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
    
    public class RoleService:IRoleService
    {
        private readonly IRoleRepository _RoleRepository;
        public RoleService(IRoleRepository RoleRepository)
        {
            this._RoleRepository = RoleRepository;
        }
        public List<Role> GetAllRole()
        {
            return _RoleRepository.GetAllRole();
        }
        public Role GETroleBYID(int id)
        {
            return _RoleRepository.GETroleBYID(id);
        }
    }
}
