using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskoDrustvoApp.Models
{
    public class Trening
    {
        public int IdTR { get; set; }
        public TimeSpan Trajanje { get; set; }
        public string Opis { get; set; }
        public int IdTeren { get; set; }
        public int Igrac { get; set; }
        public int Trener { get; set; }

        public Trening(int idt,TimeSpan trajanje,string opis,int idTeren,int igrac,int trener)
        {
            this.IdTR = idt;
            this.Trajanje = trajanje;
            this.Opis = opis;
            this.IdTeren = idTeren;
            this.Igrac = igrac;
            this.Trener = trener;
        }

        public Trening() { }
    }
}
