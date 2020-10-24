using EAuction.WebApp.Data;
using EAuction.WebApp.Models;
using System;
using System.Collections.Generic;

namespace EAuction.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {
        private readonly IAuctionDao _auctionDao;
        private readonly ICategoryDao _categoryDao;

        public DefaultAdminService(IAuctionDao auctionDao, ICategoryDao categoryDao)
        {
            _auctionDao = auctionDao;
            _categoryDao = categoryDao;
        }

        public IEnumerable<Auction> GetAuctions()
        {
            return _auctionDao.Get();
        }

        public Auction GetAuctionById(int id)
        {
            return _auctionDao.Get(id);
        }

        public void InsertAuction(Auction auction)
        {
            _auctionDao.Insert(auction);
        }

        public void UpdateAuction(Auction auction)
        {
            _auctionDao.Update(auction);
        }

        public void DeleteAuction(Auction auction)
        {
            if (auction != null && auction.Status != AuctionStatus.Trading)
            {
                _auctionDao.Delete(auction);
            }
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryDao.Get();
        }

        public void OpenAuctionById(int id)
        {
            var auction = _auctionDao.Get(id);

            if (auction != null && auction.Status == AuctionStatus.Trading)
            {
                auction.Status = AuctionStatus.Trading;
                auction.DateOpen = DateTime.Now;
                _auctionDao.Update(auction);
            }
        }

        public void CloseAuctionFloorById(int id)
        {
            var auction = _auctionDao.Get(id);

            if (auction != null && auction.Status == AuctionStatus.Trading)
            {
                auction.Status = AuctionStatus.Close;
                auction.DateClose = DateTime.Now;
                _auctionDao.Update(auction);
            }
        }
    }
}
