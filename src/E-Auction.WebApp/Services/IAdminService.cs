using EAuction.WebApp.Models;
using System.Collections.Generic;

namespace EAuction.WebApp.Services
{
    public interface IAdminService
    {
        IEnumerable<Category> GetCategories();
        IEnumerable<Auction> GetAuctions();
        Auction GetAuctionById(int id);
        void InsertAuction(Auction leilao);
        void UpdateAuction(Auction leilao);
        void DeleteAuction(Auction leilao);
        void OpenAuctionById(int id);
        void CloseAuctionFloorById(int id);
    }
}
