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
        // GET: Home
        public ActionResult Index()
        {
            this.ControllerContext.HttpContext.Response.Cookies.Clear();
            HttpCookie cookie =  _cookieServico.CreateCookie();
            //if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie"))
            //{
            //    cookie = "Oh yeah baby" + this.ControllerContext.HttpContext.Request.Cookies["Cookie"].Value;
            //}

            
            Registro pergunta = _perguntaServico.GetRandom(ControllerContext.HttpContext.Request.Cookies["Cookie"].Value);
            string batata = ControllerContext.HttpContext.Request.Cookies["Cookie"].Value;
            batata = batata +"/"+ pergunta.Perguntas.PerguntaId.ToString();
            cookie.Value = batata;
            return View(pergunta);
        }

        [HttpPost]
        public ActionResult Index(Registro registro)
        {
            _cookieServico.RemoveCookie();
            return RedirectToAction("Index");
        }

    }
}
