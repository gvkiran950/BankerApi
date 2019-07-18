﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Banker.Database;
using Banker.Models;
using Banker.Repository.Contracts;
using Banker.Service.Contracts;
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
        private IUserService _userService;
        private IConfiguration _config;
        private IMapper _mapper;
        public AccountsController(IUserService userService, IConfiguration config,IMapper mapper)
        {
            _userService = userService;
            _config = config;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [Route("[action]")]
        [HttpPost("Login")]
        public  IActionResult Post([FromBody] UserViewModel userViewModel)
        {
            IActionResult response = Unauthorized();
            if (ModelState.IsValid)
            {
                UserViewModel userModel = _userService.GetUser(userViewModel);

                if (userModel != null)
                {                    
                    userModel.Token = GenerateJSONWebToken(userViewModel);
                    response = Ok(userModel);
                }
            }

            return response;

        }

        [AllowAnonymous]
        //GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }


        //GET api/values
        [Route("[action]")]
        [HttpGet("SomeGetinfo")]
        public ActionResult<IEnumerable<string>> GetList()
        {
            return new string[] { "value1", "value2", "value3", "value4" };
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

        private string GenerateJSONWebToken(UserViewModel userViewModel)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha384);

            var claims = new[] {
                new Claim("UserId",userViewModel.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, userViewModel.UserName)
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
