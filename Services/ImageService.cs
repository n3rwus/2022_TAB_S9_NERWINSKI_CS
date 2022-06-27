using AutoMapper;
using WebAlbum.Authorization;
using WebAlbum.Entities;
using WebAlbum.Helpers;
using WebAlbum.Models.Images;

namespace WebAlbum.Services
{
    public interface IImageService
    {
        public Image AddImages(AddImageRequest request);
        public Image DeleteImage(DeleteImageRequest request);
        public GetImageResponse GetImage(GetImageRequest request);
        public Image EditImage(EditImageRequest request);
    }

    public class ImageService : IImageService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly ICategoryService _categoryService;
        private readonly IJwtUtils _jwtUtils;

        public ImageService(DataContext context, IMapper mapper, ICategoryService categoryService, IJwtUtils jwtUtils)
        {
            _context = context;
            _mapper = mapper;
            _categoryService = categoryService;
            _jwtUtils = jwtUtils;
        }

        public Image AddImages(AddImageRequest request)
        {
            Image image = null;

            var tags = request.Tags;

            List<Category> categories = new List<Category>();

            foreach (var item in tags)
            {
                var tag = _categoryService.GetCategoryByName(item);
                categories.Add(tag);
            }

            foreach (var item in request.Images)
            {
                image = _mapper.Map<Image>(request);
                image.AccountId = _jwtUtils.ValidateJwtToken(request.UserToken);
                image.ImageData = item;
                _context.Images.Add(image);
                _context.SaveChanges();

                foreach (var tag in categories)
                {
                    ImageCategory imageCategory = new ImageCategory(image.Id, tag.Id, tag, image);
                    _context.ImageCategories.Add(imageCategory); 
                }

                _context.SaveChanges();
            }

            return image ;
        }

        public Image DeleteImage(DeleteImageRequest request)
        {
            var image = _context.Images.FirstOrDefault(x => x.Id == request.Id);
            _context.Images.Remove(image);
            _context.SaveChanges();

            return image;
        }

        public GetImageResponse GetImage(GetImageRequest request)
        {
            var image = _context.Images.FirstOrDefault(x => x.Id == request.Id);

            var response = _mapper.Map<GetImageResponse>(image);

            return response;
        }

        public Image EditImage(EditImageRequest request)//TODO
        {
            var image = _mapper.Map<Image>(request);

            _context.Images.Update(image);
            _context.SaveChanges();

            return image;
        }
    }
}
