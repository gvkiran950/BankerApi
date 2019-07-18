using Banker.Database;
using Banker.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banker.Service.Contracts
{
    public interface IUserService
    {
        UserViewModel GetUser(UserViewModel userViewModel);
        List<User> GetAllUsers();
    }
}
