using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_backend.Application.DTO
{
    public class UserRegisterDTO : UserLoginDTO
    {
        public string FirstName { get; set; }
    }
}
