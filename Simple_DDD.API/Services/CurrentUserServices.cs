using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Simple_DDD.API.Services.Interfaces;
using Simple_DDD.Domain.DTOs;
using Simple_DDD.Infrastructure;
using Simple_DDD.Infrastructure.Context;

namespace Simple_DDD.API.Services
{
    public class CurrentUserServices :ICurrentUserServices
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        
 
        public CurrentUserServices(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            
            

        }
        public string GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue("user_id");
            return userId;
        }

        public string GetUserEmail()
        {
            var userEmail = _httpContextAccessor.HttpContext.User.FindFirstValue("user_email");
            return userEmail;

        }
        public string GetUserRole()
        {
            var userEmail = _httpContextAccessor.HttpContext.User.FindFirstValue("user_role");
            return userEmail;
        }


    }
}