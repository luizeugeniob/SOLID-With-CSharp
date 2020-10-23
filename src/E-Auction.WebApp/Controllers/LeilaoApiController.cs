using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EAuction.WebApp.Models;
using EAuction.WebApp.Dados;
using System.Collections.Generic;
using System.Linq;

namespace EAuction.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        AppDbContext _context;

        public LeilaoApiController()
        {
            _context = new AppDbContext();
        }

        private IEnumerable<Leilao> GetLeiloes()
        {
            return _context.Leiloes
                .Include(l => l.Categoria)
                .ToList();
        }

        private Leilao GetLeilaoById(int id)
        {
            return _context.Leiloes.First(l => l.Id == id);
        }

        private void AddLeilao(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }

        private void UpdateLeilao(Leilao leilao)
        {
            _context.Leiloes.Update(leilao);
            _context.SaveChanges();
        }

        private void RemoveLeilao(Leilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leiloes = GetLeiloes();
            return Ok(leiloes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = GetLeilaoById(id);
            if (leilao == null)
            {
                return NotFound();
            }
            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            AddLeilao(leilao);
            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            UpdateLeilao(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = GetLeilaoById(id);
            if (leilao == null)
            {
                return NotFound();
            }
            RemoveLeilao(leilao);
            return NoContent();
        }


    }
}
