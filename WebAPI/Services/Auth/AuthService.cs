using Common.Model;
using Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Services.Email;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Services.Auth
{
    public class AuthService : IAuthService
    {
        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IEmailService _emailService;

        public AuthService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IHttpContextAccessor contextAccessor, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _contextAccessor = contextAccessor;
            _emailService = emailService;
        }

        public async Task<string> LoginUser(Login login)
        {
            var user = await _userManager.FindByEmailAsync(login.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, login.Password))
            {
                await _signInManager.PasswordSignInAsync(login.Email, login.Password, true, lockoutOnFailure: false);
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5001",
                    audience: "https://localhost:5001",
                    claims: new List<Claim> { new Claim(ClaimTypes.NameIdentifier, user.Id), new Claim(ClaimTypes.Name, user.UserName) },
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                var result = new AuthenticatedResponse { Token = tokenString };

                return result.Token.ToString();
            }
            else
            {
                var result = ErrorMessageConstant.PleaseEnterValidEmailPassword;
                throw new ApplicationException(result);
            }
        }

        public async Task<string> RegisterUser(Register register)
        {
            var user = new IdentityUser
            {
                Email = register.Email,
                UserName = register.Email,
                PhoneNumber = register.PhoneNumber
            };
            var exitingUser = await _userManager.FindByEmailAsync(register.Email);
            if (exitingUser == null)
            {

                var result = await _userManager.CreateAsync(user, register.Password);
                if (!result.Succeeded)
                {
                    var error = ErrorMessageConstant.PleaseEnterValidInput;
                    return (error);
                }
                return (ErrorMessageConstant.RegisteredSuccefully);
            }
            var existingerror = ErrorMessageConstant.EmailAllreadyExist;
            throw new ApplicationException(existingerror);
        }

        public async Task LogOutUser()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<string> ChangePassword(ChangePasswordViewModel changePassword)
        {
            var userId = _contextAccessor.HttpContext.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId);
            var result = await _userManager.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);
            if (result.Succeeded)
            {
                return (ErrorMessageConstant.PasswordChangedSuccesfully);
            }
            throw new ApplicationException(ErrorMessageConstant.IncorrectCurrentPassword);
        }

        public async Task<string> ForgetPassword(ForgotPasswordViewModel forgotPassword)
        {
            var user = _userManager.FindByEmailAsync(forgotPassword.Email);
            if (user.Result != null)
            {
                var userId = user.Result.Id;
                var token = await _userManager.GeneratePasswordResetTokenAsync(user.Result);
                if (!string.IsNullOrEmpty(token))
                {
                    await SendEmail(forgotPassword, token, userId);
                    return ("Token: " + token + "\nuserId: " + userId);
                }
            }
            throw new ApplicationException(ErrorMessageConstant.PleaseEnterCorrectEmail);
        }

        public async Task SendEmail(ForgotPasswordViewModel forgotPassword, string token, string userId)
        {
            string resetPasswordUrl = $"https://localhost:7042/swagger/index.html?token={token}&userId={userId}";
            MailRequest mailRequest = new MailRequest();
            mailRequest.ToEmail = forgotPassword.Email;
            mailRequest.Subject = "Welcome to Aspirefox";
            mailRequest.Body = $"Send Email for Confirmation <br><a href='{resetPasswordUrl}'>click Here</a>";
            await _emailService.SendEmailAsync(mailRequest);
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordViewModel resetPassword)
        {
            return await _userManager.ResetPasswordAsync(await _userManager.FindByIdAsync(resetPassword.UserId), resetPassword.Token, resetPassword.NewPassword);
        }
    }
}
