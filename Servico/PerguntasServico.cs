using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia.DAL;
using Modelo;

namespace Servico
{
    public class PerguntasServico
    {
        private PerguntasDAL perguntasDAL = new PerguntasDAL();
        private CookieServico _cookieServico = new CookieServico();
        //Create/Edit

        public void Save(Perguntas pergunta)
        {
            perguntasDAL.Save(pergunta);
        }

        //List
        public IQueryable<Perguntas> List()
        {
            return perguntasDAL.List();
        }

        //GetBy Id
        public Perguntas GetById(long id)
        {
            return perguntasDAL.GetById(id);
        }

        public void Delete(long id)
        {
            perguntasDAL.Delete(id);
        }

        public string GetRandom()
        {
            return perguntasDAL.GetRandom();
        }

        public Perguntas ProximaPerg(string ant)
        {
            return GetById(_cookieServico.ToArray(ant)[0]);
        }
    }
}
