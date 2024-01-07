using LearningHub.Core.Data;
using LearningHub.Core.repository;
using LearningHub.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Infra.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public bool CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }
        public bool UpdateUser(User user)
        {
            return _userRepository.UpdateUser(user);
        }
        public bool DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }
        public User GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }
    }
}
