using Modelo;
using Pesistencia.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico
{
    public class CategoriasServico
    {
        private CategoriasDAL _categoriaDAL = new CategoriasDAL();

        public IEnumerable<Categorias> List()
        {
            return _categoriaDAL.List();
        }

        public void Save(Categorias cate)
        {
            _categoriaDAL.Save(cate);
        }

        public Categorias GetById(long id)
        {
            return _categoriaDAL.GetById(id);
        }

        public void Delete(long id)
        {
            _categoriaDAL.Delete(id);
        }
    }
}
