using System.Collections.Generic;

namespace EAuction.WebApp.Models
{
    public class Category
    {
        public Category()
        {
            Auctions = new List<Auction>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string UrlImage { get; set; }
        public IList<Auction> Auctions { get; set; }
    }

    public class CategoryWithAuctionInfo : Category
    {
        public int InDraft { get; set; }
        public int InTrading { get; set; }
        public int Closed { get; set; }
    }
}