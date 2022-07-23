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
        public IEnumerable<GetMainFoldersResponse> GetMainFolder(GetMainFoldersRequest request);
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

            // WHY ACCOUNT ID IS OPTIONAL ??? 
            if (folder.AccountId == null)
                return null;

            _context.Folders.Add(folder);
            _context.SaveChanges();
            return folder;
        }

        public Folder DeleteFolder(DeleteFolderRequest request)
        {            
            var folder = _context.Folders.FirstOrDefault(x => x.Id == request.FolderId);
            if (folder != null)
            {
                var nestedFolders = _context.Folders.Where(x => x.ParentFolderId == request.FolderId).ToList();
                DeleteNestedFolders(nestedFolders);
                _context.Folders.Remove(folder);
                _context.SaveChanges();
            }

            return folder;
        }

        public GetFolderResponse GetFolder(GetFolderRequest request)
        {
            var accountId = _jwtUtils.ValidateJwtToken(request.UserToken);

            var folder = _context.Folders.FirstOrDefault(x=>x.Id == request.FolderId);

            if (folder != null)
            {
                folder.InverseParentFolder = _context.Folders.Where(x => x.AccountId == accountId && x.ParentFolderId == request.FolderId).ToList();
                folder.Images = _context.Images.Where(x => x.AccountId == accountId && x.FolderId == request.FolderId).ToList();
            }

            var response = _mapper.Map<GetFolderResponse>(folder);

            return response;
        }

        public IEnumerable<GetMainFoldersResponse> GetMainFolder(GetMainFoldersRequest request)//TODO
        {
            var accountId = _jwtUtils.ValidateJwtToken(request.UserToken);
            var folders = _context.Folders.Where(x => x.AccountId == accountId && x.ParentFolder == null);
            var response = _mapper.Map<IList<GetMainFoldersResponse>>(folders);

            return response;
        }

        public GetFolderListResponse GetFolderList(GetFoldersListRequest request)
        {   
            var accountId = _jwtUtils.ValidateJwtToken(request.UserToken);
            var folders = _context.Folders.Where(x=>x.AccountId == accountId);

            var response = _mapper.Map<GetFolderListResponse>(folders);//TODO

            return response;
        }

        private void DeleteNestedFolders(IEnumerable<Folder> nestedFolders)
        {
            foreach (var nestedFolder in nestedFolders)
            {
                var folders = _context.Folders.Where(x => x.ParentFolderId == nestedFolder.Id).ToList();
                if (folders.Count != 0)
                {
                    DeleteNestedFolders(folders);
                }
                _context.Folders.Remove(nestedFolder);
                _context.SaveChanges();
            }
        }
    }
}
