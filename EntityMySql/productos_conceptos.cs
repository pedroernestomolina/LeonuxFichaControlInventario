//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EntityMySql
{
    using System;
    using System.Collections.Generic;
    
    public partial class productos_conceptos
    {
        public productos_conceptos()
        {
            this.productos_kardex = new HashSet<productos_kardex>();
            this.productos_movimientos = new HashSet<productos_movimientos>();
        }
    
        public string auto { get; set; }
        public string codigo { get; set; }
        public string nombre { get; set; }
    
        public virtual ICollection<productos_kardex> productos_kardex { get; set; }
        public virtual ICollection<productos_movimientos> productos_movimientos { get; set; }
    }
}
