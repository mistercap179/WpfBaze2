using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskoDrustvoApp.Models
{
    public class Trener
    {
        public long JMBGT { get; set; }
        public string ImePrezime { get; set; }
        public int BrojTitula { get; set; }
        public string Karijera { get; set; }
        public int IdKlub { get; set; }
        public int IdSD { get; set; }
        public ICollection<Trening> treninzi { get; set; }

        public Trener(long jbmgt,string imeP,int brT,string karijera,int idK,int idsd,ICollection<Trening>trenings)
        {
            this.JMBGT = jbmgt;
            this.ImePrezime = imeP;
            this.BrojTitula = brT;
            this.Karijera = karijera;
            this.IdKlub = idK;
            this.IdSD = idsd;
            this.treninzi = trenings;
        }

        public Trener() { }
    }
}
