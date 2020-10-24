using EAuction.WebApp.Data;
using EAuction.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace EAuction.WebApp.Services.Handlers
{
    public class ArchivedAdminService : IAdminService
    {
        private readonly IAdminService _defaultAdminService;

        public ArchivedAdminService(IAuctionDao auctionDao, ICategoryDao categoryDao)
        {
            _defaultAdminService = new DefaultAdminService(auctionDao, categoryDao);
        }

        public IEnumerable<Auction> GetAuctions()
        {
            return _defaultAdminService
                .GetAuctions()
                .Where(a => a.Status != AuctionStatus.Archived);
        }

        public Auction GetAuctionById(int id)
        {
            return _defaultAdminService.GetAuctionById(id);
        }

        public void InsertAuction(Auction auction)
        {
            _defaultAdminService.InsertAuction(auction);
        }

        public void UpdateAuction(Auction auction)
        {
            _defaultAdminService.UpdateAuction(auction);
        }

        public void DeleteAuction(Auction auction)
        {
            if (auction != null && auction.Status != AuctionStatus.Trading)
            {
                auction.Status = AuctionStatus.Archived;
                _defaultAdminService.UpdateAuction(auction);
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return _defaultAdminService.GetCategories();
        }

        public void OpenAuctionById(int id)
        {
            _defaultAdminService.OpenAuctionById(id);
        }

        public void CloseAuctionFloorById(int id)
        {
            _defaultAdminService.CloseAuctionFloorById(id);
        }
    }
}
