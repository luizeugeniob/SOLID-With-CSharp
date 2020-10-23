using EAuction.WebApp.Models;
using System.Collections.Generic;

namespace EAuction.WebApp.Dados
{
    public interface ILeilaoDao
    {
        IEnumerable<Categoria> GetCategorias();

        IEnumerable<Leilao> GetLeiloes();

        Leilao GetLeilaoById(int id);

        void AddLeilao(Leilao leilao);

        void UpdateLeilao(Leilao leilao);

        void RemoveLeilao(Leilao leilao);
    }
}
