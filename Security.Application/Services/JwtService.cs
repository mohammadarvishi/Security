using Microsoft.IdentityModel.Tokens;
using Security.Application.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Security.Application.Services
{
    public class JwtService: IJwtService
    {
        public string GenerateToken(string userid)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("ABNM YE KJLK FD OPIL KLM AERIFY ERT OOKENS, REPLACE AB POIN YOUN OWN SECRET, IT HTR PO RET STWINC");
            var encrytionKey = Encoding.UTF8.GetBytes("qwsadfrewtyh4532");
            var encryptingCredentials = new EncryptingCredentials(new SymmetricSecurityKey(encrytionKey), SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddMinutes(20),
                EncryptingCredentials = encryptingCredentials,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userid",userid)
                }),


                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
