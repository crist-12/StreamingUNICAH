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
    using System.Collections.Generic;
    
    public partial class Paises
    {
        public Paises()
        {
            this.Estudios = new HashSet<Estudios>();
        }
    
        public byte IdPais { get; set; }
        public string NombrePais { get; set; }
        public bool EstadoPais { get; set; }
    
        public virtual ICollection<Estudios> Estudios { get; set; }
    }
}