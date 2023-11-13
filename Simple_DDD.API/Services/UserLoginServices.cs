using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Simple_DDD.API.Services.Interfaces;

namespace Simple_DDD.API.Services;
public class UserLoginServices : IUserLoginServices
{
    private IConfiguration _config;

    public UserLoginServices(IConfiguration config)
    {
        _config = config;
    }

    public async Task<string> GetToken(string userID, string userRole, string userEmail)
    {
        try
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
       // new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
       // new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
        new Claim("user_id",userID),
        new Claim("user_email",userEmail),
        new Claim("user_role",userRole),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);
            var res = new JwtSecurityTokenHandler().WriteToken(token);
            return res;
        }
        catch (Exception ex)
        {

            throw ex;
 
       }



    }
}