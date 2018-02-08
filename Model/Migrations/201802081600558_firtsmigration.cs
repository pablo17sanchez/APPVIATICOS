namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class firtsmigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actividads",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        COD_ACTIVIDAD = c.String(maxLength: 255, unicode: false),
                        DESC_ACTIVIDAD = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.cuentas_presupuestales",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        COD_CUENTA_PRESUP = c.String(maxLength: 12, unicode: false),
                        DES_CUENTA_PRESUP = c.String(maxLength: 45),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.formularionominas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identificacion = c.String(nullable: false, maxLength: 12),
                        Tipo_identificacion = c.String(),
                        Capitulo = c.String(),
                        Subcapitulo = c.String(),
                        DAF = c.String(),
                        UE = c.String(),
                        Programa = c.String(),
                        Subprograma = c.String(),
                        Proyecto = c.String(),
                        Actividad = c.String(maxLength: 20),
                        Objeto = c.String(),
                        Fondo = c.String(),
                        Organismo_Financiador = c.String(maxLength: 5),
                        Tarjeta = c.String(nullable: false),
                        codigo_del_banco = c.String(nullable: false),
                        tipo_de_cuenta = c.String(),
                        Nodecuentabancaria = c.String(nullable: false),
                        Codigo_de_moneda = c.String(),
                        FechaActual = c.DateTime(),
                        Beneficiario = c.String(nullable: false, maxLength: 37),
                        Cargo = c.String(nullable: false, maxLength: 37),
                        Concepto = c.String(),
                        Cedula = c.String(),
                        FechaNomina = c.DateTime(precision: 7, storeType: "datetime2"),
                        NombredelDepartamento = c.String(nullable: false),
                        Codigodepartamento = c.String(nullable: false),
                        Codigocargo = c.Int(nullable: false),
                        Region = c.String(nullable: false),
                        Provincia = c.String(nullable: false),
                        Municipio = c.String(nullable: false),
                        Funcion = c.Int(nullable: false),
                        MontoViatico = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CCP = c.Int(nullable: false),
                        userid = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuario", t => t.userid, cascadeDelete: true)
                .Index(t => t.userid);
            
            CreateTable(
                "dbo.Usuario",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                        Apellido = c.String(nullable: false, maxLength: 100),
                        Username = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 32),
                        Cedula = c.String(maxLength: 11),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Funciones",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CODIGO_FUNCIONES = c.String(maxLength: 10, unicode: false),
                        DESCRIPCION_FUNCION = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Monedas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CODIGO_MONEDA = c.String(maxLength: 10, unicode: false),
                        MONEDA_DESCRIPCION = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.MontosViaticos",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        CODIGODEGRUPO = c.Int(nullable: false),
                        MONTO = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Municipios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        COD_REGION = c.String(maxLength: 10),
                        COD_PROVINCIA = c.String(maxLength: 10),
                        COD_MUNICIPIO = c.String(maxLength: 10),
                        NOM_MUNICIPIO = c.String(maxLength: 80),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Objetal",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        codigo_objetal = c.String(nullable: false, maxLength: 10, unicode: false),
                        nombre_objetal = c.String(nullable: false, maxLength: 45, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Personals",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Cedula = c.String(maxLength: 11),
                        NombreYApellido = c.String(maxLength: 80),
                        CuentaBancaria = c.String(maxLength: 40),
                        Cargo = c.String(maxLength: 40),
                        Departamento = c.String(nullable: false, maxLength: 40),
                        grupo_ocupacional = c.String(maxLength: 40),
                        Codigo_de_grupo_ocupacional = c.Int(nullable: false),
                        MontoViaticos = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Provincias",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        COD_REGION = c.String(nullable: false, maxLength: 10),
                        COD_PROVINCIA = c.String(nullable: false, maxLength: 10),
                        NOM_PROVINCIA = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        COD_REGION = c.String(maxLength: 10, unicode: false),
                        NOM_REGION = c.String(maxLength: 80, unicode: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Tipo_de_cuenta",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        TIPO_CUENTA_CODIGO = c.String(maxLength: 255, unicode: false),
                        TIPO_DESCRICION = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.formularionominas", "userid", "dbo.Usuario");
            DropIndex("dbo.formularionominas", new[] { "userid" });
            DropTable("dbo.Tipo_de_cuenta");
            DropTable("dbo.Region");
            DropTable("dbo.Provincias");
            DropTable("dbo.Personals");
            DropTable("dbo.Objetal");
            DropTable("dbo.Municipios");
            DropTable("dbo.MontosViaticos");
            DropTable("dbo.Monedas");
            DropTable("dbo.Funciones");
            DropTable("dbo.Usuario");
            DropTable("dbo.formularionominas");
            DropTable("dbo.cuentas_presupuestales");
            DropTable("dbo.Actividads");
        }
    }
}
