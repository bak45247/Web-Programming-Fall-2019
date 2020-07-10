using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Portal.Services.V1U0
{
    public class SecurityProvider : ISecurityProvider
    {
        private RSA rsa;

        public SecurityProvider()
        {
            rsa = RSA.Create();
        }

        public string GetToken(List<Claim> claims)
        {
            var handler = new JwtSecurityTokenHandler();
            var credentials = new SigningCredentials(new RsaSecurityKey(rsa.ExportParameters(true)), SecurityAlgorithms.RsaSha256);
            var token = new JwtSecurityToken("www.webprogrammingserver.com", "www.bethel.edu", claims, DateTime.UtcNow.Subtract(TimeSpan.FromMinutes(15)), DateTime.UtcNow.AddDays(1), credentials);
            return handler.WriteToken(token);
        }

        public bool ValidateToken(string token)
        {
            var validationParameters = new TokenValidationParameters()
            {
                ValidIssuer = "www.webprogrammingserver",
                ValidAudience = "www.bethel.edu",
                IssuerSigningKey = new RsaSecurityKey(rsa.ExportParameters(false))
            };

            var handler = new JwtSecurityTokenHandler();

            try
            {
                handler.ValidateToken(token, validationParameters, out SecurityToken securityToken);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
