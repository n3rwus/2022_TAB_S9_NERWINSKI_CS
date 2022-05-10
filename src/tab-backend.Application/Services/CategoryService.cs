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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public CategoryDTO AddCategory(CategoryDTO category)
        {
            var categoryRep = _mapper.Map<Category>(category);

            var addedCategory = _categoryRepository.AddCategory(categoryRep);

            return _mapper.Map<CategoryDTO>(addedCategory);
        }

        public void DeleteCategory(CategoryDTO category)
        {
            var categoryRep = _mapper.Map<Category>(category);

             _categoryRepository.DeleteCategory(categoryRep);
        }

        public CategoryDTO GetCategoryByID(int id)
        {
            var addedCategory = _categoryRepository.GetCategoryByID(id);

            return _mapper.Map<CategoryDTO>(addedCategory);
        }

        public CategoryDTO GetCategoryByName(string name)
        {
            var addedCategory = _categoryRepository.GetCategoryByName(name);

            return _mapper.Map<CategoryDTO>(addedCategory);
        }

        public void UpdateCategory(CategoryDTO category)
        {
            var categoryRep = _mapper.Map<Category>(category);

            _categoryRepository.UpdateCategory(categoryRep);
        }
    }
}
