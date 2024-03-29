//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace piti2013.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Pymes
    {
        public Pymes()
        {
            this.Publicidad = new HashSet<Publicidad>();
            this.Servicios = new HashSet<Servicios>();
            this.Subdominios = new HashSet<Subdominios>();
        }
    
        public int pymesID { get; set; }
        public string nombre { get; set; }
        public int usuarioID { get; set; }
        public string calle { get; set; }
        public int numero { get; set; }
        public Nullable<int> telefono { get; set; }
        public string foto { get; set; }
        public string descripcion { get; set; }
        public string denominacion { get; set; }
        public double posicionx { get; set; }
        public double posiciony { get; set; }
        public System.DateTime fechaagregado { get; set; }
        public System.DateTime fechamodificado { get; set; }
    
        public virtual ICollection<Publicidad> Publicidad { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<Servicios> Servicios { get; set; }
        public virtual ICollection<Subdominios> Subdominios { get; set; }
    }
}
