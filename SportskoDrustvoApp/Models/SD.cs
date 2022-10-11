using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskoDrustvoApp.Models
{
    public class SD
    {
        public int IdSD { get; set; }
        public string Naziv { get; set; }
        public string SjedisteSD { get; set; }
        public DateTime? DatumOsnivanja {get ; set; } 
        public Uprava Uprava { get; set; }

        public SD(int idsd,string naz,string sjediste,DateTime? datumO,Uprava uprava = null)
        {
            this.IdSD = idsd;
            this.Naziv = naz;
            this.SjedisteSD = sjediste;
            this.DatumOsnivanja = datumO;
            this.Uprava = uprava;
        }
    }
}
