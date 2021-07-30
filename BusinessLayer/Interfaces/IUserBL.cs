using Amazon.CognitoIdentityProvider.Model;
using CommonLayer;
using CommonLayer.RequestModel;
using CommonLayer.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserBL
    {
        void RegisterUser(RegisterUserRequest user);    // Register User
        string Login(string email, string password); // User login      
        bool ForgotPassword(string email);  // Forgot Password       
        void ChangePassword(string email, string newPassword); // Change Password
    }
}
