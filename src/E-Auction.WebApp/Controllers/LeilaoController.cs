using EAuction.WebApp.Dados;
using EAuction.WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EAuction.WebApp.Controllers
{
    public class LeilaoController : Controller
    {
        ILeilaoDao _dao;

        public LeilaoController(ILeilaoDao dao)
        {
            _dao = dao;
        }

        public IActionResult Index()
        {
            var leiloes = _dao.GetLeiloes();
            return View(leiloes);
        } 

        [HttpGet]
        public IActionResult Insert()
        {
            ViewData["Categorias"] = _dao.GetCategorias();
            ViewData["Operacao"] = "Inclusão";
            return View("Form");
        }

        [HttpPost]
        public IActionResult Insert(Leilao model)
        {
            if (ModelState.IsValid)
            {
                _dao.AddLeilao(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _dao.GetCategorias();
            ViewData["Operacao"] = "Inclusão";
            return View("Form", model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Categorias"] = _dao.GetCategorias();
            ViewData["Operacao"] = "Edição";
            var leilao = _dao.GetLeilaoById(id);
            if (leilao == null) return NotFound();
            return View("Form", leilao);
        }

        [HttpPost]
        public IActionResult Edit(Leilao model)
        {
            if (ModelState.IsValid)
            {
                _dao.UpdateLeilao(model);
                return RedirectToAction("Index");
            }
            ViewData["Categorias"] = _dao.GetCategorias();
            ViewData["Operacao"] = "Edição";
            return View("Form", model);
        }

        [HttpPost]
        public IActionResult Inicia(int id)
        {
            var leilao = _dao.GetLeilaoById(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao != SituacaoLeilao.Rascunho) return StatusCode(405);
            leilao.Situacao = SituacaoLeilao.Pregao;
            leilao.Inicio = DateTime.Now;
            _dao.UpdateLeilao(leilao);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Finaliza(int id)
        {
            var leilao = _dao.GetLeilaoById(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao != SituacaoLeilao.Pregao) return StatusCode(405);
            leilao.Situacao = SituacaoLeilao.Finalizado;
            leilao.Termino = DateTime.Now;
            _dao.UpdateLeilao(leilao);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var leilao = _dao.GetLeilaoById(id);
            if (leilao == null) return NotFound();
            if (leilao.Situacao == SituacaoLeilao.Pregao) return StatusCode(405);
            _dao.RemoveLeilao(leilao);
            return NoContent();
        }

        [HttpGet]
        public IActionResult Pesquisa(string termo)
        {
            ViewData["termo"] = termo;
            var leiloes = _dao.GetLeiloes()
                .Where(l => string.IsNullOrWhiteSpace(termo) || 
                    l.Titulo.ToUpper().Contains(termo.ToUpper()) || 
                    l.Descricao.ToUpper().Contains(termo.ToUpper()) ||
                    l.Categoria.Descricao.ToUpper().Contains(termo.ToUpper())
                );
            return View("Index", leiloes);
        }
    }
}
