using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_backend.Application.DTO
{
    public class UserResponseDTO
    {
        public int ID { get; set; }

        public string FirstName { get; set; }

        public string Email { get; set; }

        public DateTime RegisterDate { get; set; }

        public string Token { get; set; }

    }
}
