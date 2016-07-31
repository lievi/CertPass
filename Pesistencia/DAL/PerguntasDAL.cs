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

        public string GetRandom()
        {

            //Criando um array de numeros randomicos
            Random r = new Random();
            List<Perguntas> perguntas = List().ToList();
            string teste = "";
            
            HashSet<int> numbers = new HashSet<int>();
            while (numbers.Count < 3)
            {
                numbers.Add(r.Next(1, perguntas.Count));
            }

            int[] rnum =  numbers.ToArray();
            teste += numbers.First();
            for (int i = 1; i < numbers.Count; i++)
            {
                teste += "/" + rnum[i];
            }


            //bool haRepetido = true;
            //do
            //{
            //    foreach (var item in anteriores)
            //    {
            //        if (atual == item)
            //        {
            //            atual = r.Next(0, perguntas.Count);
            //            break;
            //        }
            //    }
            //    haRepetido = false;
            //} while (haRepetido == true || perguntas.Count != anteriores.Length);
            return teste;
        }
    }
}

