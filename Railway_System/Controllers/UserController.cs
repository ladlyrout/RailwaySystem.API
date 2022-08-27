﻿using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using MimeKit.Text;
using RailwaySystem.API.Models;
using RailwaySystem.API.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RailwaySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserS _userServices;
        public UserController(UserS userServices)
        {
            _userServices = userServices;
        }
        [HttpPost("SaveUser")]
        public IActionResult SaveUser(User user)
        {
            return Ok(_userServices.SaveUser(user));
        }
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            return Ok(_userServices.UpdateUser(user));
        }
        [HttpGet("GetUser")]
        public IActionResult GetUser(int UserId)
        {
            return Ok(_userServices.GetUser(UserId));
        }
        [HttpGet("GetUserByEmail")]
        public IActionResult GetUserByEmail(string Email)
        {
            return Ok(_userServices.GetUserByEmail(Email));
        }
        [HttpGet("GetAllUser()")]
        public List<User> GetAllUser()
        {
            return _userServices.GetAllUser();
        }

        #region LoginModel

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = _userServices.GetUserByEmail(model.Email);
            if (user != null && model.Password == user.Password)
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                       new Claim("UserId", user.UserId.ToString()),
                       new Claim("Email", user.Email.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(12),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("55f6UmNJfrbdi8It")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            else
            {
                return BadRequest(new { message = "Email or Password is incorrect." });
            }
        }
        #endregion


        #region EmailService
       [HttpGet("EmailService")]

        public IActionResult SendEmail(string name, string reciever)
        {
            string body = "Hello, " + name + ".Your email id " + reciever + " is succesfully registered with Trainspeenic Railway Services";
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("trainspleenic@gmail.com"));
            email.To.Add(MailboxAddress.Parse(reciever));
            email.Subject = "Test WEBAPI Email Sending Service";
            email.Body = new TextPart(TextFormat.Plain) { Text = body };

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate("trainspleenic@gmail.com ", "jurkcwrlpaffpfhn");
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();
        }
        #endregion


        #region GetUserProfile

        [HttpGet("GetUserProfile")]
        [Authorize]

        public User GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = _userServices.GetUser(int.Parse(userId));
            return user;
        }

        #endregion
    }
}
