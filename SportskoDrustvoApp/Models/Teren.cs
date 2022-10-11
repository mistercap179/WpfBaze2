using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskoDrustvoApp.Models
{
    public class Teren
    {
        public int IdT { get; set; }
        public string Lokacija { get; set; }
        public string Istorijat { get; set; }
        public long Kapacitet { get; set; }
        public string Naziv { get; set; }
        public int IdKlub { get; set; }
        public int IdSD { get; set; }
        public ICollection<Trening> treninzi { get; set; }

        public Teren(int idt,string lok,string istorijat,long kap,string naz,int idK,int idsd,ICollection<Trening> trenings)
        {
            this.IdT = idt;
            this.Lokacija = lok;
            this.Istorijat = istorijat;
            this.Kapacitet = kap;
            this.Naziv = naz;
            this.IdKlub = idK;
            this.IdSD = idsd;
            this.treninzi = trenings;
        }

        public Teren() { }
    }
}
