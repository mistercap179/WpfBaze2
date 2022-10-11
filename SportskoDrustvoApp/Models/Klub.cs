using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskoDrustvoApp.Models
{
    public class Klub
    {
        public int IdK { get; set; }
        public int BrojTitutala { get; set; }
        public string Sport { get; set; }
        public string Liga { get; set; }
        public int IdSD { get; set; }
        public Uprava uprava { get; set; }
        public ICollection<Trener> treneri {get;set;}
        public ICollection<Igrac> igraci { get; set; }
        public ICollection<Teren> tereni { get; set; }

        public Klub(int idk,int brT,string sport,string liga,int idsd,
            Uprava u,ICollection<Trener> t, ICollection<Igrac> i, ICollection<Teren> te)
        {
            this.IdK = idk;
            this.BrojTitutala = brT;
            this.Sport = sport;
            this.Liga = liga;
            this.IdSD = idsd;
            this.uprava = u;
            this.treneri = t;
            this.igraci = i;
            this.tereni = te;
        }

        public Klub() { }
    }
}
