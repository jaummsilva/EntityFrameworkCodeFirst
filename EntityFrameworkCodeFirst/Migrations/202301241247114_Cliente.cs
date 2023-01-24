namespace EntityFrameworkCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cliente : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Carroes", "Nome", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Modeloes", "Nome", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Modeloes", "Nome", c => c.String());
            AlterColumn("dbo.Carroes", "Nome", c => c.String());
            DropTable("dbo.Clientes");
        }
    }
}
