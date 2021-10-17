using EBO.CodingTask.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace EBO.CodingTask.API.Data
{
    public class UserService : IUserService
    {
        private List<User> userList = new List<User>();
        public UserService()
        {
            userList = new List<User>
            {
                new User{ UserID = 1, Username = "User1", Password = "Password1" },
                new User{ UserID = 2, Username = "User2", Password = "Password2" },
                new User{ UserID = 3, Username = "User3", Password = "Password3" },
                new User{ UserID = 4, Username = "User4", Password = "Password4" },
            };
        }

        public AuthResponse Login(User loginRequest)
        {
            var result = new AuthResponse();
            if (loginRequest == null || string.IsNullOrEmpty(loginRequest.Username) || string.IsNullOrEmpty(loginRequest.Password))
            {
                result.IsSuccessful = false;
                result.Message = Constants.LOGIN_ERROR_EMPTY_CREDENTIALS;
            }
            else
            {
                if (userList.Any(u => u.Username == loginRequest.Username && u.Password == loginRequest.Password))
                {
                    result.IsSuccessful = true;
                    result.UserInfo = userList.Find(u => u.Username == loginRequest.Username && u.Password == loginRequest.Password);
                }
                else
                {
                    result.IsSuccessful = false;
                    result.Message = Constants.LOGIN_ERROR_INVALID_CREDENTIALS;
                }
            }

            return result;
        }
    }
}