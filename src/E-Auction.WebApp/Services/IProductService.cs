using EAuction.WebApp.Models;
using System.Collections.Generic;

namespace EAuction.WebApp.Services
{
    public interface IProductService
    {
        IEnumerable<Auction> GetOpenAuctionsByTerm(string term);
        IEnumerable<CategoryWithAuctionInfo> GetCategoriesWithTotalAuctionsInTrading();
        Category GetCategoryWithAuctionsInTradingById(int id);
    }
}
