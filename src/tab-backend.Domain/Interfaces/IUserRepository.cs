using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tab_backend.Domain.Entities;
using tab_backend.Domain.DTO;

namespace tab_backend.Domain.Interfaces
{
    public interface IUserRepository
    {
        User LoginRepository(User requestUser);

        User RegisterRepository(UserRegisterDTO requestUser);

        IEnumerable<User> GetAllRepository();

        User GetUserByIdRepository(int id);
    }
}
