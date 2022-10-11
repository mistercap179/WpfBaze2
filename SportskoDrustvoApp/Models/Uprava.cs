using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskoDrustvoApp.Models
{
    public class Uprava
    {
        public ICollection<ClanUpravnogOdbora> clanovi { get; set; }
        public int IdSD { get; set; }
        public int? IdKlub { get; set; }
        public int IdU { get; set; }
        public string OpisPosla { get; set; }
        public string SjedisteUprave {get;set;}

        public Uprava(ICollection<ClanUpravnogOdbora> clans,int idsd,int? idK,int idu,string opis,string sjediste)
        {
            this.clanovi = clans;
            this.IdSD = idsd;
            this.IdKlub = idK;
            this.IdU = idu;
            this.OpisPosla = opis;
            this.SjedisteUprave = sjediste;
        }

        public Uprava() { }
    }
}
