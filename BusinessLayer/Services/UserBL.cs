﻿using Amazon.CognitoIdentityProvider.Model;
using BusinessLayer.Interfaces;
using CommonLayer;
using CommonLayer.RequestModel;
using CommonLayer.RequestModels;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class UserBL : IUserBL
    {
        private IUserRL userRL;
        public UserBL(IUserRL userRL)
        {
            this.userRL = userRL;
        }        
        public void RegisterUser(RegisterUserRequest user)
        {
            try
            {
                this.userRL.RegisterUser(user);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        
        //Users login
        public string Login(string email, string password)
        {
            try
            {
                return this.userRL.Login(email, password);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // Forgot Password
        public bool ForgotPassword(string email)
        {
            try
            {
                return this.userRL.ForgotPassword(email);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // Change Password
        public void ChangePassword(string email, string newPassword)
        {
            try
            {
                this.userRL.ChangePassword(email, newPassword);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
