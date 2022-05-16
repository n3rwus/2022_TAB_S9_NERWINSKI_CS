using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tab_backend.Domain.Entities;

namespace tab_backend.Domain.Interfaces
{
    public interface IImageRepository
    {
        public Image GetImageByID(int id);

        public IEnumerable<Image> GetUserImage(User user);

        public IEnumerable<Image> GetFolderImage(Folder folder);

        public IEnumerable<Image> GetImageByCategory(Category category);

        public IEnumerable<Image> GetImageBySize(string size);

        public IEnumerable<Image> GetImageByFormat(string format);

        public IEnumerable<Image> GetImageByDate(DateTime date);

        public Image AddImage(Image image);

        public void UpdateImage(Image image);

        public void DeleteImage(Image image);

        public IEnumerable<Image> GetAllImage();
    }
}
