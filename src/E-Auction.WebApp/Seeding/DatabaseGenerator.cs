using EAuction.WebApp.Dados.EFCore;
using EAuction.WebApp.Models;
using System;
using System.Collections.Generic;

namespace EAuction.WebApp.Seeding
{
    public static class DatabaseGenerator
    {
        public static void Seed()
        {
            using (var context = new AppDbContext())
            {
                if (context.Database.EnsureCreated())
                {
                    var generator = new AuctionRandomGenerator(new Random());
                    var auctions = new List<Auction>();
                    for (var i = 1; i <= 200; i++)
                    {
                        auctions.Add(generator.NewAuction);
                    }
                    context.Auctions.AddRange(auctions);
                    context.SaveChanges();
                }
            }
        }
    }
}