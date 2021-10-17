using EBO.CodingTask.API.Data;
using EBO.CodingTask.API.Models;
using System.Web.Http;

namespace EBO.CodingTask.API.Controllers
{
    public class LoginController : ApiController
    {
        //private static readonly IUserService _userRepository = new UserService(); //In-memory data manipulation
        private readonly IUserService _userRepository = new OnlineShopContext(); //SQL Server (EF) data manipulation

        public LoginController() { }

        public LoginController(IUserService userRepository)
        {
            _userRepository = userRepository;
        }

        public AuthResponse Post([FromBody] User loginRequest)
        {
            return _userRepository.Login(loginRequest);
        }
    }
}