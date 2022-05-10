using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tab_backend.Application.DTO;

namespace tab_backend.Application.Interfaces
{
    public interface ICategoryService
    {
        public CategoryDTO GetCategoryByID(int id);

        public CategoryDTO GetCategoryByName(string name);

        public CategoryDTO AddCategory(CategoryDTO category);

        public void UpdateCategory(CategoryDTO category);

        public void DeleteCategory(CategoryDTO category);
    }
}
