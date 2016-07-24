using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Servico
{
    public class CookieServico
    {
        public HttpCookie CreateCookie()
        {
            HttpCookie cookie = new HttpCookie("Cookie");
            cookie.Value = "Olá Mundo, eu fui criado ás: " + DateTime.Now.ToShortTimeString();

            HttpContext.Current.Response.Cookies.Add(cookie);

            return cookie;
        }
    }
}
