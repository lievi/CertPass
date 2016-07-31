using Modelo;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CertPass.Controllers
{
    public class PerguntasController : Controller
    {
        private PerguntasServico perguntasServico = new PerguntasServico();
        private CategoriasServico categoriasServico = new CategoriasServico();
        CookieServico _cookieServico = new CookieServico();

        // GET: Perguntas
        public ActionResult Index()
        {
            return View(perguntasServico.List());
        }

        // GET: Perguntas/Details/5
        public ActionResult Details(int id)
        {
            return View(perguntasServico.GetById(id));
        }

        // GET: Perguntas/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Perguntas/Create
        [HttpPost]
        public ActionResult Create(Perguntas pergunta)
        {
            try
            {
                perguntasServico.Save(pergunta);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(pergunta);
            }
        }

        // GET: Perguntas/Edit/5
        public ActionResult Edit(long id)
        {
            Modelo.Perguntas p = perguntasServico.GetById(id);
            PopularViewBag(p);
            return View(p);
        }

        // POST: Perguntas/Edit/5
        [HttpPost]
        public ActionResult Edit(Perguntas pergunta)
        {
                perguntasServico.Save(pergunta);
                return RedirectToAction("Index");

        }

        // GET: Perguntas/Delete/5
        public ActionResult Delete(long? id)
        {
            return View();
        }

        // POST: Perguntas/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            perguntasServico.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult ProximaPergunta()
        {
            HttpCookie cookie = HttpContext.Request.Cookies["Cookie"];
            Perguntas pergunta = perguntasServico.ProximaPerg(cookie.Value);
            _cookieServico.DeletarAnterior(pergunta.PerguntaId, cookie.Value);
            return View(pergunta);
        }

        [HttpPost]
        public ActionResult ProximaPergunta(Perguntas p)
        {
            Perguntas pAtual = perguntasServico.GetById((long)p.PerguntaId);

            if (p.Alt1 == pAtual.AltCorreta)
            {
                return View("~/Views/Perguntas/Certo.cshtml", pAtual);
            }
            return View("~/Views/Perguntas/Errado.cshtml", pAtual);
        }

        public ActionResult Perguntas(string categoriaSelecionada)
        {
            HttpCookie cookie = _cookieServico.CreateCookie(perguntasServico.GetRandom(Convert.ToInt16(categoriaSelecionada)));

            Perguntas pergunta = perguntasServico.ProximaPerg(cookie.Value);
            _cookieServico.DeletarAnterior(pergunta.PerguntaId, cookie.Value);
            return View("~/Views/Perguntas/Perguntas.cshtml", pergunta);
        }

        private void PopularViewBag(Perguntas pergunta = null)
        {
            if (pergunta == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriasServico.List(),"CategoriaId","NomeCateg");
            }
            else
            {
                //No Edit, ele ja mostra a categoria salva, (selected item)
                ViewBag.CategoriaId = new SelectList(categoriasServico.List(),"CategoriaId", "NomeCateg",pergunta.CategoriaId);
            }
        }
    }
}
