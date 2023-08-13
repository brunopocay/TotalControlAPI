using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;


namespace TotalControlAPI.Services.SecurityServices
{
    public class SecurityServices : Controller, ISecurityService
    {
        Users user = new Users();
        private readonly IConfiguration _configuration;
        private readonly DataContext _dataContext;
        
        public SecurityServices(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;   
            _dataContext = context;
        }    

        public void CreatePasswordHash(string password, out string passwordHashBase64, out string passwordSaltBase64)
        {
            using ( var hmac = new HMACSHA512() )
            {
                byte[] passwordSalt = hmac.Key;
                byte[] passwordHashBytes = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                passwordSaltBase64 = Convert.ToBase64String(passwordSalt);
                passwordHashBase64 = Convert.ToBase64String(passwordHashBytes);
            }
        }

        public string CreateToken(Users user)
        {
            List<Claim> claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, user.Email)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: credentials
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public bool VerifyPasswordHash(string password, string passwordHash, string passwordSalt)
        {
            byte[] passwordHashBytes = Convert.FromBase64String(passwordHash);
            byte[] passwordSaltBytes = Convert.FromBase64String(passwordSalt);
            
            using ( var hmac = new HMACSHA512(passwordSaltBytes))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHashBytes);
            }   
                
        }

        public RefreshToken GenerateRefreshToken(Users user)
        {
            var refreshToken = new RefreshToken
            {          
                UserId = user.Id,
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            _dataContext.RefreshToken.Add(refreshToken);
            _dataContext.SaveChanges();
            return refreshToken;
        }

        public Users SetRefreshToken(Users user, RefreshToken newRefreshToken, HttpResponse response)
        {
       
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires,
            };
            response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);
                   
            user.RefreshToken = newRefreshToken.Token;
            user.DateCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;

            _dataContext.Users.Update(user);
            _dataContext.SaveChanges();           
            return user;
        }       
    }
}
