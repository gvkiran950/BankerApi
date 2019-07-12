using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Banker.Contracts;
using Banker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BankerApiPro.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private IUserRepository _userRepository;
        private IConfiguration _config;

        public AccountsController(IUserRepository userRepository, IConfiguration config)
        {
            _userRepository = userRepository;
            _config = config;
        }

        [AllowAnonymous]
        [Route("[action]")]
        [HttpPost("Login")]
        public async Task<IActionResult> Post([FromBody] UserModel userModel)
        {
            IActionResult response = Unauthorized();
            if (ModelState.IsValid)
            {
                var result = await _userRepository.IsUserExist(userModel);
                if (result)
                    response = Ok(new { toke = GenerateJSONWebToken(userModel) });
            }
            
            return response;

        }

        //GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private string GenerateJSONWebToken(UserModel userModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha384);

            var claims = new[] {
                new Claim("UserId",userModel.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userModel.UserName)
            };

            var Token = new JwtSecurityToken
                (
                _config["Jwt:Issuer"]
                , _config["Jwt:Issuer"]
                , claims
                , expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(Token);

        }
    }


}
