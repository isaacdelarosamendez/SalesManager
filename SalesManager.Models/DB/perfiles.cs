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
    
    public partial class perfiles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public perfiles()
        {
            this.usuarios = new HashSet<usuarios>();
            this.perfilMenus = new HashSet<perfilMenus>();
        }
    
        public int perfilId { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<usuarios> usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<perfilMenus> perfilMenus { get; set; }
    }
}
