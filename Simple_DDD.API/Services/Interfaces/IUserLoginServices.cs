using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_DDD.Domain.DTOs;

namespace Simple_DDD.API.Services.Interfaces
{
    public interface IUserLoginServices
    {
        Task<string> GetToken( string userID , string userRole ,string userEmail);
        void InsertUser(UserDto input);
        List<UserDto> GetUserList();
    }
}