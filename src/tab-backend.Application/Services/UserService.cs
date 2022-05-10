using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using tab_backend.Application.DTO;
using tab_backend.Application.Interfaces;
using tab_backend.Domain.Entities;
using tab_backend.Domain.Interfaces;

namespace tab_backend.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var users = _userRepository.GetAll();

            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }

        public UserDTO GetUserByID(int id)
        {
            var user = _userRepository.GetUserByID(id);

            return _mapper.Map<UserDTO>(user);
        }

        public UserResponseDTO Login(UserRequestDTO userRequestDTO)
        {
            var userLogin = _mapper.Map<User>(userRequestDTO);

            var user = _userRepository.Login(userLogin);

            if (user == null) return null;

            var userRegister = _mapper.Map<UserResponseDTO>(user);

            userRegister.Token = GenerateJwtToken(user);
            return userRegister;
        }

        public UserResponseDTO Register(UserRequestDTO userRequestDTO)
        {
            var newUser = _mapper.Map<User>(userRequestDTO);
            var user = _userRepository.Register(newUser);

            if (user == null) return null;

            var userRegister = _mapper.Map<UserResponseDTO>(user);

            return userRegister;
        }

        private string GenerateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authentication");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.ID.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
