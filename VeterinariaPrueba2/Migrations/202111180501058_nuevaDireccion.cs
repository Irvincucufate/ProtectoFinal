namespace VeterinariaPrueba2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nuevaDireccion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblRegistroAnimales",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tblRegistroDueñoId = c.Int(),
                        ClaseAnimal = c.String(nullable: false),
                        Raza = c.String(nullable: false),
                        Edad = c.Int(nullable: false),
                        Color = c.String(nullable: false),
                        Estatura = c.Int(nullable: false),
                        FechaCita = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblRegistroDueño", t => t.tblRegistroDueñoId)
                .Index(t => t.tblRegistroDueñoId);
            
            CreateTable(
                "dbo.tblRegistroDueño",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tblRegistroPersonalId = c.Int(),
                        Nombre = c.String(nullable: false),
                        Calle = c.Int(nullable: false),
                        Ciudad = c.String(nullable: false),
                        Telefono = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblRegistroPersonal", t => t.tblRegistroPersonalId)
                .Index(t => t.tblRegistroPersonalId);
            
            CreateTable(
                "dbo.tblRegistroPersonal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        DocumentoIdentificacion = c.Int(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        Edad = c.Int(nullable: false),
                        Especialidad = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblRegistroAnimales", "tblRegistroDueñoId", "dbo.tblRegistroDueño");
            DropForeignKey("dbo.tblRegistroDueño", "tblRegistroPersonalId", "dbo.tblRegistroPersonal");
            DropIndex("dbo.tblRegistroDueño", new[] { "tblRegistroPersonalId" });
            DropIndex("dbo.tblRegistroAnimales", new[] { "tblRegistroDueñoId" });
            DropTable("dbo.tblRegistroPersonal");
            DropTable("dbo.tblRegistroDueño");
            DropTable("dbo.tblRegistroAnimales");
        }
    }
}
