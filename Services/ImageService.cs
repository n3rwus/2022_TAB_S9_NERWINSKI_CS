using AutoMapper;
using WebAlbum.Authorization;
using WebAlbum.Entities;
using WebAlbum.Helpers;
using WebAlbum.Models.Images.Request;
using WebAlbum.Models.Images.Response;

namespace WebAlbum.Services
{

    public interface IImageService
    {
        IEnumerable<ImageResponse> GetAll();
        ImageResponse GetById(int id);
        void Create(CreateImageRequest model);
        ImageResponse Update(int id, UpdateImageRequest model);
        void Delete(int id);
    }
    public class ImageService : IImageService
    {
        private readonly DataContext _context;
        private readonly IJwtUtils _jwtUtils;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ImageService(
            DataContext context, IJwtUtils jwtUtils, IMapper mapper, ICategoryService categoryService)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public void Create(CreateImageRequest model)
        {      
            var image = _mapper.Map<Image>(model);
            image.ImageDateOfCreate = DateTime.Now;
            _context.Images.Add(image);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var image = getImage(id);
            _context.Images.Remove(image);
            _context.SaveChanges();
        }

        public IEnumerable<ImageResponse> GetAll()
        {
            var images = _context.Images;
            return _mapper.Map<IList<ImageResponse>>(images);
        }

        public ImageResponse GetById(int id)
        {
            var image = getImage(id);
            return _mapper.Map<ImageResponse>(image);
        }

        public ImageResponse Update(int id, UpdateImageRequest model)
        {
            var image = getImage(id);
            if (image == null) throw new KeyNotFoundException("Image not found");
            _mapper.Map(model, image);
            _context.Images.Update(image);
            return _mapper.Map<ImageResponse>(image);
        }

        private Image getImage(int id)
        {
            var image = _context.Images.Find(id);
            if (image == null) throw new KeyNotFoundException("Image not found");
            return image;
        }
    }
}
