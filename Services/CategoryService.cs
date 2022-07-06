using AutoMapper;
using WebAlbum.Authorization;
using WebAlbum.Entities;
using WebAlbum.Helpers;
using WebAlbum.Models.Categories;

namespace WebAlbum.Services
{
    public interface ICategoryService
    {
        public Category AddTag(AddCategoryRequest request);
        public GetCategoryResponse GetTags(GetCategoryRequest request);
        public Category DeleteTag(DeleteCategoryRequest request);
        public Category GetCategoryByName(string name);
    }

    public class CategoryService: ICategoryService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        private readonly IJwtUtils _jwtUtils;

        public CategoryService(DataContext context, IMapper mapper, IJwtUtils jwtUtils)
        {
            _context = context;
            _mapper = mapper;
            _jwtUtils = jwtUtils;
        }

        public Category AddTag(AddCategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            category.AccountId = _jwtUtils.ValidateJwtToken(request.UserToken);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public GetCategoryResponse GetTags(GetCategoryRequest request)
        {
            
             var accountId = _jwtUtils.ValidateJwtToken(request.UserToken);
             var categories = _context.Categories.Where(x => x.AccountId == accountId);

             var response = _mapper.Map<GetCategoryResponse>(categories);

             return response;
        }

        public Category DeleteTag(DeleteCategoryRequest request)
        {
            var tag = _context.Categories.FirstOrDefault(x => x.Id == request.Id);
            _context.Categories.Remove(tag);
            _context.SaveChanges();

            return tag;
        }

        public Category GetCategoryByName(string name)
        {
            return _context.Categories.FirstOrDefault(x => x.CategoryName == name);
        }
    }
}
