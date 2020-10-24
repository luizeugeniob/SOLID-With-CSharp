using EAuction.WebApp.Models;
using EAuction.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace EAuction.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class AuctionApiController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AuctionApiController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            return base.Ok(_adminService.GetAuctions());
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetAuctionById(int id)
        {
            var auction = _adminService.GetAuctionById(id);
            if (auction == null)
            {
                return NotFound();
            }
            return Ok(auction);
        }

        [HttpPost]
        public IActionResult EndpointPostAucion(Auction auction)
        {
            _adminService.InsertAuction(auction);
            return Ok(auction);
        }

        [HttpPut]
        public IActionResult EndpointPutAuction(Auction auction)
        {
            _adminService.UpdateAuction(auction);
            return Ok(auction);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteAuction(int id)
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
