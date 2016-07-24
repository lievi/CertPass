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
            cookie.Value = "1";
            HttpContext.Current.Response.Cookies.Add(cookie);

            return cookie;
        }

        public void RemoveCookie()
        {
            if (HttpContext.Current.Request.Cookies.AllKeys.Contains("Cookie"))
            {
                HttpCookie cookie = HttpContext.Current.Request.Cookies["Cookie"];
                cookie.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
    }
}
