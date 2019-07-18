using AutoMapper;
using Banker.Database;
using Banker.Models;
using Banker.Repository.Contracts;
using Banker.Service.Contracts;
using System;
using System.Collections.Generic;

namespace Banker.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;


        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public UserViewModel GetUser(UserViewModel userViewModel)
        {
            try
            {
                UserViewModel userModel = new UserViewModel();
                User user = _userRepository.GetUser(userViewModel);

                if (user != null)
                {
                    user.Password = null;
                    userModel = _mapper.Map<UserViewModel>(user);
                }

                return userModel;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
