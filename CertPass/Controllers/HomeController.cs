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
            HttpCookie cookie = _cookieServico.CreateCookie(_perguntaServico.GetRandom());

            //Somente teste, necessário colocar cada elemento aqui em sua View correspondente
            Perguntas pergunta = _perguntaServico.ProximaPerg(cookie.Value);
            _cookieServico.DeletarAnterior(pergunta.PerguntaId, cookie.Value);
            return View(pergunta);
        }

        [HttpPost]
        public ActionResult ProximaPergunta(Perguntas p)
        {
            Perguntas pAtual = _perguntaServico.GetById((long)p.PerguntaId);

            if (p.Alt1 == pAtual.AltCorreta)
            {
                return View("~/Views/Home/Certo.cshtml",pAtual);
            }
            return View("~/Views/Home/Errado.cshtml",pAtual);
        }

        public ActionResult ProximaPergunta()
        {
            HttpCookie cookie = HttpContext.Request.Cookies["Cookie"];
            Perguntas pergunta = _perguntaServico.ProximaPerg(cookie.Value);
            _cookieServico.DeletarAnterior(pergunta.PerguntaId, cookie.Value);
            return View(pergunta);
        }
    }
}
