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

        //Create/Edit

        public void Save(Registro regitro)
        {
            perguntasDAL.Save(regitro);
        }

        //List
        public IEnumerable<Perguntas> List()
        {
            return perguntasDAL.List();
        }

        //GetBy Id
        public Registro GetById(long id)
        {
            return perguntasDAL.GetById(id);
        }

        public void Delete(long id)
        {
            perguntasDAL.Delete(id);
        }

    }
}
