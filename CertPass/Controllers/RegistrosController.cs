﻿using Modelo;
using Servico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CertPass.Controllers
{
    public class RegistrosController : Controller
    {
        private PerguntasServico perguntasServico = new PerguntasServico();
        private CategoriasServico categoriasServico = new CategoriasServico();
        // GET: Perguntas
        public ActionResult Index()
        {
            return View(perguntasServico.List());
        }

        // GET: Perguntas/Details/5
        public ActionResult Details(int id)
        {
            return View(perguntasServico.GetById(id));
        }

        // GET: Perguntas/Create
        public ActionResult Create()
        {
            PopularViewBag();
            return View();
        }

        // POST: Perguntas/Create
        [HttpPost]
        public ActionResult Create(Registro novoRegistro, Perguntas pergunta)
        {
            novoRegistro.Perguntas.CategoriaId = pergunta.CategoriaId;
            try
            {
                perguntasServico.Save(novoRegistro);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(novoRegistro);
            }
        }

        // GET: Perguntas/Edit/5
        public ActionResult Edit(long id)
        {
            return View(perguntasServico.GetById(id));
        }

        // POST: Perguntas/Edit/5
        [HttpPost]
        public ActionResult Edit(Registro registro)
        {
                perguntasServico.Save(registro);
                return RedirectToAction("Index");

        }

        // GET: Perguntas/Delete/5
        public ActionResult Delete(long? id)
        {
            return View();
        }

        // POST: Perguntas/Delete/5
        [HttpPost]
        public ActionResult Delete(long id)
        {
            perguntasServico.Delete(id);
            return RedirectToAction("Index");
        }

        private void PopularViewBag(Registro registro = null)
        {
            if (registro == null)
            {
                ViewBag.CategoriaId = new SelectList(categoriasServico.List(),"CategoriaId","NomeCateg");
            }
            else
            {
                //No Edit, ele ja mostra a categoria salva, (selected item)
                ViewBag.CategoriaId = new SelectList(categoriasServico.List(),"CategoriaId", "NomeCateg",registro.Perguntas.CategoriaId);
            }
        }
    }
}
