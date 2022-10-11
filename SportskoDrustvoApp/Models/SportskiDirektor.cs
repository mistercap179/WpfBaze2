using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskoDrustvoApp.Models
{
    public class SportskiDirektor : ClanUpravnogOdbora
    {
        public int? ObavljeniTransferi { get; set; }
        public SportskiDirektor(int? obavljeniT,int brCk, string imeP, DateTime datum, string praksa, int uprave)
            : base(brCk, imeP, datum, praksa, uprave)
        {
            this.ObavljeniTransferi = obavljeniT;
        }

    }
}
