using EAuction.WebApp.Models;
using System.Collections.Generic;

namespace EAuction.WebApp.Data
{
    public interface ICategoryDao
    {
        Category GetCategoryById(int id);
        IEnumerable<Category> GetCategories();
    }
}
