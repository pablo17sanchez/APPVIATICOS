namespace Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB")
        {
        }

        public virtual DbSet<cuentas_presupuestales> cuentas_presupuestales { get; set; }
        public virtual DbSet<Municipio> Municipios { get; set; }
        public virtual DbSet<Objetal> Objetals { get; set; }
        public virtual DbSet<Provincia> Provincias { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<formularionomina> formularionomina { get; set; }
        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<Tipo_de_cuenta> Tipo_de_cuenta { get; set; }
        public virtual DbSet<Monedas> Moneda { get; set; }
        public virtual DbSet<Funciones> Funciones { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
         public virtual DbSet<MontosViaticos> MontoViaticos { get; set; }
        // public virtual  DbSet<Departamento>Departamentos { get; set; }
        
      //  public virtual DbSet<PersonalInabie> PersonalInabiees { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            
            modelBuilder.Entity<Actividad>()
               .Property(e => e.COD_ACTIVIDAD)
               .IsUnicode(false);



            modelBuilder.Entity<Funciones>()
               .Property(e => e.CODIGO_FUNCIONES)
               .IsUnicode(false);

            modelBuilder.Entity<cuentas_presupuestales>()
                .Property(e => e.COD_CUENTA_PRESUP)
                .IsUnicode(false);
/*
            modelBuilder.Entity<cuentas_presupuestales>()
                .Property(e => e.DES_CUENTA_PRESUP)
                .IsUnicode(false);
            */
            modelBuilder.Entity<Objetal>()
                .Property(e => e.codigo_objetal)
                .IsUnicode(false);

            modelBuilder.Entity<Objetal>()
                .Property(e => e.nombre_objetal)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.COD_REGION)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.NOM_REGION)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_de_cuenta>()
              .Property(e => e.TIPO_CUENTA_CODIGO)
              .IsUnicode(false);


            modelBuilder.Entity<Monedas>()
             .Property(e => e.CODIGO_MONEDA)
             .IsUnicode(false);
            Database.SetInitializer<DB>(null);

            base.OnModelCreating(modelBuilder);
            

        }
    }
}
