using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tab_backend.Application.DTO;

namespace tab_backend.Application.Interfaces
{
    public interface IFolderService
    {
        public FolderDTO GetFolderByID(int id);

        public IEnumerable<FolderDTO> GetAllFolders();

        public FolderDTO GetFolderByName(string name);

        public FolderDTO AddFolder(FolderDTO folder);

        public void UpdateFolder(FolderDTO folder);

        public void DeleteFolder(FolderDTO folder);

        public IEnumerable<FolderDTO> GetUserFolders(UserDTO user);
    }
}
