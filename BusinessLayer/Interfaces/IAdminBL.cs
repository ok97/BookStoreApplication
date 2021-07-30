using CommonLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
   public interface IAdminBL
    {
        void RegisterAdmin(AdminRegisterRequest admin);
        string Login(string email, string password);
        bool ForgotPassword(string email);

        // Change Password
        void ChangePassword(string email, string newPassword);
    }
}
