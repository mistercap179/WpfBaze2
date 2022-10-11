using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskoDrustvoApp.Models
{
    public class Igrac
    {
        public long JBMG { get; set; }
        public string ImePrezime { get; set; }
        public string Karijera { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public int IdKlub { get; set; }

        public int IdSd { get; set; }
        public ICollection<Trening> treninzi { get; set; }

        public Igrac(long jmbg,string ip,string kar,DateTime datum,int idK,int idsd,ICollection<Trening> trenings)
        {
            this.JBMG = jmbg;
            this.ImePrezime = ip;
            this.Karijera = kar;
            this.DatumRodjenja = datum;
            this.IdKlub = idK;
            this.IdSd = idsd;
            this.treninzi = trenings;
        }

        public Igrac() { }
    }
}
