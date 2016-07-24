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
            
            HttpCookie cookie =  _cookieServico.CreateCookie();
            if (this.ControllerContext.HttpContext.Request.Cookies.AllKeys.Contains("Cookie"))
            {
                //cookie = "Oh yeah baby" + this.ControllerContext.HttpContext.Request.Cookies["Cookie"].Value;
            }

            
            List<Registro> perguntas = _perguntaServico.GetRandom();
            cookie.
            ViewData["Perguntas"] = perguntas;
            return View();
        }

    }
}
