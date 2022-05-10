using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tab_backend.Domain.Entities;

namespace tab_backend.Domain.Interfaces
{
    public interface IUserRepository
    {
        User Login(User requestUser);

        User Register(User requestUser);

        IEnumerable<User> GetAll();

        User GetUserByID(int id);
    }
}
