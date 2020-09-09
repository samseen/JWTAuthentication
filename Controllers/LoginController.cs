using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTAuthDemo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JWTAuthDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public IActionResult Login(string username, string pass)
        {
            UserModel login = new UserModel();
            login.UserName = username;
            login.Password = pass;
            IActionResult response = Unauthorized();

            var user = AuthenticateUser(login);

            if(user != null)
            {
                var tokenStr = GenerateJSONWebToken(user);
                response = Ok(new { token = tokenStr });
            }
        }

        private UserModel AuthenticateUser(UserModel login)
        {
            UserModel user = null;
            if(login.UserName == "samseen" && login.Password == "123")
            {
                user = new UserModel { UserName = "Samseen", EmailAddress = "developersamseen@outlook.com", Password = "123" };
            }
            return user;
        }

        private string GenerateJSONWebToken(UserModel userinfo)
        {
            var securityKey = new SymmetricSecurityKey();
        }
    }
}
