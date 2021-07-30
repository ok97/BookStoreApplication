using CommonLayer.RequestModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IAdminRL
    {
        void RegisterAdmin(AdminRegisterRequest admin);
        string Login(string email, string password);

        // Forgot Password
        bool ForgotPassword(string email);

        // Change Password
        void ChangePassword(string email, string newPassword);
    }
}
