using EAuction.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EAuction.WebApp.Data.EFCore
{
    public class CategoryDao : ICategoryDao
    {
        AppDbContext _context;

        public CategoryDao(AppDbContext context)
        {
            _context = context;
        }

        public Category Get(int id)
        {
            return _context.Categories
                .Include(c => c.Auctions)
                .First(c => c.Id == id);
        }

        public IEnumerable<Category> Get()
            => _context.Categories.Include(a => a.Auctions);
    }
}
