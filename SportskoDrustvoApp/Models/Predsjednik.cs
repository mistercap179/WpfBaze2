using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskoDrustvoApp.Models
{
    public class Predsjednik : ClanUpravnogOdbora
    {
        public string TrajanjeMandata { get; set; }

        public Predsjednik(string trajanje, int brCk, string imeP, DateTime datum, string praksa, int uprave)
            : base(brCk, imeP, datum, praksa, uprave)
        {
            this.TrajanjeMandata = trajanje;
        }
    }
}
