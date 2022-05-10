using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_backend.Domain.Entities
{
    public class User
    {
        public User()
        {

        }

        public User(int id, string phoneNumber, string email, string password, DateTime registerDate)
        {
            ID = id;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            RegisterDate = registerDate;
        }

        public int ID { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
