using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servico;
using Modelo;

namespace CertPass.Controllers
{
    public class HomeController : Controller
    {
        CookieServico _cookieServico = new CookieServico();
        PerguntasServico _perguntaServico = new PerguntasServico();
        private Perguntas pergunta;
        // GET: Home
        public ActionResult Index()
        {
            this.ControllerContext.HttpContext.Response.Cookies.Clear();
            HttpCookie cookie =  _cookieServico.CreateCookie();
            
            cookie.Value = _perguntaServico.GetRandom();
            pergunta = _perguntaServico.ProximaPerg(cookie.Value);
            return View(pergunta);
        }

        //[HttpPost]
        //public ActionResult Index(Perguntas r)
        //{
        //    if (r.Perguntas.Alt1 == pergunta.Respostas.AltCorreta)
        //    {
        //        return View("~/Views/Home/Certo.cshtml");
        //    }
        //    return View("~/Views/Home/Errado.cshtml");

        //    _cookieServico.RemoveCookie();
        //    return RedirectToAction("Index");
        //}

    }
}
