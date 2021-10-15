using EBO.CodingTask.API.Data;
using EBO.CodingTask.API.Models;
using System.Web.Http;

namespace EBO.CodingTask.API.Controllers
{
    public class LoginController : ApiController
    {
        private static readonly IUserService _userRepository = new UserService();
        // POST: api/Login
        public AuthResponse Post([FromBody] User loginRequest)
        {
            return _userRepository.Login(loginRequest);
        }
    }
}