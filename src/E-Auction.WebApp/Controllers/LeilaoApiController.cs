using EAuction.WebApp.Dados;
using EAuction.WebApp.Models;
using EAuction.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EAuction.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public LeilaoApiController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            return base.Ok(_adminService.GetAuctions());
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var auction = _adminService.GetAuctionById(id);
            if (auction == null)
            {
                return NotFound();
            }
            return Ok(auction);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Auction auction)
        {
            _adminService.InsertAuction(auction);
            return Ok(auction);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Auction auction)
        {
            _adminService.UpdateAuction(auction);
            return Ok(auction);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var auction = _adminService.GetAuctionById(id);
            if (auction == null)
            {
                return NotFound();
            }
            _adminService.DeleteAuction(auction);
            return NoContent();
        }
    }
}
