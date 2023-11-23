using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using TotalControlAPI.Models;

namespace TotalControlAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private ISecurityServices _securityService;
        private readonly DataContext _dataContext;
        private readonly IUserService _userService;
        
        public AuthController(DataContext context, ISecurityServices securityService, IUserService userService)
        {
            _dataContext = context;     
            _securityService = securityService;
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<string> GetMe()
        {
            var userData = _userService.GetMyData();
            return Ok(userData);
        }

        [HttpPost("login"), AllowAnonymous]
        public ActionResult<string> login(UserRequestDTO request)
        {

            var user = _dataContext.Users.SingleOrDefault(u => u.Email == request.Email);

            try
            {
                if(user is null)
                {
                    return NotFound("Usuario não encontrado ou senha incorreta.");
                }

                if(!_securityService.VerifyPasswordHash(request.Senha, user.PasswordHash!, user.PasswordSalt!))
                {                                
                    return NotFound("Usuario não encontrado ou senha incorreta.");
                }

                string token = _securityService.CreateToken(user);

                var refreshToken = _securityService.GenerateRefreshToken(user);
                _securityService.SetRefreshToken(user, refreshToken, Response);       
                return Ok(token);
            }
            catch(Exception er)
            {
                return StatusCode(500, $"Erro interno do servidor: {er.Message}");
            }
        }

        [HttpPost("refreshtoken"), AllowAnonymous]
        public ActionResult<string> RefreshToken(UserRequestDTO request)
        {
            var user = _dataContext.Users.SingleOrDefault(u => u.Email == request.Email);
            if(user is null || !_securityService.VerifyPasswordHash(request.Senha, user.PasswordHash!, user.PasswordSalt!))
            {
                return NotFound("Usuario não encontrado ou senha incorreta.");
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

        [HttpPost("register"), AllowAnonymous]
        public async Task<ActionResult<string>> Register(UserRegisterDTO user)
        {
            try
            {
                var result = await _userService.Register(user);
                string token = _securityService.CreateToken(result);
                var refreshToken = _securityService.GenerateRefreshToken(result);
                _securityService.SetRefreshToken(result, refreshToken, Response);

                return Ok(token);
            }
            catch ( DbUpdateException dbError)
            {
                return StatusCode(500, $"Erro interno do servidor: {dbError.Message}");
            }
            catch (Exception er)
            {
                return StatusCode(404, er.Message);
            }
        
        }

    }
}
