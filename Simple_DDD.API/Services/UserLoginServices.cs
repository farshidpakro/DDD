using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.IdentityModel.Tokens;
using Simple_DDD.API.Services.Interfaces;
using Simple_DDD.Domain.DTOs;
using Simple_DDD.Infrastructure;
using Simple_DDD.Infrastructure.Context;

namespace Simple_DDD.API.Services;
public class UserLoginServices : IUserLoginServices
{
    private IConfiguration _config;
private readonly IMapper _mapper;
 private readonly IRepositoryWrapper _repo;
    public UserLoginServices(IConfiguration config  ,IMapper mapper , IRepositoryWrapper repo)
    {
        _config = config;
        _mapper =mapper;
        _repo =repo;
    }
        public void InsertUser(UserDto input)
        {
           var user = _mapper.Map<User>(input);
            _repo.User.Create(user);
            _repo.Save();
        }
          public List<UserDto> GetUserList()
        {
          return  _repo.User.FindAll().ProjectTo<UserDto>(_mapper.ConfigurationProvider).ToList();
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