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
    
    public partial class estados
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public estados()
        {
            this.municipios = new HashSet<municipios>();
        }
    
        public int estadoId { get; set; }
        public int paisId { get; set; }
        public string nombre { get; set; }
        public bool activo { get; set; }
    
        public virtual paises paises { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<municipios> municipios { get; set; }
    }
}