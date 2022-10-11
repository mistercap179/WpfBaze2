using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskoDrustvoApp.Conversions
{
    public class Conversions : IConversions
    {
        public Models.ClanUpravnogOdbora ConversionClanU(DataBase.ClanUpravnogOdbora clanU)
        {
            int idu = clanU.Upravas.FirstOrDefault().IdU;
            return new Models.ClanUpravnogOdbora(clanU.BrCK, clanU.IP, clanU.DR, clanU.SS, idu);
        }

        public Models.GeneralniDirektor ConversionGeneralniD(DataBase.GeneralniDirektor generalniD)
        {
            int idu = generalniD.ClanUpravnogOdbora.Upravas.FirstOrDefault().IdU;
            return new Models.GeneralniDirektor(generalniD.US, generalniD.BrCK,generalniD.ClanUpravnogOdbora.IP,
                generalniD.ClanUpravnogOdbora.DR,generalniD.ClanUpravnogOdbora.SS,idu);
        }

        public Models.Igrac ConversionIgrac(DataBase.Igrac igrac)
        {
            List<Models.Trening> treninzi = new List<Models.Trening>();
            igrac.Trenings.ToList().ForEach(x => treninzi.Add(this.ConversionTrening(x)));
            return new Models.Igrac(igrac.JMBG, igrac.IP, igrac.KA, igrac.DR, igrac.IdKlub,igrac.IdSD,treninzi);
        }

        public Models.Klub ConversionKlub(DataBase.Klub klub)
        {
            List<Models.Trener> treneri = new List<Models.Trener>();
            klub.Treners.ToList().ForEach(x => treneri.Add(this.ConversionTrener(x)));

            List<Models.Igrac> igraci = new List<Models.Igrac>();
            klub.Igracs.ToList().ForEach(x => igraci.Add(this.ConversionIgrac(x)));

            List<Models.Teren> tereni = new List<Models.Teren>();
            klub.Terens.ToList().ForEach(x => tereni.Add(this.ConversionTeren(x)));

            return new Models.Klub(klub.IdK, klub.BT, klub.SPORT, klub.LIG, klub.IdSD,
                this.ConversionUprava(klub.Sacinjavas.FirstOrDefault().Uprava), treneri, igraci, tereni);
        }

        public Models.Predsjednik ConversionPredsjednik(DataBase.Predsjednik predsjednik)
        {
            List<int> upraveID = new List<int>();
            int idu = predsjednik.ClanUpravnogOdbora.Upravas.FirstOrDefault().IdU;
            return new Models.Predsjednik(predsjednik.TM, predsjednik.BrCK, predsjednik.ClanUpravnogOdbora.IP,
                predsjednik.ClanUpravnogOdbora.DR, predsjednik.ClanUpravnogOdbora.SS, idu);
        }

        public Models.SD ConversionSD(DataBase.SD sD)
        {
            var temp = sD.Vladas.FirstOrDefault() == null ?
                null : this.ConversionUprava(sD.Vladas.FirstOrDefault().Uprava);

            return new Models.SD(sD.IdSD, sD.NAZ, sD.SJ, sD.DO, temp);
        }
        public Models.SportskiDirektor ConversionSportskiD(DataBase.SportskiDirektor sportskiD)
        {
            int idu  = sportskiD.ClanUpravnogOdbora.Upravas.FirstOrDefault().IdU;
            return new Models.SportskiDirektor(sportskiD.OT, sportskiD.BrCK, sportskiD.ClanUpravnogOdbora.IP,
                sportskiD.ClanUpravnogOdbora.DR, sportskiD.ClanUpravnogOdbora.SS, idu);
        }

        public Models.Teren ConversionTeren(DataBase.Teren teren)
        {
            List<Models.Trening> treninzi = new List<Models.Trening>();
            teren.Trenings.ToList().ForEach(x => treninzi.Add(this.ConversionTrening(x)));
            return new Models.Teren(teren.IdT, teren.LOK, teren.IST, teren.KAP, teren.NAZ, teren.IdK,teren.IdSD,treninzi);
        }

        public Models.Trener ConversionTrener(DataBase.Trener trener)
        {
            List<Models.Trening> treninzi = new List<Models.Trening>();
            trener.Trenings.ToList().ForEach(x => treninzi.Add(this.ConversionTrening(x)));
            return new Models.Trener(trener.JMBGT, trener.IiP, trener.BRT, trener.KAR, trener.IdKL,trener.IdSD,treninzi);
        }

        public Models.Trening ConversionTrening(DataBase.Trening trening)
        {
            return new Models.Trening(trening.IdTR, trening.TR, trening.OT, trening.IdT, (int)trening.Igrac.JMBG,(int)trening.Trener.JMBGT);
        }

        public Models.Uprava ConversionUprava(DataBase.Uprava uprava)
        {
            List<Models.ClanUpravnogOdbora> clanovi = new List<Models.ClanUpravnogOdbora>();
            uprava.ClanUpravnogOdboras.ToList().ForEach(x => clanovi.Add(this.ConversionClanU(x)));
            int? idk = uprava.Sacinjavas.FirstOrDefault() == null ?
                null : uprava.Sacinjavas.FirstOrDefault().IdK;

            return new Models.Uprava(clanovi, uprava.Vladas.FirstOrDefault().IdSD, idk, uprava.IdU, uprava.OP, uprava.LOK);
        }
    }
}
