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
        public HttpCookie CreateCookie(string value)
        {

            HttpCookie cookie = new HttpCookie("Cookie");
            cookie.Value = value;
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

        //Pegando os anteriores do cache e transformando em int
        public int[] ToArray(string ant)
        {
            string[] antes = ant.Split('/');
            int[] anteriores = new int[antes.Length];
            for (int i = 0; i < antes.Length; i++)
            {
                anteriores[i] = Convert.ToInt32(antes[i]);
            }

            return anteriores;
        }

        public void DeletarAnterior(long? idPergunta, string ant)
        {
            //Transformando o cookie em array
            int[] anteriores = ToArray(ant);

            //Encontrando o ID da pergunta no array e pegando seu  index
            int indexAnterior;
            if (idPergunta == null)
            {
                indexAnterior = 0;
            }
            else
            {
                indexAnterior = Array.FindIndex(anteriores, x => x == idPergunta);
            }

            //Criando um novo cookie a partir do proximo valor do index encontrado
            string novoCookie = anteriores[indexAnterior + 1].ToString();
            for (int i = indexAnterior + 2; i < anteriores.Length; i++)
            {
                novoCookie += "/" + anteriores[i];
            }
            RemoveCookie();
            CreateCookie(novoCookie);
        }
    }
}
