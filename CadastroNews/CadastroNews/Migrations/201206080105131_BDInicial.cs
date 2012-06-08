namespace CadastroNews.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class BDInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Fontes",
                c => new
                    {
                        FonteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Contato = c.String(),
                    })
                .PrimaryKey(t => t.FonteId);
            
            CreateTable(
                "Noticias",
                c => new
                    {
                        NoticiaId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Conteudo = c.String(),
                        Fonte_FonteId = c.Int(),
                    })
                .PrimaryKey(t => t.NoticiaId)
                .ForeignKey("Fontes", t => t.Fonte_FonteId)
                .Index(t => t.Fonte_FonteId);
            
        }
        
        public override void Down()
        {
            DropIndex("Noticias", new[] { "Fonte_FonteId" });
            DropForeignKey("Noticias", "Fonte_FonteId", "Fontes");
            DropTable("Noticias");
            DropTable("Fontes");
        }
    }
}
