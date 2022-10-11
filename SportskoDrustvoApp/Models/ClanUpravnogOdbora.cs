using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskoDrustvoApp.Models
{
    public class ClanUpravnogOdbora
    {
        public int BrojClanskeKarte { get; set; }
        public string ImeIPrezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string StrucnaPraksa { get; set; }
        public int idUprave { get; set; } 

        public ClanUpravnogOdbora(int brClKr,string imePrezime,DateTime datumR,string praksa,int uprave)
        {
            this.BrojClanskeKarte = brClKr;
            this.ImeIPrezime = imePrezime;
            this.DatumRodjenja = datumR;
            this.StrucnaPraksa = praksa;
            this.idUprave = uprave;
        }
    }
}
