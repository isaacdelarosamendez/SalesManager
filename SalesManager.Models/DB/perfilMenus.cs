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
    
    public partial class perfilMenus
    {
        public int perfilMenuId { get; set; }
        public int id_menu { get; set; }
        public int perfilId { get; set; }
        public bool activo { get; set; }
    
        public virtual menus menus { get; set; }
        public virtual perfiles perfiles { get; set; }
    }
}
