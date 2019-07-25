using Banker.Entity;
using Banker.Models;
using Banker.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Banker.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly BankerDbContext _bankerDbContext;

        public UserRepository(BankerDbContext bankerDbContext)
        {
            _bankerDbContext = bankerDbContext;
        }

        public User GetUser(UserViewModel userModel)
        {
            var result = _bankerDbContext.Users.Where(u => u.UserName == userModel.UserName && u.Password == userModel.Password).SingleOrDefault();
            return result;
        }

        public List<User> GetAllUsers()
        {
            return _bankerDbContext.Users.ToList();
        }

        public User InsertUser(User user)
        {
            try
            {
                _bankerDbContext.Users.Add(user);
                _bankerDbContext.SaveChanges();

                return user;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}