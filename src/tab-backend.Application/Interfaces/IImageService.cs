using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tab_backend.Application.DTO;

namespace tab_backend.Application.Interfaces
{
    public interface IImageService
    {
        public ImageDTO GetImageByID(int id);

        public IEnumerable<ImageDTO> GetUserImage(UserDTO user);

        public IEnumerable<ImageDTO> GetFolderImage(FolderDTO folder);

        public IEnumerable<ImageDTO> GetImageByCategory(CategoryDTO category);

        public IEnumerable<ImageDTO> GetImageBySize(string size);

        public IEnumerable<ImageDTO> GetImageByFormat(string format);

        public IEnumerable<ImageDTO> GetImageByDate(DateTime date);

        public ImageDTO AddImage(ImageAddDTO image);

        public void UpdateImage(ImageDTO image);

        public void DeleteImage(ImageDTO image);

        public IEnumerable<ImageDTO> GetAllImage();
    }
}
