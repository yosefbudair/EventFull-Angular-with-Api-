using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.repository
{
    public interface IUserRepository
    {
        public List<User> GetAllUsers();

        public bool CreateUser(User user);
        public bool UpdateUser(User user);
        public bool DeleteUser(int id);
        public User GetUserById(int id);
    }
}
