using Common.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Auth
{
    public interface IAuthService
    {
        Task<string> LoginUser(Login login);
        Task<string> RegisterUser(Register register);
        Task LogOutUser();
        Task<string> ChangePassword(ChangePasswordViewModel changePassword);
        Task<string> ForgetPassword(ForgotPasswordViewModel forgotPassword);
        Task SendEmail(ForgotPasswordViewModel forgotPassword, string token , string userId);
        Task<IdentityResult> ResetPassword(ResetPasswordViewModel resetPassword);
    }
}
