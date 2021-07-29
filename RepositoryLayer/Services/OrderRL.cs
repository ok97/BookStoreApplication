using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
   public class OrderRL: IOrderRL
    {
        // Add connection code
        private readonly IConfiguration _configuration;
        private SqlConnection connection;



        public OrderRL(IConfiguration configuration)
        {
            _configuration = configuration;

        }

        public void SQLConnection()
        {
            string sqlConnectionString = _configuration.GetConnectionString("BookStoreDB");
            connection = new SqlConnection(sqlConnectionString);
        }

        public bool AddOrder(int UserId, int CartId,int AddressId)
        {
            try
            {

                SQLConnection();
                using (SqlCommand cmd = new SqlCommand("sp_AddOrder", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserId", UserId);
                    cmd.Parameters.AddWithValue("@CartId", CartId);
                    cmd.Parameters.AddWithValue("@AddressId", AddressId);
                   
                    connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();

                };
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<OrderResponse> GetListOfOrders(int UserId)
        {
            try
            {
                List<AdminBookResponseData> bookList = null;
                SQLConnection();
                bookList = new List<AdminBookResponseData>();
                using (SqlCommand cmd = new SqlCommand("sp_GetListOfBooks", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    bookList = ListBookResponseModel(dataReader);
                };
                return bookList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private List<AdminBookResponseData> ListBookResponseModel(SqlDataReader dataReader)
        {
            try
            {
                List<AdminBookResponseData> bookList = new List<AdminBookResponseData>();
                AdminBookResponseData responseData = null;
                while (dataReader.Read())
                {
                    responseData = new AdminBookResponseData
                    {
                        BookId = Convert.ToInt32(dataReader["BookId"]),
                        Name = dataReader["Name"].ToString(),
                        Author = dataReader["Author"].ToString(),
                        Language = dataReader["Language"].ToString(),
                        Category = dataReader["Category"].ToString(),
                        Pages = dataReader["Pages"].ToString(),
                        Price = dataReader["Price"].ToString(),
                        Quantity = Convert.ToInt32(dataReader["Quantity"])
                    };
                    bookList.Add(responseData);
                }
                return bookList;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
