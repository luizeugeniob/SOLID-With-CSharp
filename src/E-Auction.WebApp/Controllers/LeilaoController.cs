using EAuction.WebApp.Models;
using EAuction.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace EAuction.WebApp.Controllers
{
    public class LeilaoController : Controller
    {
        private readonly IAdminService _adminService;

        public LeilaoController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public IActionResult Index()
        {
            var auctions = _adminService.GetAuctions();
            return View(auctions);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            ViewData["Categorias"] = _adminService.GetCategories();
            ViewData["Operacao"] = "Inclusão";
            return View("Form");
        }

        [HttpPost]
        public IActionResult Insert(Auction model)
        {
            if (ModelState.IsValid)
            {
                _adminService.InsertAuction(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _adminService.GetCategories();
            ViewData["Operacao"] = "Inclusão";
            return View("Form", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Categorias"] = _adminService.GetCategories();
            ViewData["Operacao"] = "Edição";
            var auction = _adminService.GetAuctionById(id);
            if (auction == null) return NotFound();
            return View("Form", auction);
        }

        [HttpPost]
        public IActionResult Edit(Auction model)
        {
            if (ModelState.IsValid)
            {
                _adminService.UpdateAuction(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _adminService.GetCategories();
            ViewData["Operacao"] = "Edição";
            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Inicia(int id)
        {
            var auction = _adminService.GetAuctionById(id);
            if (auction == null) return NotFound();
            if (auction.Status != AuctionStatus.Draft) return StatusCode(405);
            auction.Status = AuctionStatus.Trading;
            auction.DateOpen = DateTime.Now;
            _adminService.UpdateAuction(auction);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Finaliza(int id)
        {
            var auction = _adminService.GetAuctionById(id);
            if (auction == null) return NotFound();
            if (auction.Status != AuctionStatus.Trading) return StatusCode(405);
            auction.Status = AuctionStatus.Close;
            auction.DateClose = DateTime.Now;
            _adminService.UpdateAuction(auction);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var auction = _adminService.GetAuctionById(id);
            if (auction == null) return NotFound();
            if (auction.Status == AuctionStatus.Trading) return StatusCode(405);
            _adminService.DeleteAuction(auction);
            return NoContent();
        }

        [HttpGet]
        public IActionResult Pesquisa(string term)
        {
            ViewData["termo"] = term;
            var auctions = _adminService.GetAuctions()
                .Where(l => string.IsNullOrWhiteSpace(term) ||
                    l.Title.ToUpper().Contains(term.ToUpper()) ||
                    l.Description.ToUpper().Contains(term.ToUpper()) ||
                    l.Category.Name.ToUpper().Contains(term.ToUpper())
                );
            return View("Index", auctions);
        }
    }
}
