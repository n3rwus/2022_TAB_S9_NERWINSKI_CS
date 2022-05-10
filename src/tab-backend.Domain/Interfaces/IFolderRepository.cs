using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tab_backend.Domain.Entities;

namespace tab_backend.Domain.Interfaces
{
    public interface IFolderRepository
    {
        public Folder GetFolderByID(int id);

        public IEnumerable<Folder> GetAllFolders();

        public Folder GetFolderByName(string name);

        public Folder AddFolder(Folder folder);

        public void UpdateFolder(Folder folder);

        public void DeleteFolder(Folder folder);

        public IEnumerable<Folder> GetUserFolders(User user);
    }
}
