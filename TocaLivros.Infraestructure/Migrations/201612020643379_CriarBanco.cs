namespace TocaLivros.Infraestructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        PedidoId = c.Int(nullable: false, identity: true),
                        Valor = c.Double(nullable: false),
                        UsuarioId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoId)
                .ForeignKey("dbo.Usuario", t => t.UsuarioId, cascadeDelete: true)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Valor = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ProdutoId);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        UsuarioId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.UsuarioId)
                .Index(t => t.UserName, unique: true, name: "IX_Username");
            
            CreateTable(
                "dbo.PedidoItens",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false),
                        PedidoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProdutoId, t.PedidoId })
                .ForeignKey("dbo.Produto", t => t.ProdutoId, cascadeDelete: true)
                .ForeignKey("dbo.Pedido", t => t.PedidoId, cascadeDelete: true)
                .Index(t => t.ProdutoId)
                .Index(t => t.PedidoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pedido", "UsuarioId", "dbo.Usuario");
            DropForeignKey("dbo.PedidoItens", "PedidoId", "dbo.Pedido");
            DropForeignKey("dbo.PedidoItens", "ProdutoId", "dbo.Produto");
            DropIndex("dbo.PedidoItens", new[] { "PedidoId" });
            DropIndex("dbo.PedidoItens", new[] { "ProdutoId" });
            DropIndex("dbo.Usuario", "IX_Username");
            DropIndex("dbo.Pedido", new[] { "UsuarioId" });
            DropTable("dbo.PedidoItens");
            DropTable("dbo.Usuario");
            DropTable("dbo.Produto");
            DropTable("dbo.Pedido");
        }
    }
}
