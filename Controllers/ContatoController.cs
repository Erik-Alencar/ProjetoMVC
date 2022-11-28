using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoMVC.Context;
using ProjetoMVC.Models;

namespace ProjetoMVC.Controllers
{
    public class ContatoController : Controller
    {
        private readonly AgendaContext _Context;

        public ContatoController(AgendaContext context)
        {
            _Context = context;
        }
        public IActionResult Index()
        {
            var contatos = _Context.contatos.ToList();
            return View(contatos);
        }
        public IActionResult Criar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            if (ModelState.IsValid)
            {
                _Context.contatos.Add(contato);
                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }
        public IActionResult Editar(int id)
        {
            var contato= _Context.contatos.Find(id);
            if (contato==null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }
         [HttpPost]
        public IActionResult Editar(Contato contato)
        {
            var contatoBanco = _Context.contatos.Find(contato.Id);

            contatoBanco.Nome= contato.Nome;
            contatoBanco.Telefone=contato.Telefone;
            contatoBanco.Ativo= contato.Ativo;

            _Context.contatos.Update(contatoBanco);
            _Context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult Detalhes (int id)
        {
            var contato= _Context.contatos.Find(id);
            if (contato ==null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }
        public IActionResult Deletar(int id)
        {
            var contato= _Context.contatos.Find(id);
            if (contato ==null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(contato);
        }
        [HttpPost]
        public IActionResult Deletar(Contato contato)
        {
            var contatoBanco= _Context.contatos.Find(contato.Id);
            _Context.contatos.Remove(contatoBanco);
            _Context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
    }
}