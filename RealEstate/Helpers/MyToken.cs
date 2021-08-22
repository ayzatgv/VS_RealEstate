using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Web;
using Microsoft.IdentityModel.Tokens;
using RealEstate.Models;

namespace RealEstate.Helpers
{
    public class MyToken
    {
        private static readonly string _secretkey = "db3OIsj+BXE9NZDy0t8W3TcNekrF+2d/1sFnWG4HnV8TZY30iTOdtVWJG8abWvB1GlOgJuQZdcF2Luqm/hccMw==";

        public static string TokenGeneration(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            ClaimsIdentity claimsIdentity = new ClaimsIdentity();

            claimsIdentity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.ID.ToString()));
            claimsIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Username));

            var token = tokenHandler.CreateJwtSecurityToken(expires: DateTime.UtcNow.AddHours(24), subject: claimsIdentity, signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.Default.GetBytes(_secretkey)), SecurityAlgorithms.HmacSha256Signature));

            return tokenHandler.WriteToken(token);
        }

        private static TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretkey)),
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ValidateAudience = false,
                ValidateIssuer = false,
                ClockSkew = TimeSpan.FromMilliseconds(100)
            };
        }

        public static ClaimsPrincipal TokenDecryption(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            ClaimsPrincipal claimsPrincipal;

            try
            {
                claimsPrincipal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
            }
            catch (Exception)
            {
                return null;
            }

            return claimsPrincipal;
        }

        public static int GetUserID(string token)
        {
            ClaimsPrincipal claimsPrincipal = TokenDecryption(token);

            return Convert.ToInt32(claimsPrincipal.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
        }
    }
}