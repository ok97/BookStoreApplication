using BookStoreApplication.Contracts;
using BusinessLayer.Interfaces;
using CommonLayer.RequestModel;
using CommonLayer.ResponseModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        //Declare private object for logger object
        private readonly ILoggerService _logger;
        private readonly IAdminBL adminBL; //object IAdmin class
        public AdminController(IAdminBL adminBL, ILoggerService logger)
        {
            this.adminBL = adminBL;
            _logger = logger;
        }
  
        [HttpPost("Register")]
        public ActionResult RegisterAdmin(AdminRegisterRequest admin)
        {
            try
            {
                _logger.LogInfo("Admin Register Account Successfull");
                this.adminBL.RegisterAdmin(admin);
                string userFullName = admin.FirstName + " " + admin.LastName;
                return this.Ok(new { success = true, message = $"Hello {userFullName} Your Account Created Successfully {admin.Email}" });
            }
            catch (Exception ex)
            {
                _logger.LogError("Admin Registration Failed");
                return this.BadRequest(new { success = false, message = $"Registration Failed {ex.Message}" });
                
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(AdminLogin cred)
        {
            var token = this.adminBL.Login(cred.Email, cred.Password);
            UserResponce data = new UserResponce();
            string message, userFullName;
            bool success = false;
            if (token == null)
            {
                _logger.LogWarn("Invalid Email and Password");
                message = "Enter Valid Email & Password";
                return Ok(new { success, message });
            }
            else
            {
                _logger.LogInfo("Logged in Successfully");
                success = true;
                userFullName = data.FirstName + " " + data.LastName;
                message = "Hello " + userFullName + ", You Logged in Successfully";
                return this.Ok(new { success = true, token = token, message = $"Login {cred.Email}" });
            }
        }

        [HttpPost("Forgot")]
        public ActionResult ForgotPassword(ForgotPassword user)
        {
            try
            {
                bool isExist = this.adminBL.ForgotPassword(user.Email);
                if (isExist)
                {
                    _logger.LogInfo($"Forgot Password Reset Link sent to {user.Email}");
                    Console.WriteLine($"Email User Exist with {user.Email}");
                    return Ok(new { success = true, message = $"Reset Link sent to {user.Email}" });
                }
                else
                {
                    _logger.LogError("Forgot Password Failed");
                    return BadRequest(new { success = false, message = $"No user Exist with {user.Email}" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPut("Reset")]
        public ActionResult ResetPassword(UserRestPassword user)
        {
            try
            {
                if (user.NewPassword == user.ConfirmPassword)
                {
                    _logger.LogInfo($"Your Account Password Changed Successfully");
                    var EmailClaim = User.Claims.FirstOrDefault(x => x.Type.ToString().Equals("Email", StringComparison.InvariantCultureIgnoreCase));
                    this.adminBL.ChangePassword(EmailClaim.Value, user.NewPassword);
                    return Ok(new { success = true, message = "Your Account Password Changed Successfully", Email = $"{EmailClaim.Value}" });
                }
                else
                {
                    _logger.LogWarn($"New Password and Confirm Password are not equal. ");
                    return Ok(new { success = false, message = "New Password and Confirm Password are not equal." });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
