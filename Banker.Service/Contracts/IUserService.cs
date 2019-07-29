using Banker.Entity;
using Banker.Models;
using System.Collections.Generic;

namespace Banker.Service.Contracts
{
    public interface IUserService
    {
        UserViewModel GetUser(UserViewModel userViewModel);

        List<UserViewModel> GetAllUsers();

        UserViewModel InertUser(UserViewModel userViewModel);
    }
}