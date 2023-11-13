using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_DDD.API.Services.Interfaces
{
    public interface IUserLoginServices
    {
        Task<string> GetToken( string userID , string userRole ,string userEmail);
    }
}