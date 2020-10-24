using EAuction.WebApp.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace EAuction.WebApp.Controllers
{
    public class HomeController : Controller
    {
        IProductService _productService;

        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            var categories = _productService.GetCategoriesWithTotalAuctionsInTrading();
            return View(categories);
        }

        [Route("[controller]/StatusCode/{statusCode}")]
        public IActionResult StatusCodeError(int statusCode)
        {
            if (statusCode == 404) return View("404");
            return View(statusCode);
        }

        [Route("[controller]/Categoria/{categoryId}")]
        public IActionResult Categoria(int categoryId)
        {
            var categ = _productService.GetCategoryWithAuctionsInTradingById(categoryId);
            return View(categ);
        }

        [HttpPost]
        [Route("[controller]/Busca")]
        public IActionResult Busca(string term)
        {
            ViewData["termo"] = term;
            var auctions = _productService.GetOpenAuctionsByTerm(term);
            return View(auctions);
        }
    }
}
