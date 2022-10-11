using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskoDrustvoApp
{
    public interface IConversions
    {
        Models.SD ConversionSD(DataBase.SD sD);
        Models.Uprava ConversionUprava(DataBase.Uprava uprava);
        Models.Klub ConversionKlub(DataBase.Klub klub);
        Models.ClanUpravnogOdbora ConversionClanU(DataBase.ClanUpravnogOdbora clanU);
        Models.SportskiDirektor ConversionSportskiD(DataBase.SportskiDirektor sportskiD);
        Models.GeneralniDirektor ConversionGeneralniD(DataBase.GeneralniDirektor generalniD);
        Models.Predsjednik ConversionPredsjednik(DataBase.Predsjednik predsjednik);
        Models.Igrac ConversionIgrac(DataBase.Igrac igrac);
        Models.Trener ConversionTrener(DataBase.Trener trener);
        Models.Teren ConversionTeren(DataBase.Teren teren);
        Models.Trening ConversionTrening(DataBase.Trening trening);

    }
}
