using EAuction.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EAuction.WebApp.Data.EFCore
{
    public class AuctionDao : IAuctionDao
    {
        AppDbContext _context;

        public AuctionDao()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Auction> GetAuctions()
        {
            return _context.Auctions
                .Include(l => l.Category)
                .ToList();
        }

        public Auction GetAuctionById(int id) 
            => _context.Auctions.First(l => l.Id == id);

        public void InsertAuction(Auction leilao)
        {
            _context.Auctions.Add(leilao);
            _context.SaveChanges();
        }

        public void UpdateAuction(Auction leilao)
        {
            _context.Auctions.Update(leilao);
            _context.SaveChanges();
        }

        public void DeleteAuction(Auction leilao)
        {
            _context.Auctions.Remove(leilao);
            _context.SaveChanges();
        }
    }
}
