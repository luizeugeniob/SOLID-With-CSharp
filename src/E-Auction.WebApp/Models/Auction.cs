using System;
using System.ComponentModel.DataAnnotations;

namespace EAuction.WebApp.Models
{
    public class Auction
    {        
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Título é obrigatório")] 
        [Display(Name = "Título", Prompt = "Digite o título do leilão")]
        public string Title { get; set; }

        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Display(Name = "Início do Pregão")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inválida")]
        public DateTime? DateOpen { get; set; }

        [Display(Name = "Término do Pregão")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inválida")]
        public DateTime? DateClose { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public AuctionStatus Status { get; set; }
        public string UrlPoster => $"/images/poster-{Id}.jpg";
    }
}