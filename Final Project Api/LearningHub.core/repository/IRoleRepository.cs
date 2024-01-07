using LearningHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Core.repository
{
    public interface IRoleRepository
    {
        public List<Role> GetAllRole();
        public Role GETroleBYID(int id);
       
    }
}
