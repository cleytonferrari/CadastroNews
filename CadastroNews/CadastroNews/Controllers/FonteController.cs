using System.Linq;
using System.Web.Mvc;
using CadastroNews.Infra;

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

    }
}
