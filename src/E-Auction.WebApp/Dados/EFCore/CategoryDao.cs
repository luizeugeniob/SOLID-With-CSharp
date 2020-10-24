using EAuction.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EAuction.WebApp.Dados.EFCore
{
    public class CategoryDao : ICategoryDao
    {
        AppDbContext _context;

        public CategoryDao(AppDbContext context)
        {
            _context = context;
        }

        public Category GetCategoryById(int id)
        {
            return _context.Categories
                .Include(c => c.Auctions)
                .First(c => c.Id == id);
        }

        public IEnumerable<Category> GetCategories()
            => _context.Categories.Include(a => a.Auctions);
    }
}
