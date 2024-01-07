using LearningHub.Core.Data;
using LearningHub.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("uploadImage")]
        [HttpPost]
        public User UploadImage()
        {

                var file = Request.Form.Files[0];

            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("D:\\study\\1-Training\\Angular\\Projects\\Final\\src\\assets\\Images\\Users", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {

                file.CopyTo(stream);

            }

            User item = new User();

            item.Image = fileName;

            return item;

        }

        [HttpGet]
        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();  
        }

        [HttpPost]
        [Route("Create")]
        public bool CreateUser(User Users)
        {
            return _userService.CreateUser(Users);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateUser(User Users)
        {
            return _userService.UpdateUser(Users);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteUser(int id)
        {
            return _userService.DeleteUser(id);
        }
        [HttpGet]
        [Route("GetUserById/{id}")]
        public User GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }
    }
}
