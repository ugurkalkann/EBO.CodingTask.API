using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EBO.CodingTask.API.Models
{
    public class AuthResponse
    {
        public bool IsSuccessful { get; set; }
        public string Message { get; set; }
        public User UserInfo { get; set; }

        public AuthResponse()
        {
            UserInfo = new User();
        }
    }
}