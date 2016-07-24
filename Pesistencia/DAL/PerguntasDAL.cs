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
        public void Save(Registro registro)
        {
            if (registro.Perguntas.PerguntaId == null)
            {
                registro.Perguntas.Resposta = registro.Respostas;
                db.Perguntas.Add(registro.Perguntas);
            }
            else
            {
                db.Entry(registro.Respostas).State = EntityState.Modified;
                registro.Perguntas.RespostaId = registro.Respostas.RespostaId;
                db.Entry(registro.Perguntas).State = EntityState.Modified;
            }
            db.SaveChanges();
        }

        //List
        public IQueryable<Perguntas> List()
        {
            return db.Perguntas.OrderBy(x => x.PerguntaId).Include(c=>c.Categorias).OrderBy(x=>x.DescPergunta);
        }


        //GetByID
        public Registro GetById(long i)
        {
            Perguntas p = db.Perguntas.Where(x => x.PerguntaId == i).Include(c =>c.Categorias).First();
            Registro r = new Registro();
            r.Perguntas = p;
            r.Respostas = db.Respostas.Where(x => x.RespostaId == p.RespostaId).First();
            return r;
        }

        public void Delete(long id)
        {
            Perguntas p = db.Perguntas.Where(x => x.PerguntaId == id).First();
            Respostas r = db.Respostas.Where(x => x.RespostaId == p.RespostaId).First();

            db.Perguntas.Remove(p);
            db.Respostas.Remove(r);

            db.SaveChanges();
        }

        public List<Registro> GetRandom()
        {
            //Pegando o ID das perguntas
            int[] nId = new int[5];
            List<Registro> perguntasRandom = new List<Registro>();
            IQueryable<Perguntas> perguntas = db.Perguntas.OrderBy(x => x.PerguntaId);
            Random r = new Random();
            
            for (int i = 0; i < 5; i++)
            {
                int atual = r.Next(30,40);
                if (perguntas.Any(x=>x.PerguntaId == atual))
                {
                    if (perguntasRandom.Any(x =>x.Perguntas.PerguntaId == atual))
                    {
                        atual = r.Next(30,40);
                        i--;
                    }
                    else
                    {
                        perguntasRandom.Add(GetById(atual));
                    }
                }
                else
                {
                    atual = r.Next(30,40);
                    i--;
                }
                
            }
            return perguntasRandom;
        }
    }
}
