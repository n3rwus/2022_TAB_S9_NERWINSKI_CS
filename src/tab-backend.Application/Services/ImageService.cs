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
        private readonly IMapper _mapper;

        public ImageService(IImageRepository imageRepository, IMapper mapper)
        {
            _imageRepository = imageRepository;
            _mapper = mapper;
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
    }
}
