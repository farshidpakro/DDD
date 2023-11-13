using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Simple_DDD.Infrastructure.Context;
using Simple_DDD.Infrastructure.Repositores;
using Simple_DDD.Infrastructure.Repositores.Interfaces;

namespace Simple_DDD.Infrastructure
{
    public class RepositoryWrapper : IRepositoryWrapper
    {  private ApplicationDbContext _repoContext;
            public RepositoryWrapper(ApplicationDbContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        private IUserRepository _user;
        public IUserRepository User => _user ??=  new UserRepository(_repoContext);


        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}