using Modelo;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CertPass.Controllers
{
    public class CategoriasController : Controller
    {
        private CategoriasServico _categoriaServico = new CategoriasServico();
        // GET: Categorias
        public ActionResult Index()
        {
            return View(_categoriaServico.List());
        }

        // GET: Categorias/Details/5
        public ActionResult Details(int id)
        {
            return View(_categoriaServico.GetById(id));
        }

        // GET: Categorias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        public ActionResult Create(Categorias cate)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _categoriaServico.Save(cate);
                }
                else
                {
                    return View(cate);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cate);
            }
        }

        // GET: Categorias/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_categoriaServico.GetById(id));
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Categorias cate)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    _categoriaServico.Save(cate);
                }
                else
                {
                    return View(cate);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(cate);
            }
        }

        // GET: Categorias/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Categorias/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
                _categoriaServico.Delete(id);
                return RedirectToAction("Index");
        }
        [ChildActionOnly]
        public ActionResult Listar()
        {
            
            return PartialView(_categoriaServico.List());
        }
    }
}
