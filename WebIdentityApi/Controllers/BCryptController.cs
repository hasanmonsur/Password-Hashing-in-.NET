using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebIdentityApi.Contacts;
using WebIdentityApi.Models;

namespace WebIdentityApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BCryptController : ControllerBase
    {
        private readonly IUserRepository _userManager;
        private readonly IPasswordService _passwordService;
        public BCryptController(IUserRepository userManager, IPasswordService passwordService)
        {
            _userManager = userManager;
            _passwordService = passwordService;
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var hashedPassword = _passwordService.HashPassword(model.Password);
            if (!string.IsNullOrEmpty(hashedPassword))
            {
                _userManager.CreateUser(model.Email, hashedPassword);
                return Ok(hashedPassword);
            }
            else return BadRequest(new { message = "fail..." });

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            // Fetch stored hashed password from the database
            string storedHash =  _userManager.ValidateUser(model.Email);

            var result = _passwordService.VerifyPassword(model.Password, storedHash);
            if (result)
            {
                // Password is valid, proceed with login
                return Ok(result);
            }
            else
            {
                return BadRequest(new { message = "fail..." });
            }                
        }

    }
}
