//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClanUpravnogOdbora
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClanUpravnogOdbora()
        {
            this.Upravas = new HashSet<Uprava>();
        }
    
        public int BrCK { get; set; }
        public string IP { get; set; }
        public System.DateTime DR { get; set; }
        public string SS { get; set; }
    
        public virtual GeneralniDirektor GeneralniDirektor { get; set; }
        public virtual Predsjednik Predsjednik { get; set; }
        public virtual SportskiDirektor SportskiDirektor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Uprava> Upravas { get; set; }
    }
}
