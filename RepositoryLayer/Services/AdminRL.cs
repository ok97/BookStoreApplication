using CommonLayer.RequestModel;
using Experimental.System.Messaging;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RepositoryLayer.Services
{
    public class AdminRL : IAdminRL
    {
        // Add connection code
        private readonly IConfiguration _configuration;
        private SqlConnection connection;

        public AdminRL(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SQLConnection()
        {
            string sqlConnectionString = _configuration.GetConnectionString("BookStoreDB");
            connection = new SqlConnection(sqlConnectionString);
        }

        public void RegisterAdmin(AdminRegisterRequest admin)
        {
            try
            {
                //UserResponce responseData = null;

                SQLConnection();
                string encryptedPassword = StringCipher.Encrypt(admin.Password);

                using (SqlCommand cmd = new SqlCommand("sp_AdminRegisterProcedure", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", admin.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", admin.LastName);
                    cmd.Parameters.AddWithValue("@Email", admin.Email);
                    cmd.Parameters.AddWithValue("@Password", encryptedPassword);
                    cmd.Parameters.AddWithValue("@Role", "Admin");

                    connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    //responseData = RegistrationResponseModel(dataReader);
                };
                // return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public string Login(string email, string password)
        {
            try
            {
                // UserResponce responseData = null;

                SQLConnection();
                string encryptedPassword = StringCipher.Encrypt(password);

                SqlCommand cmd = new SqlCommand("AdminLogin", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", encryptedPassword);

                SqlParameter userId = new SqlParameter("@AdminId", System.Data.SqlDbType.Int);
                userId.Direction = System.Data.ParameterDirection.Output;

                cmd.Parameters.Add(userId);
                connection.Open();
                cmd.ExecuteNonQuery();
                string ID = (cmd.Parameters["@AdminId"].Value).ToString();

                connection.Close();
                connection.Dispose();



                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.ASCII.GetBytes("Hello This Token Is Genereted");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
               {
                    new Claim("Email",email),
                    new Claim("AdminId",ID.ToString())
               }),
                    Expires = DateTime.UtcNow.AddHours(7),
                    SigningCredentials =
               new SigningCredentials(
                   new SymmetricSecurityKey(tokenKey),
                   SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return tokenHandler.WriteToken(token);
            }


            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        // Forgot Password
        public bool ForgotPassword(string email)
        {
            try
            {
                SQLConnection();
                SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Admin WHERE Email='" + email + "'", connection);
                DataTable dt = new DataTable();

                sda.Fill(dt);
                if (dt.Rows.Count < 1)
                {
                    return false;
                }

                //var result = _userDBContext.Users.FirstOrDefault(u => u.Email == email);
                //if (result == null)
                //{
                //    return false;
                //}
                MessageQueue queue;

                // Message Queue 
                if (MessageQueue.Exists(@".\Private$\FundooApplicationQueue"))
                {
                    queue = new MessageQueue(@".\Private$\FundooApplicationQueue");
                }
                else
                {
                    queue = MessageQueue.Create(@".\Private$\FundooApplicationQueue");
                }

                Message MyMessage = new Message();
                MyMessage.Formatter = new BinaryMessageFormatter();
                MyMessage.Body = email;
                MyMessage.Label = "Forget Password Email Fundoo Application";
                queue.Send(MyMessage);
                Message msg = queue.Receive();
                msg.Formatter = new BinaryMessageFormatter();
                EmailService.SendEmail(msg.Body.ToString(), GenerateToken(msg.Body.ToString()));
                queue.ReceiveCompleted += new ReceiveCompletedEventHandler(msmqQueue_ReceiveCompleted);
                queue.BeginReceive(TimeSpan.FromSeconds(5));
                queue.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private void msmqQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {

            MessageQueue queue = (MessageQueue)sender;
            Message msg = queue.EndReceive(e.AsyncResult);
            EmailService.SendEmail(e.Message.ToString(), GenerateToken(e.Message.ToString()));
            queue.BeginReceive(TimeSpan.FromSeconds(5));


        }
        // Generate Token
        public string GenerateToken(string email)
        {
            if (email == null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes("THIS_IS_MY_KEY_TO_GENERATE_TOKEN");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("Email",email)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        // Change Password

        public void ChangePassword(string email, string newPassword)
        {
            try
            {
                SQLConnection();
                string encryptedPassword = StringCipher.Encrypt(newPassword);
                SqlCommand cmd = new SqlCommand("UPDATE [dbo].[Admin] SET[Password] ='" + encryptedPassword + "' WHERE Email ='" + email + "' ", connection);
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
