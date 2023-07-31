using Azure.Storage.Blobs;
using Common.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Services.Auth;
using Services.Image;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private IImageService _imageService;
        public AuthController(IAuthService authService, IImageService imageService)
        {
            _authService = authService;
            _imageService= imageService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(Register register)
        {
            try
            {
                var result = await _authService.RegisterUser(register);
                return Ok(result);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Login userModel)
        {
            try
            {
                var result = await _authService.LoginUser(userModel);
                return Ok(result);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("logOut")]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _authService.LogOutUser();
                return Ok(ErrorMessageConstant.LogoutSuccessfully);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePassword)
        {
            try
            {
                var result = await _authService.ChangePassword(changePassword);
                return Ok(result);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("forget-password")]
        public async Task<IActionResult> ForgetPassword(ForgotPasswordViewModel forgotPassword)
        {
            try
            {
                var result = await _authService.ForgetPassword(forgotPassword);
                return Ok(result);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPassword)
        {
            try
            {
                var result = await _authService.ResetPassword(resetPassword);
                return Ok(result);
            }
            catch (ApplicationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Image Controller for testing purpose

        [AllowAnonymous]
        [HttpPost("upload-image")]
        public async Task<IActionResult> UploadImage([FromForm]ImageViewModel imageViewModel)
        {
            try
            {

            if(imageViewModel.File == null && imageViewModel.File.FileName == null)
            {
                return BadRequest("Please enter valid input");
                }
            var result = await _imageService.UploadImage(imageViewModel.File);
            return Ok(result);
            }
            catch (ApplicationException ex)
            {
                throw ex;
            }
        }
    }

}
