using EAuction.WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EAuction.WebApp.Dados
{
    public class LeilaoDao
    {
        AppDbContext _context;

        public LeilaoDao()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Categoria> GetCategorias()
        {
            return _context.Categorias.ToList();
        }

        public IEnumerable<Leilao> GetLeiloes()
        {
            return _context.Leiloes
                .Include(l => l.Categoria)
                .ToList();
        }

        public Leilao GetLeilaoById(int id)
        {
            return _context.Leiloes.First(l => l.Id == id);
        }

        public void AddLeilao(Leilao leilao)
        {
            _context.Leiloes.Add(leilao);
            _context.SaveChanges();
        }

        public void UpdateLeilao(Leilao leilao)
        {
            _context.Leiloes.Update(leilao);
            _context.SaveChanges();
        }

        public void RemoveLeilao(Leilao leilao)
        {
            _context.Leiloes.Remove(leilao);
            _context.SaveChanges();
        }
    }
}
