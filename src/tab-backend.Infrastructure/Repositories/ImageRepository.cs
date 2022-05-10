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
    public class ImageRepository : IImageRepository
    {
        private readonly TabContext _context;

        public ImageRepository(TabContext context)
        {
            _context = context;
        }

        public IEnumerable<Image> GetFolderImage(Folder folder)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Image> GetImageByCategory(Category category)
        {
            //return _context.Images.Where(x => x.Categories.FirstOrDefault(c=>c.Name==category.Name) == category);
            throw new NotImplementedException();
        }

        public IEnumerable<Image> GetImageByDate(DateTime date)
        {
            return _context.Images.Where(x => x.DateOfCreate == date);
        }

        public IEnumerable<Image> GetImageByFormat(string format)
        {
            return _context.Images.Where(x => x.Format == format);
        }

        public Image GetImageByID(int id)
        {
           return _context.Images.FirstOrDefault(x => x.ID == id);
        }

        public IEnumerable<Image> GetImageBySize(string size)
        {
            return _context.Images.Where(x => x.Size == size);
        }

        public IEnumerable<Image> GetUserImage(User user)
        {
            return _context.Images.Where(x => x.User == user);
        }
    }
}
