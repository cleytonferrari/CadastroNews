using System.Data;
using System.Linq;
using System.Web.Mvc;
using CadastroNews.Infra;
using CadastroNews.Models;

namespace CadastroNews.Controllers
{
    public class FonteController : Controller
    {
        private readonly DbComum db = new DbComum();

        public ActionResult Index()
        {
            var listaDeFontes = db.Fontes.ToList();
            return View(listaDeFontes);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Fonte fonte)
        {
            if (ModelState.IsValid)
            {
                db.Fontes.Add(fonte);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fonte);
        }

        public ActionResult Editar(int id)
        {
            var fonte = db.Fontes.Find(id);
            return View(fonte);
        }

        [HttpPost]
        public ActionResult Editar(Fonte fonte)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fonte).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fonte);
        }

        public ActionResult Excluir(int id)
        {
            var fonte = db.Fontes.Find(id);
            return View(fonte);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(int id)
        {
            var fonte = db.Fontes.Find(id);
            db.Fontes.Remove(fonte);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}