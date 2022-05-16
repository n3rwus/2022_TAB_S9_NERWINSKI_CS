using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tab_backend.Application.DTO;
using tab_backend.Domain.Entities;

namespace tab_backend.Application.Mappings
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
            => new MapperConfiguration(cfg => {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserRequestDTO, User>();
                cfg.CreateMap<User, UserResponseDTO>();
                cfg.CreateMap<Image, ImageDTO>();
                cfg.CreateMap<Category, CategoryDTO>();
                cfg.CreateMap<Folder, FolderDTO>();
                cfg.CreateMap<ImageDTO, Image>();
                cfg.CreateMap<CategoryDTO, Category>();
                cfg.CreateMap<FolderDTO, Folder>();
                cfg.CreateMap<ImageAddDTO, ImageDTO>();
            }).CreateMapper();
    }
}
