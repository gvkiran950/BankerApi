using Banker.Entity;
using Banker.Models;
using System.Collections.Generic;

namespace Banker.Repository.Contracts
{
    public interface IUserRepository
    {
        User GetUser(UserViewModel userModel);

        List<User> GetAllUsers();
        User InsertUser(User user);
    }
}