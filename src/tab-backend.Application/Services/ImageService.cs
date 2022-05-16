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
    public class ImageService : IImageService
    {
        private readonly IImageRepository _imageRepository;
        private readonly ICategoryService _categoryService;
        private readonly IFolderService _folderService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ImageService(IImageRepository imageRepository, ICategoryService categoryService, IFolderService folderService, IUserService _userService, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _categoryService = categoryService;
            _folderService = folderService;
            _mapper = mapper;
        }

        public ImageDTO AddImage(ImageAddDTO image)
        {

            List<CategoryDTO> categories = new List<CategoryDTO>();
    
            foreach (var categoryName in image.CategoriesName)
            {
                categories.Add(_categoryService.GetCategoryByName(categoryName));
            }

            var imageDto = _mapper.Map<ImageDTO>(image);

            imageDto.Categories = categories;
            imageDto.User = _userService.GetUserByID(image.UserID);
            var folder = _folderService.GetFolderByID(image.FolderID);
            imageDto.Folders = new List<FolderDTO>() { folder };

            var imageRep = _mapper.Map<Image>(image);

            var addedImage = _imageRepository.AddImage(imageRep);

            return _mapper.Map<ImageDTO>(addedImage);
        }

        public void DeleteImage(ImageDTO image)
        {
            var imageRep = _mapper.Map<Image>(image);

            _imageRepository.DeleteImage(imageRep);
        }

        public IEnumerable<ImageDTO> GetAllImage()
        {
            var images = _imageRepository.GetAllImage();

            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }

        public IEnumerable<ImageDTO> GetFolderImage(FolderDTO folder)
        {
            var folderRep = _mapper.Map<Folder>(folder);

            var images = _imageRepository.GetFolderImage(folderRep);

            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }

        public IEnumerable<ImageDTO> GetImageByCategory(CategoryDTO category)
        {
            if (category == null) throw new ArgumentNullException();

            var categoryRep = _mapper.Map<Category>(category);
            var images = _imageRepository.GetImageByCategory(categoryRep);

            return _mapper.Map <IEnumerable<ImageDTO>>(images);
        }

        public IEnumerable<ImageDTO> GetImageByDate(DateTime date)
        {
            var images = _imageRepository.GetImageByDate(date);

            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }

        public IEnumerable<ImageDTO> GetImageByFormat(string format)
        {
            var images = _imageRepository.GetImageByFormat(format);

            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }

        public ImageDTO GetImageByID(int id)
        {
            var images = _imageRepository.GetImageByID(id);

            return _mapper.Map<ImageDTO>(images);
        }

        public IEnumerable<ImageDTO> GetImageBySize(string size)
        {
            var images = _imageRepository.GetImageBySize(size);

            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }

        public IEnumerable<ImageDTO> GetUserImage(UserDTO user)
        {
            var userRep = _mapper.Map<User>(user);

            var images = _imageRepository.GetUserImage(userRep);

            return _mapper.Map<IEnumerable<ImageDTO>>(images);
        }

        public void UpdateImage(ImageDTO image)
        {
            var imageRep = _mapper.Map<Image>(image);

            _imageRepository.UpdateImage(imageRep);
        }
    }
}
