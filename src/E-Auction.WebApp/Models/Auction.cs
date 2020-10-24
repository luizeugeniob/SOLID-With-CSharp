using System;
using System.ComponentModel.DataAnnotations;

namespace EAuction.WebApp.Models
{
    public class Auction
    {        
        public int Id { get; set; }
        
        [Required(ErrorMessage = "T�tulo � obrigat�rio")] 
        [Display(Name = "T�tulo", Prompt = "Digite o t�tulo do leil�o")]
        public string Title { get; set; }

        [Display(Name = "Descri��o")]
        public string Description { get; set; }

        [Display(Name = "In�cio do Preg�o")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inv�lida")]
        public DateTime? DateOpen { get; set; }

        [Display(Name = "T�rmino do Preg�o")]
        [DataType(DataType.DateTime, ErrorMessage = "Data inv�lida")]
        public DateTime? DateClose { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public AuctionStatus Status { get; set; }
        public string UrlPoster => $"/images/poster-{Id}.jpg";
    }
}