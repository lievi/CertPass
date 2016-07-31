using Modelo;
using Persistencia.Context;
using Pesistencia.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAL
{
    public class PerguntasDAL
    {
        private CertPassContext db = new CertPassContext();

        //Create/Edit
        public void Save(Perguntas pergunta)
        {
            if (pergunta.PerguntaId == null)
            {
                db.Perguntas.Add(pergunta);
            }
            else
            {
                db.Entry(pergunta).State = EntityState.Modified;
            }
            db.SaveChanges();
        }

        //List
        public IQueryable<Perguntas> List()
        {
            return db.Perguntas.OrderBy(x => x.PerguntaId).Include(c => c.Categorias).OrderBy(x => x.DescPergunta);
        }


        //GetByID
        public Perguntas GetById(long i)
        {
            return db.Perguntas.Where(x => x.PerguntaId == i).Include(c => c.Categorias).First();

        }

        public void Delete(long id)
        {
            Perguntas p = db.Perguntas.Where(x => x.PerguntaId == id).First();

            db.Perguntas.Remove(p);
            db.SaveChanges();
        }

        public string GetRandom(int categoria)
        {

            //Criando um array de numeros randomicos
            Random r = new Random();
            List<Perguntas> perguntas = db.Perguntas.Where(x=>x.CategoriaId == categoria).OrderBy(x => x.PerguntaId).ToList();
            string teste = "";
            
            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count < 3)
            {
                int novo = r.Next(1, (int)perguntas.Last().PerguntaId);

                if (perguntas.Any(x=>x.PerguntaId == novo))
                {
                    numbers.Add(novo);
                } 
            }

            int[] rnum =  numbers.ToArray();
            teste += numbers.First();
            for (int i = 1; i < numbers.Count; i++)
            {
                teste += "/" + rnum[i];
            }
            return teste;
        }
    }
}

