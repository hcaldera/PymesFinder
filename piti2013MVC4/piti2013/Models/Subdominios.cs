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
    
    public partial class Subdominios
    {
        public int subdominiosID { get; set; }
        public int pymesID { get; set; }
        public int estatusID { get; set; }
        public string url { get; set; }
        public System.DateTime fechaagregado { get; set; }
        public System.DateTime fechamodificado { get; set; }
    
        public virtual Estatus Estatus { get; set; }
        public virtual Pymes Pymes { get; set; }
    }
}
