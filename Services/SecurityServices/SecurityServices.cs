using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace TotalControlAPI.Services.SecurityServices
{
    public class SecurityServices : ISecurityService
    {
        private readonly IConfiguration _configuration;

        public SecurityServices(IConfiguration configuration)
        {
            this._configuration = configuration;            
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
    }
}
