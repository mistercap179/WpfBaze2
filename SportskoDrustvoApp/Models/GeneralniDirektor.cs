using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskoDrustvoApp.Models
{
    public class GeneralniDirektor : ClanUpravnogOdbora
    {
        public int UgovorenaSponzorstva { get; set; }

        public GeneralniDirektor(int sponzorstva, int brCk, string imeP, DateTime datum, string praksa, int uprave) 
                : base(brCk,imeP,datum,praksa,uprave)
        {
            this.UgovorenaSponzorstva = sponzorstva;
        }
    }
}
