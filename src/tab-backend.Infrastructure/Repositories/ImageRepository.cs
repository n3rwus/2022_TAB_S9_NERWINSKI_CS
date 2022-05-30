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

        public Image AddImage(Image image)
        {
            _context.Images.Add(image);

            _context.SaveChanges();

            return image;
        }

        public void DeleteImage(Image image)
        {
            _context.Images.Remove(image);

            _context.SaveChanges();
        }

        public IEnumerable<Image> GetAllImage()
        {
            return _context.Images;
        }

        public IEnumerable<Image> GetFolderImage(Folder folder)
        {
            return _context.Images.Where(x => x.ImageFolder.Any(f => f.FolderID == folder.ID) == true);
        }

        public IEnumerable<Image> GetImageByCategory(Category category)
        {
            return _context.Images.Where(x => x.ImageCategory.Any(c=>c.CategoryID==category.ID) == true);
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

        public void UpdateImage(Image image)
        {
            _context.Images.Update(image);

            _context.SaveChanges();
        }
    }
}
