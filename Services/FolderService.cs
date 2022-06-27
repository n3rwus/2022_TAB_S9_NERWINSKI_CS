using AutoMapper;
using WebAlbum.Authorization;
using WebAlbum.Entities;
using WebAlbum.Helpers;
using WebAlbum.Models.Folders;

namespace WebAlbum.Services
{
    public interface IFolderService
    {
        public GetFolderResponse GetFolder(GetFolderRequest request);
        public Folder AddFolder(AddFolderRequest request);
        public Folder DeleteFolder(DeleteFolderRequest request);
        public GetMainFolderResponse GetMainFolder(GetMainFolderRequest request);
        public GetFolderListResponse GetFolderList(GetFoldersListRequest request);
    }
    public class FolderService: IFolderService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtils;

        public FolderService(DataContext context, IMapper mapper, IJwtUtils jwtUtils) 
        {
            _context = context;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        public Folder AddFolder(AddFolderRequest request) 
        {
            var folder = _mapper.Map<Folder>(request);
            folder.AccountId = _jwtUtils.ValidateJwtToken(request.UserToken);
            _context.Folders.Add(folder);
            _context.SaveChanges();
            return folder;
        }

        public Folder DeleteFolder(DeleteFolderRequest request)
        {
            var folder = _context.Folders.FirstOrDefault(x => x.Id == request.FolderId);
            _context.Folders.Remove(folder);
            _context.SaveChanges();

            return folder;
        }

        public GetFolderResponse GetFolder(GetFolderRequest request)
        {
            var folder = _context.Folders.FirstOrDefault(x=>x.Id == request.FolderId);

            var response = _mapper.Map<GetFolderResponse>(folder);

            return response;
        }

        public GetMainFolderResponse GetMainFolder(GetMainFolderRequest request)//TODO
        {
            return null;
        }

        public GetFolderListResponse GetFolderList(GetFoldersListRequest request)
        {   
            var accountId = _jwtUtils.ValidateJwtToken(request.UserToken);
            var folders = _context.Folders.Where(x=>x.AccountId == accountId);

            var response = _mapper.Map<GetFolderListResponse>(folders);//TODO

            return response;
        }
    }
}
