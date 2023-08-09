﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TotalControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private ISecurityService _securityService;
        private readonly DataContext _dataContext;
        private readonly IUserService _userService;
        
        public AuthController(DataContext context, ISecurityService securityService, IUserService userService)
        {
            _dataContext = context;     
            _securityService = securityService;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<string> GetMe()
        {
            var userName = _userService.GetMyName();
            return Ok(userName);
        }

        [HttpPost("login"), AllowAnonymous]
        public ActionResult<Users> login(UserRequestDTO request)
        {

            var user = _dataContext.Users.SingleOrDefault(u => u.Email == request.Email);

            if(user is null)
            {
                return BadRequest("Usuario não encontrado ou senha incorreta.");
            }

            if(!_securityService.VerifyPasswordHash(request.Senha, user.PasswordHash, user.PasswordSalt))
            {                                
                return BadRequest("Usuario não encontrado ou senha incorreta.1");
            }

            string token = _securityService.CreateToken(user);

            var refreshToken = _securityService.GenerateRefreshToken(user);
            _securityService.SetRefreshToken(user, refreshToken, Response);       
            return Ok(token);
        }

        [HttpPost("refreshtoken"), AllowAnonymous]
        public ActionResult<string> RefreshToken(UserRequestDTO request)
        {
            var user = _dataContext.Users.SingleOrDefault(u => u.Email == request.Email);
            if(user is null)
            {
                return BadRequest("User not found.");
            }

            var refreshToken = Request.Cookies["refreshToken"];

            if(!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Refresh Token Inválido.");
            }
            else if(user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token Expirado");
            }

            string token = _securityService.CreateToken(user);
            var newRefreshToken = _securityService.GenerateRefreshToken(user);
            _securityService.SetRefreshToken(user, newRefreshToken, Response);

            return Ok(token);
        }

        
    }
}