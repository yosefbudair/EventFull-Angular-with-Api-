using LearningHub.Core.Data;
using LearningHub.Core.repository;
using LearningHub.Core.Services;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Services
{
    public class JWTService : IJWTService
    {

        private readonly IJWTRepository _jWTRepository;

        public JWTService(IJWTRepository jWTRepository)
        {
            _jWTRepository = jWTRepository;
        }


        public string userLogin(User login)
        {
            //return jwtRepository.Auth(login); ---> useranme & rolename(payload)
            var result = _jWTRepository.UserLogin(login);//result = useraname & rolename

            if (result == null)
                return null;
            else
            {
                // Generate Token
                // 1- Token Handler --> Class (Create Token)
                var TokenHandler = new JwtSecurityTokenHandler();

                // 2- Token Key --> The same as key in the startup
                var TokenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SECRET USED TO SIGN AND VERIFY JWT TOKEN"));

                // 3- Token Descriptor --> Paylod (result) + prop
                var TokenDescriptor = new SecurityTokenDescriptor
                {
                    // Subject
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        // new Claim(type, value)
                        new Claim("name", result.Username),

                        // new Claim(type, value)
                        new Claim("role", result.Roleid.ToString())
                    }),

                    // Expires
                    Expires = DateTime.Now.AddSeconds(10),

                    // Signing Credintials

                    SigningCredentials = new SigningCredentials(TokenKey, SecurityAlgorithms.HmacSha256Signature)
                };

                var token = TokenHandler.CreateToken(TokenDescriptor);
                return TokenHandler.WriteToken(token); // string
            }
        }
    }
}
