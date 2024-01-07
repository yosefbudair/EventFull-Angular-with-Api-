using LearningHub.Core.Data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LearningHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;


        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public List<Role> GetAllRole()
        {
            return _roleService.GetAllRole();
        }
        [HttpGet]
        [Route("GETroleBYID/{id}")]
        public Role GETroleBYID(int id)
        {
            return _roleService.GETroleBYID(id);
        }
    }
}
