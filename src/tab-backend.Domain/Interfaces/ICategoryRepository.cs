using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tab_backend.Domain.Entities;

namespace tab_backend.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        public Category GetCategoryByID(int id);

        public Category GetCategoryByName(string name);

        public Category AddCategory(Category category);

        public void UpdateCategory(Category category);

        public void DeleteCategory(Category category);
    }
}
