using AutoMapper;
using WebAlbum.Entities;
using WebAlbum.Models.Accounts;
using WebAlbum.Models.Accounts.Request;
using WebAlbum.Models.Accounts.Response;
using WebAlbum.Models.Categories;
using WebAlbum.Models.Folders;

namespace WebAlbum.Helpers
{
    public class AutoMapperProfile : Profile
    {
        // mappings between model and entity objects
        public AutoMapperProfile()
        {
            CreateMap<Account, AccountResponse>();

            CreateMap<Account, AuthenticateResponse>();
            
            CreateMap<RegisterRequest, Account>();

            CreateMap<CreateRequest, Account>();

            CreateMap<UpdateRequest, Account>()
                .ForAllMembers(x => x.Condition(
                    (src, dest, prop) =>
                    {
                    // ignore null & empty string properties
                        if (prop == null) return false;
                        if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    // ignore null role
                        if (x.DestinationMember.Name == "Role" && src.Role == null) return false;

                        return true;
                    }
                ));

            CreateMap<AddCategoryRequest, Category>();

            CreateMap<Category, CategoryResponse>();

            CreateMap<AddFolderRequest, Folder>();

            CreateMap<Folder, GetFolderResponse>();

            CreateMap<Folder, GetMainFoldersResponse>();

        }
    }
}
