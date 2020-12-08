using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using RegistraPessoa.Dados.Entity.Context;
using RegistraPessoa.Dominio;
using RegistraPessoa.Repositorios.Comum;
using RegistraPessoa.Repositorios.Entity;
using RegistraPessoa.Web.ViewModels.Categoria;
using RegistraPessoa.Web.ViewModels.Pessoa;

namespace RegistraPessoa.Web.Controllers
{
    [Authorize]
    public class PessoasController : Controller
    {
        private IRepositorioGenerico<Pessoa, int>
            repositorioPessoas = new PessoasRepositorio(new PessoaDbContext());

        private IRepositorioGenerico<Categoria, int>
            repositorioCategorias = new CategoriasRepositorio(new PessoaDbContext());

        // GET: Pessoas
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Pessoa>, 
                List<PessoaIndexViewModel>>(repositorioPessoas.Selecionar()));
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa filme = repositorioPessoas.SelecionarPorId(id.Value);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Pessoa, PessoaIndexViewModel>(filme));
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            // ViewBag.IdCategoria = new SelectList(db.Categorias, "Id", "Nome");
            List<CategoriaIndexViewModel> categorias = Mapper.Map<List<Categoria>,
                List<CategoriaIndexViewModel>>(repositorioCategorias.Selecionar());


            SelectList dropDownCategorias = new SelectList(categorias, "Id", "Nome");
            ViewBag.DropDownCategorias = dropDownCategorias;
            return View();
        }

        // POST: Pessoas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdPessoa,NomePessoa,IdCategoria")] PessoaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Pessoa filme = Mapper.Map<PessoaViewModel, Pessoa>(viewModel);
                repositorioPessoas.Inserir(filme);
                return RedirectToAction("Index");
            }

            // ViewBag.IdCategoria = new SelectList(db.Categorias, "Id", "Nome", filme.IdCategoria);
            return View(viewModel);
        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa filme = repositorioPessoas.SelecionarPorId(id.Value);
            if (filme == null)
            {
                return HttpNotFound();
            }
    
            List<CategoriaIndexViewModel> categorias = Mapper.Map<List<Categoria>,
               List<CategoriaIndexViewModel>>(repositorioCategorias.Selecionar());


            SelectList dropDownCategorias = new SelectList(categorias, "Id", "Nome");
            ViewBag.DropDownCategorias = dropDownCategorias;
            return View(Mapper.Map<Pessoa, PessoaViewModel>(filme));
        }

        // POST: Pessoas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdPessoa,NomePessoa,IdCategoria")] PessoaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Pessoa filme = Mapper.Map<PessoaViewModel, Pessoa>(viewModel);
                repositorioPessoas.Alterar(filme);
                return RedirectToAction("Index");
            }
            // ViewBag.IdCategoria = new SelectList(db.Categorias, "Id", "Nome", filme.IdCategoria);
            return View(viewModel);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pessoa filme = repositorioPessoas.SelecionarPorId(id.Value);
            if (filme == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Pessoa, PessoaIndexViewModel>(filme));
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositorioPessoas.ExcluirPorId(id);
            return RedirectToAction("Index");
        }
    }
}
