//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SalesManager.Models.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class clientes
    {
        public decimal clienteId { get; set; }
        public string nombre { get; set; }
        public string razonSocial { get; set; }
        public decimal margen { get; set; }
        public decimal monto { get; set; }
        public string direccion { get; set; }
        public Nullable<int> municipioId { get; set; }
        public string observaciones { get; set; }
        public bool esProspecto { get; set; }
        public Nullable<double> ubicacion { get; set; }
        public decimal usuarioId { get; set; }
        public bool activo { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public Nullable<double> latitud { get; set; }
        public Nullable<double> longitud { get; set; }
    
        public virtual municipios municipios { get; set; }
        public virtual usuarios usuarios { get; set; }
    }
}
