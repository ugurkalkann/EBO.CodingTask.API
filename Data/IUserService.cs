using EBO.CodingTask.API.Models;

namespace EBO.CodingTask.API.Data
{
    interface IUserService
    {
        AuthResponse Login(User loginRequest);
    }
}
