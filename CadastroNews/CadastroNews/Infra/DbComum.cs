using System.Data.Entity;
using CadastroNews.Models;

namespace CadastroNews.Infra
{
    public class DbComum : DbContext
    {
        public DbComum()
            : base("CadastroNews")
        {

        }

        public DbSet<Fonte> Fontes { get; set; }

        public DbSet<Noticia> Noticias { get; set; }
    }
}