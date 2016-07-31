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
        
        PerguntasServico _perguntaServico = new PerguntasServico();
        CookieServico _cookie = new CookieServico();
        
        // GET: Home
        public ActionResult Index()
        {
            _cookie.RemoveCookie();
            return View();
        }

        
    }
}
