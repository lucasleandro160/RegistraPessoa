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
using RegistraPessoa.Web.Filtros;
using RegistraPessoa.Web.ViewModels.Categoria;

namespace RegistraPessoa.Web.Controllers
{
    [Authorize]
    public class CategoriasController : Controller
    {
        private IRepositorioGenerico<Categoria, int>
            repositorioCategorias = new CategoriasRepositorio(new PessoaDbContext());

        // GET: Categorias
        // GET: Categorias
        public ActionResult Index()
        {
            return View(Mapper.Map<List<Categoria>, List<CategoriaIndexViewModel>>(repositorioCategorias.Selecionar()));
        }

        public ActionResult FiltrarPorNome(string pesquisa)
        {
            List<Categoria> categorias = repositorioCategorias
                .Selecionar()
                .Where(a => a.OcupacaoProfissional.Contains(pesquisa)).ToList();

            List<CategoriaIndexViewModel> viewModels = 
                Mapper.Map<List<Categoria>, List<CategoriaIndexViewModel>>(categorias);

            return Json(viewModels, JsonRequestBehavior.AllowGet);
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria album = repositorioCategorias.SelecionarPorId(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Categoria, CategoriaIndexViewModel>(album));
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OcupacaoProfissional,Sexo")] CategoriaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Categoria album = Mapper.Map<CategoriaViewModel, Categoria>(viewModel);
                repositorioCategorias.Inserir(album);
                return RedirectToAction("Index");
            }

            return View(viewModel);
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria album = repositorioCategorias.SelecionarPorId(id.Value);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Categoria, CategoriaViewModel>(album));
        }

        // POST: Categorias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OcupacaoProfissional,Sexo")] CategoriaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Categoria album = Mapper.Map<CategoriaViewModel, Categoria>(viewModel);
                repositorioCategorias.Alterar(album);
                return RedirectToAction("Index");
            }
            return View(viewModel);
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Categoria album = repositorioCategorias.SelecionarPorId(id.Value);

            if (album == null)
            {
                return HttpNotFound();
            }
            return View(Mapper.Map<Categoria, CategoriaIndexViewModel>(album));
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            repositorioCategorias.ExcluirPorId(id);
            return RedirectToAction("Index");
        }
    }
}
