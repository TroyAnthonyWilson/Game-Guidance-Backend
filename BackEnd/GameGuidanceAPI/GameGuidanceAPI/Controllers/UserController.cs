﻿using GameGuidanceAPI.Context;
using GameGuidanceAPI.DTO;
using GameGuidanceAPI.Helpers;
using GameGuidanceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GameGuidanceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly GameGuidanceDBContext _authContext;
        public UserController(GameGuidanceDBContext gameGuidanceDBContext)
        {
            _authContext = gameGuidanceDBContext;
        }


        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] User userObj)
        {

            if(userObj == null)
                return BadRequest();

            var user = await _authContext.Users.FirstOrDefaultAsync(x => x.UserName == userObj.UserName);

            if(user == null)
                return NotFound(new { Message = "User Not Found!" });

            if(!PasswordHasher.VarifyPassword(userObj.Password, user.Password))
            {
                return BadRequest(new { Message = "Password is Incorrect" });
            }

            user.Token = CreateJwt(user);
            await _authContext.SaveChangesAsync();
            return Ok(new
            {
                Token = user.Token,
                Message = "Login Success!"
            });
        }


        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] UserLoginSignup userObj)
        {
            User newUser = new User{
                newUser.UserName = userObj.UserName,
                newUser.Password = userObj.Password,
            };
            if(newUser == null)
                return BadRequest();

            if(await CheckUserNameExistAsync(newUser.UserName))
                return BadRequest(new { message = "Username Already Exists!" });



            newUser.Password = PasswordHasher.HashPassword(userObj.Password);
            newUser.Token = "";
            await _authContext.Users.AddAsync(newUser);
            await _authContext.SaveChangesAsync();
            return Ok(new { Message = "User Registered" });
        }

        private async Task<bool> CheckUserNameExistAsync(string userName)
            => await _authContext.Users.AnyAsync(x => x.UserName == userName);


        private static string CreateJwt(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysceret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                //new Claim(ClaimTypes.Role, "user"),
                new Claim(ClaimTypes.Name, user.UserName)
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            return jwtTokenHandler.WriteToken(token);
        }


        //code for testing
        //[Authorize]
        //[HttpGet]
        //public async Task<ActionResult<User>> GetAllUsers()
        //{
        //    return Ok(await _authContext.Users.ToListAsync());
        //}

        [Authorize]
        [HttpPost("UserData")]
        public async Task<IActionResult> UserData()
        {
            var authHeader = Request.Headers["Authorization"];
            var tokenString = authHeader.ToString().Split(" ")[1];
            User user = _authContext.Users.Where(u => u.Token == tokenString).FirstOrDefault();
            if(user == null)
            {
                return NotFound();
            }
            return Ok(new { Message = user.UserName });
        }
    }
}
