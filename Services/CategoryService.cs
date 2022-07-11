using AutoMapper;
using WebAlbum.Authorization;
using WebAlbum.Entities;
using WebAlbum.Helpers;
using WebAlbum.Models.Categores.Request;
using WebAlbum.Models.Categores.Response;

namespace WebAlbum.Services
{
    public interface ICategoryService
    {
        IEnumerable<CategoryResponse> GetAll();
        CategoryResponse GetById(int id);
        CategoryResponse Create(CreateCategoryRequest model);
        CategoryResponse Update(int id, UpdateCategoryRequest model);
        void Delete(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _context;
        private readonly IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;

        public CategoryService(DataContext context, IJwtUtils jwtUtils, IMapper mapper)
        {
            _context = context;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public CategoryResponse Create(CreateCategoryRequest model)
        {
            var category = _mapper.Map<Category>(model);
            _context.Categories.Add(category);
            _context.SaveChanges();
            return _mapper.Map<CategoryResponse>(category);
        }

        public void Delete(int id)
        {
            var category = getCategory(id);
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }

        public IEnumerable<CategoryResponse> GetAll()
        {
            var categories = _context.Categories;
            return _mapper.Map<IList<CategoryResponse>>(categories);
        }

        public CategoryResponse GetById(int id)
        {
            var category = getCategory(id);
            return _mapper.Map<CategoryResponse>(category);
        }

        public CategoryResponse Update(int id, UpdateCategoryRequest model)
        {
            var category = getCategory(id);
            if (category == null) throw new KeyNotFoundException("Category not found");
            _mapper.Map(model, category);
            _context.Categories.Update(category);
            return _mapper.Map<CategoryResponse>(category);
        }

        private Category getCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) throw new KeyNotFoundException("Category not found");
            return category;
        }
    }
}
