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
        UserResponseDTO Login(UserRequestDTO userRequestDTO);

        UserResponseDTO Register(UserRequestDTO userRequestDTO);

        IEnumerable<UserDTO> GetAll();

        UserDTO GetUserByID(int id);
    }
}
