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
    public class FolderRepository : IFolderRepository
    {
        private readonly TabContext _context;

        public FolderRepository(TabContext context)
        {
            _context = context;
        }
        public Folder AddFolder(Folder folder)
        {
            _context.Folders.Add(folder);

            _context.SaveChanges();

            return folder;
        }

        public void DeleteFolder(Folder folder)
        {
            _context.Folders.Remove(folder);

            _context.SaveChanges();
        }

        public IEnumerable<Folder> GetAllFolders()
        {
            return _context.Folders;
        }

        public Folder GetFolderByID(int id)
        {
            return _context.Folders.FirstOrDefault(x => x.ID == id);
        }

        public Folder GetFolderByName(string name)
        {
            return _context.Folders.FirstOrDefault(x => x.Name == name);
        }

        public IEnumerable<Folder> GetUserFolders(User user)
        {
            return _context.Folders.Where(x => x.MainFolder.User == user);
        }

        public void UpdateFolder(Folder folder)
        {
            _context.Folders.Update(folder);

            _context.SaveChanges();
        }
    }
}
