using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tab_backend.Domain.Entities;
using tab_backend.Domain.Interfaces;
using tab_backend.Infrastructure.Data;

namespace tab_backend.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static readonly ISet<User> _users = new HashSet<User>()
        {
            new User(1, "123456789", "admin@test.com", "admin", new DateTime(2022,1,1)),
            new User(2, "987654321", "user@test.com", "user", new DateTime(2022,2,2))
        };
        private readonly TabContext _context;

        public UserRepository(TabContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetUserByID(int id)
        {
            return _users.FirstOrDefault(x => x.ID == id);
        }

        public User Login(User requestUser)
        {
            var user = _users.FirstOrDefault(x => x.Email == requestUser.Email && x.Password == requestUser.Password);

            // return null if user not found
            if (user == null) return null;

            return user;
        }

        public User Register(User user)
        {
            user.ID = _users.Count() + 1;
            user.RegisterDate = DateTime.UtcNow;
            _users.Add(user);

            return user;
        }
    }
}
