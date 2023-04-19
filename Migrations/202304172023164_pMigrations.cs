namespace evaluacionTecnica1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pMigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rols",
                c => new
                {
                    Id = c.Int(nullable: false, identity: false),
                    Nombre = c.String(maxLength: 50),
                    Usuario_Transaccion = c.String(nullable: true, defaultValue: "USER"),
                    Fecha_Transaccion = c.DateTime(nullable: true, defaultValueSql: "GETDATE()"),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Nombre, unique: true);

            CreateTable(
                "dbo.Usuarios",
                c => new
                {
                    Id = c.Int(nullable: false, identity: false),
                    RoleId = c.Int(nullable: false),
                    Nombre = c.String(nullable: false, maxLength: 50),
                    Apellido = c.String(nullable: false, maxLength: 50),
                    Cedula = c.String(maxLength: 15),
                    Usuario_Nombre = c.String(maxLength: 50),
                    Contraseña = c.String(nullable: false, maxLength: 50),
                    Fecha_Nacimiento = c.DateTime(nullable: false),
                    Usuario_Transaccion = c.String(nullable: true, defaultValue: "USER"),
                    Fecha_Transaccion = c.DateTime(nullable: true, defaultValueSql: "GETDATE()"),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rols", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.Cedula, unique: true)
                .Index(t => t.Usuario_Nombre, unique: true, name: "IX_UsuarioNombre")
                .Index(t => t.Fecha_Nacimiento);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Usuarios", "RoleId", "dbo.Rols");
            DropIndex("dbo.Usuarios", new[] { "Fecha_Nacimiento" });
            DropIndex("dbo.Usuarios", "IX_UsuarioNombre");
            DropIndex("dbo.Usuarios", new[] { "Cedula" });
            DropIndex("dbo.Usuarios", new[] { "RoleId" });
            DropIndex("dbo.Rols", new[] { "Nombre" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Rols");
        }
    }
}
