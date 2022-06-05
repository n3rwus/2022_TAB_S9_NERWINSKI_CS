using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tab_backend.Application.DTO;

namespace tab_backend.Application.Interfaces
{
    public interface IUserService
    {
        Token LoginService(UserLoginDTO userRequestDTO);

        Token RegisterService(UserRegisterDTO userRequestDTO);

        IEnumerable<UserDTO> GetAllService();

        UserDTO GetUserByIdService(int id);
    }
}
