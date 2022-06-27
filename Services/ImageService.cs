using WebAlbum.Models.Images.Request;
using WebAlbum.Models.Images.Response;

namespace WebAlbum.Services
{
    public interface IImageService
    {
        IEnumerable<ImageResponse> GetAll();
        ImageResponse GetById(int id);
        ImageResponse Create(CreateImageRequest model);
        void Delete(int id);
    }
    public class ImageService : IImageService
    {
        public ImageResponse Create(CreateImageRequest model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImageResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public ImageResponse GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
