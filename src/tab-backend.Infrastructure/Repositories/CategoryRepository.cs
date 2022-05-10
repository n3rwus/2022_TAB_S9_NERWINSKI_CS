using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tab_backend.Domain.Entities;
using tab_backend.Domain.Interfaces;
using tab_backend.Infrastructure.Data;

namespace tab_backend.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly TabContext _context;

        public CategoryRepository(TabContext context)
        {
            _context = context;
        }

        public Category AddCategory(Category category)
        {
            _context.Categories.Add(category);

            _context.SaveChanges();

            return category;
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);

            _context.SaveChanges();
        }

        public Category GetCategoryByID(int id)
        {
            var category = _context.Categories.FirstOrDefault(x => x.ID == id);
            return category;
        }

        public Category GetCategoryByName(string name)
        {
            var category = _context.Categories.FirstOrDefault(x => x.Name == name);
            return category;
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);

            _context.SaveChanges();
        }
    }
}
