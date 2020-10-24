using System;
using EAuction.WebApp.Models;

namespace EAuction.WebApp.Seeding
{
    public class AuctionRandomGenerator
    {
        Random random;
        Category[] categories = new Category[6]
        {
            new Category() { Name = "Diversão e Jogos", UrlImage = "images/jogos.png" },
            new Category() { Name = "Carros Antigos", UrlImage = "images/carros.png" },
            new Category() { Name = "Obras de Arte", UrlImage = "images/artes.png" },
            new Category() { Name = "Imóveis", UrlImage = "images/imoveis.png" },
            new Category() { Name = "Eletrônicos", UrlImage = "images/technology.png" },
            new Category() { Name = "Itens de Colecionador", UrlImage = "images/colecionador.png" },
        };

        public AuctionRandomGenerator(Random random)
        {
            this.random = random;
        }

        private Category AnyCategory()
        {
            var randomIndex = random.Next(0, 5);
            return categories[randomIndex];
        }

        private DateTime RandomDate()
        {
            int randomDays = random.Next(1, 100);
            return DateTime.Now.AddDays(-randomDays);
        }

        public Auction NewAuction
        {
            get
            {
                var auction = new Auction();
                // auction.Id = random.Next(); será definido no loop de geração
                auction.Category = AnyCategory();
                auction.Title = $"{auction.Category.Name} - Lote nº {random.Next(500)}";
                auction.Description = $"{auction.Title}. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut consequat semper viverra nam libero justo laoreet. Ut placerat orci nulla pellentesque dignissim enim sit amet. Cras semper auctor neque vitae. Eu lobortis elementum nibh tellus molestie nunc non blandit massa. Penatibus et magnis dis parturient montes nascetur ridiculus. Bibendum enim facilisis gravida neque convallis. At risus viverra adipiscing at in tellus integer feugiat scelerisque. Turpis egestas pretium aenean pharetra magna ac. Suspendisse ultrices gravida dictum fusce ut. Mauris vitae ultricies leo integer. Senectus et netus et malesuada fames ac turpis egestas. Libero volutpat sed cras ornare. Tristique senectus et netus et malesuada fames ac.";
                auction.Status = this.RandomStatus();
                if (auction.Status != AuctionStatus.Draft)
                {
                    auction.DateOpen = this.RandomDate();
                }
                if (auction.Status == AuctionStatus.Close)
                {
                    var dataAnterior = DateTime.Now.AddDays(-random.Next(10));
                    auction.DateClose = auction.DateOpen.Value.CompareTo(dataAnterior) > 0 ? dataAnterior : auction.DateOpen.Value;
                }
                auction.CategoryId = auction.Category.Id;
                return auction;
            }
        }

        private AuctionStatus RandomStatus()
        {
            int index = random.Next(0, 3);
            var values = Enum.GetValues(typeof(AuctionStatus));
            return (AuctionStatus)values.GetValue(index);
        }
    }
}