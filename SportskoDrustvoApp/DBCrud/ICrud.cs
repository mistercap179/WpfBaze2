using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportskoDrustvoApp.DBCrud
{
    public interface ICrud
    {
        List<Models.Igrac> citajSveIgraceTreningId(int idTrening);
        List<Models.Trener> citajSveTreneriTreningId(int idTrening);
        List<Models.SD> citajSveSd();
        List<int?> citajSveUpraveSD(int idSd);
        List<Models.Trening> citajSveTreninge();
        List<Models.Klub> citajSveKlubove(int idSd);

        Models.Uprava citajUpravu(int idU);
        Models.Igrac citajIgraca(int idKlub);
        Models.Trener citajTrenera(int idKlub);
        List<Models.Teren> citajSveTerene(int idKlub);

        int DeleteUprava(int idUprava);
        int DeleteSD(int idSD);
        int DeleteKlub(int idKlub);

        int ModifyInfoUprava(Models.Uprava uprava);
        int ModifySD(Models.SD sd);

        int CreateSD(Models.SD sD);
        int CreateManagement(Models.Uprava uprava);
        int CreateVlada(int idSd, int idU);
        int CreateSacinjava(int idSd, int idU, int idK);
        int CreateClanU(Models.ClanUpravnogOdbora clan);
        int CreatePresident(Models.Predsjednik predsjednik);
        int CreateGenDir(Models.GeneralniDirektor generalni);
        int CreateSportDir(Models.SportskiDirektor sportskiDirektor);
        int CreateKLUB(Models.Klub klub);
        int CreatePlayer(Models.Igrac igrac);
        int CreateCoach(Models.Trener trener);
        int CreateField(Models.Teren teren);
        int CreateTrening(Models.Trening trening);




    }
}
