//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace pryStreaingUnicah
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class StreamingUnicahEntities1 : DbContext
    {
        public StreamingUnicahEntities1()
            : base("name=StreamingUnicahEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Clasificaciones> Clasificaciones { get; set; }
        public DbSet<Estudios> Estudios { get; set; }
        public DbSet<Paises> Paises { get; set; }
        public DbSet<TiposPeliculas> TiposPeliculas { get; set; }
    }
}
