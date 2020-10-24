using EAuction.WebApp.Models;
using System.Collections.Generic;

namespace EAuction.WebApp.Services
{
    public interface IAdminService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Auction> GetAuctions();
        Auction GetAuctionById(int id);
        void InsertAuction(Auction auction);
        void UpdateAuction(Auction auction);
        void DeleteAuction(Auction auction);
        void OpenAuctionById(int id);
        void CloseAuctionFloorById(int id);
    }
}
