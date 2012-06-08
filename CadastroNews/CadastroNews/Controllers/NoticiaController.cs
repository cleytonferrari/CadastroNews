using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CadastroNews.Infra;
using CadastroNews.Models;

namespace CadastroNews.Controllers
{
    public class NoticiaController : Controller
    {
        private readonly DbComum db = new DbComum();

        public ViewResult Index()
        {
            return View(db.Noticias.Include(x => x.Fonte).ToList());
        }

        public ViewResult Details(int id)
        {
            Noticia noticia = db.Noticias.Include(x => x.Fonte).FirstOrDefault(x => x.NoticiaId == id);
            return View(noticia);
        }

        public ActionResult Create()
        {
            var listaDeFontes = db.Fontes.ToList();

            //<select>
            // <option value="1">Texto</option>
            //</select>
            ViewBag.ListaDeFontes = new SelectList(listaDeFontes, "FonteId", "Nome");

            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Fonte")]Noticia noticia, int fonteId)
        {
            if (ModelState.IsValid)
            {
                noticia.Fonte = db.Fontes.Find(fonteId);
                db.Noticias.Add(noticia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(noticia);
        }

        public ActionResult Edit(int id)
        {
            Noticia noticia = db.Noticias.Include(x => x.Fonte).FirstOrDefault(x => x.NoticiaId == id);

            var listaDeFontes = db.Fontes.ToList();
            ViewBag.ListaDeFontes = new SelectList(listaDeFontes, "FonteId", "Nome", noticia.Fonte.FonteId);

            return View(noticia);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Exclude = "Fonte")]Noticia noticia, int fonteId)
        {
            if (ModelState.IsValid)
            {
                var noticiaQueVaiProBanco = db.Noticias.Find(noticia.NoticiaId);
                noticiaQueVaiProBanco.Conteudo = noticia.Conteudo;
                noticiaQueVaiProBanco.Titulo = noticia.Titulo;

                noticiaQueVaiProBanco.Fonte = db.Fontes.Find(fonteId);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(noticia);
        }

        public ActionResult Delete(int id)
        {
            Noticia noticia = db.Noticias.Find(id);
            return View(noticia);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Noticia noticia = db.Noticias.Find(id);
            db.Noticias.Remove(noticia);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}