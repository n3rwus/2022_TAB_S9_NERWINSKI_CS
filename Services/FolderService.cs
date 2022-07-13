using WebAlbum.Models.Folders.Respons;
using WebAlbum.Models.Folders.Request;
using WebAlbum.Helpers;
using AutoMapper;
using WebAlbum.Authorization;

namespace WebAlbum.Services
{
    public interface IFolderService
    {
        IEnumerable<FolderResponse> GetAll();
        FolderResponse GetById(int id);
        FolderResponse Create(CreateFolderRequest model);
        FolderResponse Update(int id, UpdateFolderRequest model);
        void Delete(int id);
    }
    public class FolderService : IFolderService
    {
        private readonly DataContext _context;
        private readonly IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public FolderService(DataContext context, IJwtUtils jwtUtils, IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public FolderResponse Create(CreateFolderRequest model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FolderResponse> GetAll()
        {
            throw new NotImplementedException();
        }

        public FolderResponse GetById(int id)
        {
            throw new NotImplementedException();
        }

        public FolderResponse Update(int id, UpdateFolderRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
