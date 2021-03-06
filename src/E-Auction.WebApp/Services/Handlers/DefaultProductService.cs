﻿using EAuction.WebApp.Data;
using EAuction.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EAuction.WebApp.Services.Handlers
{
    public class DefaultProductService : IProductService
    {
        private IAuctionDao _auctionDao;
        private ICategoryDao _categoryDao;

        public DefaultProductService(IAuctionDao auctionDao, ICategoryDao categoryDao)
        {
            _auctionDao = auctionDao;
            _categoryDao = categoryDao;
        }

        public Category GetCategoryWithAuctionsInTradingById(int id)
        {
            return _categoryDao.Get(id);
        }

        public IEnumerable<CategoryWithAuctionInfo> GetCategoriesWithTotalAuctionsInTrading()
        {
            return _categoryDao
                .Get()
                .Select(c => new CategoryWithAuctionInfo
                {
                    Id = c.Id,
                    Name = c.Name,
                    UrlImage = c.UrlImage,
                    InDraft = c.Auctions.Where(l => l.Status == AuctionStatus.Draft).Count(),
                    InTrading = c.Auctions.Where(l => l.Status == AuctionStatus.Trading).Count(),
                    Closed = c.Auctions.Where(l => l.Status == AuctionStatus.Close).Count(),
                });
        }

        public IEnumerable<Auction> GetOpenAuctionsByTerm(string term)
        {
            var normalizedTerm = term.ToUpper();
            return _auctionDao
                .Get()
                .Where(c =>
                    c.Title.ToUpper().Contains(normalizedTerm) ||
                    c.Description.ToUpper().Contains(normalizedTerm) ||
                    c.Category.Name.ToUpper().Contains(normalizedTerm));
        }
    }
}
