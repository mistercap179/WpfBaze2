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
    
    public partial class Trening
    {
        public int IdTR { get; set; }
        public System.TimeSpan TR { get; set; }
        public string OT { get; set; }
        public int IdT { get; set; }
        public long JMBGTR { get; set; }
        public long JMBGI { get; set; }
    
        public virtual Igrac Igrac { get; set; }
        public virtual Teren Teren { get; set; }
        public virtual Trener Trener { get; set; }
    }
}