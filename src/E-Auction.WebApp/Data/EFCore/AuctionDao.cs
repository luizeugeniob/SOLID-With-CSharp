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

        public IEnumerable<Auction> Get()
            => _context.Auctions.Include(a => a.Category).ToList();

        public Auction Get(int id) 
            => _context.Auctions.First(a => a.Id == id);

        public void Insert(Auction leilao)
        {
            _context.Auctions.Add(leilao);
            _context.SaveChanges();
        }

        public void Update(Auction leilao)
        {
            _context.Auctions.Update(leilao);
            _context.SaveChanges();
        }

        public void Delete(Auction leilao)
        {
            _context.Auctions.Remove(leilao);
            _context.SaveChanges();
        }
    }
}
