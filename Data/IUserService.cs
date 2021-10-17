using EBO.CodingTask.API.Models;

namespace EBO.CodingTask.API.Data
{
    public interface IUserService
    {
        AuthResponse Login(User loginRequest);
    }
}
