using Amazon.CognitoIdentityProvider.Model;
using CommonLayer;
using CommonLayer.RequestModel;
using CommonLayer.RequestModels;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserRL
    {      
        void RegisterUser(RegisterUserRequest user);    //Register User         
        string Login(string email, string password);  // User login        
        bool ForgotPassword(string email);// Forgot Password      
        void ChangePassword(string email, string newPassword);  // Change Password
    }
}
