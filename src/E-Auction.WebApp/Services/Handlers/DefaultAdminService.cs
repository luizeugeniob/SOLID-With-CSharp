using EAuction.WebApp.Dados;
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
            return _auctionDao.GetAuctions();
        }

        public Auction GetAuctionById(int id)
        {
            return _auctionDao.GetAuctionById(id);
        }

        public void InsertAuction(Auction leilao)
        {
            _auctionDao.InsertAuction(leilao);
        }

        public void UpdateAuction(Auction leilao)
        {
            _auctionDao.UpdateAuction(leilao);
        }

        public void DeleteAuction(Auction leilao)
        {
            _auctionDao.DeleteAuction(leilao);
        }

        public IEnumerable<Category> GetCategories()
        {
            return _categoryDao.GetCategories();
        }

        public void OpenAuctionById(int id)
        {
            var auction = _auctionDao.GetAuctionById(id);

            if (auction != null && auction.Status == AuctionStatus.Trading)
            {
                auction.Status = AuctionStatus.Trading;
                auction.DateOpen = DateTime.Now;
                _auctionDao.UpdateAuction(auction);
            }
        }

        public void CloseAuctionFloorById(int id)
        {
            var auction = _auctionDao.GetAuctionById(id);

            if (auction != null && auction.Status == AuctionStatus.Trading)
            {
                auction.Status = AuctionStatus.Close;
                auction.DateClose = DateTime.Now;
                _auctionDao.UpdateAuction(auction);
            }
        }
    }
}
