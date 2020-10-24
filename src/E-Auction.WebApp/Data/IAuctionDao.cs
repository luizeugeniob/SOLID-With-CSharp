using EAuction.WebApp.Models;
using System.Collections.Generic;

namespace EAuction.WebApp.Data
{
    public interface IAuctionDao
    {        
        IEnumerable<Auction> GetAuctions();
        Auction GetAuctionById(int id);
        void InsertAuction(Auction leilao);
        void UpdateAuction(Auction leilao);
        void DeleteAuction(Auction leilao);
    }
}
