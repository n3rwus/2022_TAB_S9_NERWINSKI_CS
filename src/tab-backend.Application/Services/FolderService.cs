using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tab_backend.Application.DTO;
using tab_backend.Application.Interfaces;
using tab_backend.Domain.Entities;
using tab_backend.Domain.Interfaces;

namespace tab_backend.Application.Services
{
    public class FolderService : IFolderService
    {
        private readonly IFolderRepository _folderRepository;
        private readonly IMapper _mapper;

        public FolderService(IFolderRepository folderRepository, IMapper mapper)
        {
            _folderRepository = folderRepository;
            _mapper = mapper;
        }

        public FolderDTO AddFolder(FolderDTO folder)
        {
            var folderRep = _mapper.Map<Folder>(folder);

            var addedFolder = _folderRepository.AddFolder(folderRep);

            return _mapper.Map<FolderDTO>(addedFolder);
        }

        public void DeleteFolder(FolderDTO folder)
        {
            var folderRep = _mapper.Map<Folder>(folder);

             _folderRepository.DeleteFolder(folderRep);
        }

        public IEnumerable<FolderDTO> GetAllFolders()
        {
            var folders = _folderRepository.GetAllFolders();

            return _mapper.Map<IEnumerable<FolderDTO>>(folders);
        }

        public FolderDTO GetFolderByID(int id)
        {
            var folder = _folderRepository.GetFolderByID(id);

            return _mapper.Map<FolderDTO>(folder);
        }

        public FolderDTO GetFolderByName(string name)
        {
            var folder = _folderRepository.GetFolderByName(name);

            return _mapper.Map<FolderDTO>(folder);
        }

        public IEnumerable<FolderDTO> GetUserFolders(UserDTO user)
        {
            var userRep = _mapper.Map<User>(user);

            var folders = _folderRepository.GetUserFolders(userRep);

            return _mapper.Map<IEnumerable<FolderDTO>>(folders);
        }

        public void UpdateFolder(FolderDTO folder)
        {
            var folderRep = _mapper.Map<Folder>(folder);

            _folderRepository.UpdateFolder(folderRep);
        }
    }
}
