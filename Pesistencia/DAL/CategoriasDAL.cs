using Modelo;
using Persistencia.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pesistencia.DAL
{
    public class CategoriasDAL
    {
        private CertPassContext db = new CertPassContext();

        public IEnumerable<Categorias> List()
        {
            return db.Categorias.OrderBy(x => x.NomeCateg);
        }

        public void Save(Categorias cate)
        {
            if(cate.CategoriaId == null)
            {
                db.Categorias.Add(cate);
            }
            else
            {
                db.Entry(cate).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
        }

        public Categorias GetById(long id)
        {
            return db.Categorias.Where(x => x.CategoriaId == id).First();
        }

        public void Delete(long id)
        {
            Categorias categoria = GetById(id);
            db.Categorias.Remove(categoria);
            db.SaveChanges();
        }
    }
}
