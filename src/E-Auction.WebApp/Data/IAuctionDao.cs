using EAuction.WebApp.Models;

namespace EAuction.WebApp.Data
{
    public interface IAuctionDao : ICommand<Auction>, IQuery<Auction> { }
}
