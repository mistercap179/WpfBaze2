using DataBase;
using SportskoDrustvoApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SportskoDrustvoApp.DBCrud
{
    public class Cruds : ICrud
    {
        public Conversions.Conversions conversions = new Conversions.Conversions();
        public List<Models.Igrac> citajSveIgraceTreningId(int idTrening)
        {
            List<Models.Igrac> igraci = new List<Models.Igrac>();
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Igracs.ToList().ForEach(x => {
                        if(x.Trenings.Where(t => t.IdTR == idTrening).Count() > 0)
                        {
                            igraci.Add(conversions.ConversionIgrac(x));
                        }
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return igraci;
        }

        public List<Models.SD> citajSveSd()
        {
            List<Models.SD> sportskaD = new List<Models.SD>();
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.SDs.ToList().ForEach(s => sportskaD.Add(conversions.ConversionSD(s)));
                }
            }
            catch (Exception)
            {
                throw;
            }

            return sportskaD;
        }

        public List<Models.Trener> citajSveTreneriTreningId(int idTrening)
        {
            List<Models.Trener> treneri = new List<Models.Trener>();
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Treners.ToList().ForEach(x => {
                        if (x.Trenings.Where(t => t.IdTR == idTrening).Count() > 0)
                        {
                            treneri.Add(conversions.ConversionTrener(x));
                        }
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return treneri;
        }


        public List<udfTrening_Result> treningTableCreate(int idTrening)
        {
            List<udfTrening_Result> result;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    result = db.udfTrening(idTrening).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }




        public int GetMaxManagmentId()
        {
            int ret = -1;

            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    ret = db.Upravas.Max(x => x.IdU);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }
        public int GetMaxTraningId()
        {
            int ret = -1;

            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    ret = db.Trenings.Max(x => x.IdTR);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public int GetMaxClanU()
        {
            int ret = -1;

            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    ret = db.ClanUpravnogOdboras.Max(x => x.BrCK);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public int GetMaxKlubId()
        {
            int ret = -1;

            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    ret = db.Klubs.Max(x => x.IdK);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }


        public int CreateManagement(Models.Uprava uprava)
        {
            int ret = -1;
       
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Upravas.Add(new DataBase.Uprava()
                    { 
                        LOK = uprava.SjedisteUprave,
                        OP = uprava.OpisPosla
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public int CreateSD(Models.SD sD)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.SDs.Add(new DataBase.SD()
                    {
                        NAZ = sD.Naziv,
                        SJ = sD.SjedisteSD,
                        DO = (DateTime)sD.DatumOsnivanja,
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public int CreateVlada(int idSd, int idU)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Vladas.Add(new DataBase.Vlada()
                    {
                        IdU = idU,
                        IdSD = idSd
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public int CreateSacinjava(int idSd, int idU,int idK)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Sacinjavas.Add(new DataBase.Sacinjava()
                    {
                        IdU = idU,
                        IdSD = idSd,
                        IdK = idK
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }


        public int CreateClanU(Models.ClanUpravnogOdbora clan)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    var uprava = db.Upravas.Where(x => x.IdU == clan.idUprave).FirstOrDefault();
                    List<DataBase.Uprava> upravas = new List<DataBase.Uprava>()
                    {
                        uprava
                    };
                    db.ClanUpravnogOdboras.Add(new DataBase.ClanUpravnogOdbora()
                    {
                        Upravas = upravas,
                        DR = clan.DatumRodjenja,
                        IP = clan.ImeIPrezime,
                        SS = clan.StrucnaPraksa
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public int CreatePresident(Models.Predsjednik predsjednik)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Predsjedniks.Add(new DataBase.Predsjednik()
                    {
                        BrCK = predsjednik.BrojClanskeKarte,
                        TM = predsjednik.TrajanjeMandata
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public int CreateGenDir(Models.GeneralniDirektor generalni)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.GeneralniDirektors.Add(new DataBase.GeneralniDirektor()
                    {
                        BrCK = generalni.BrojClanskeKarte,
                        US = generalni.UgovorenaSponzorstva
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public int CreateSportDir(Models.SportskiDirektor sportskiDirektor)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.SportskiDirektors.Add(new DataBase.SportskiDirektor()
                    {
                        BrCK = sportskiDirektor.BrojClanskeKarte,
                        OT = sportskiDirektor.ObavljeniTransferi
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public int CreateKLUB(Models.Klub klub)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Klubs.Add(new DataBase.Klub()
                    {
                        //IdK = klub.IdK,
                        BT = klub.BrojTitutala,
                        LIG = klub.Liga,
                        IdSD = klub.IdSD,
                        SPORT = klub.Sport
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;

        }

        public List<int?> citajSveUpraveSD(int idSd)
        {
            List<int?> uprave = new List<int?>();
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Vladas.ToList().ForEach((x) => {
                        if (x.IdSD == idSd)
                        {
                            uprave.Add(x.IdU);
                        }
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return uprave;

        }

        public int CreatePlayer(Models.Igrac igrac)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Igracs.Add(new DataBase.Igrac()
                    {
                        IdKlub = igrac.IdKlub,
                        IdSD = igrac.IdSd,
                        DR = igrac.DatumRodjenja,
                        IP = igrac.ImePrezime,
                        KA = igrac.Karijera
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;

        }

        public List<Models.Klub> citajSveKlubove(int idSd)
        {
            List<Models.Klub> klubovi = new List<Models.Klub>();
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Klubs.ToList().ForEach((x) => { 
                        if(x.IdSD == idSd)
                        {
                            klubovi.Add(conversions.ConversionKlub(x));
                        }
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return klubovi;

        }

        public int CreateCoach(Models.Trener trener)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Treners.Add(new DataBase.Trener()
                    {
                        IdKL = trener.IdKlub,
                        IdSD = trener.IdSD,
                        BRT = trener.BrojTitula,
                        IiP = trener.ImePrezime,
                        KAR = trener.Karijera
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public int CreateField(Models.Teren teren)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Terens.Add(new DataBase.Teren()
                    {
                        IdK = teren.IdKlub,
                        IdSD = teren.IdSD,
                        IST = teren.Istorijat,
                        KAP = teren.Kapacitet,
                        NAZ = teren.Naziv,
                        LOK = teren.Lokacija
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public Models.Igrac citajIgraca(int id)
        {
            Models.Igrac igrac = new Models.Igrac();
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    igrac = conversions.ConversionIgrac(db.Igracs.Where(x => x.JMBG == id).FirstOrDefault());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return igrac;
        }

        public Models.Trener citajTrenera(int id)
        {
            Models.Trener trener = new Models.Trener();
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    trener = conversions.ConversionTrener(db.Treners.Where(x => x.JMBGT == id).FirstOrDefault());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return trener;
        }

        public List<Models.Teren> citajSveTerene(int idKlub)
        {
            List<Models.Teren> tereni = new List<Models.Teren>();
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Terens.ToList().ForEach((x) => {
                        if (x.IdK == idKlub)
                        {
                            tereni.Add(conversions.ConversionTeren(x));
                        }
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return tereni;
        }

        public int CreateTrening(Models.Trening trening)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Trenings.Add(new DataBase.Trening()
                    {
                        TR = trening.Trajanje,
                        OT = trening.Opis,
                        IdT = trening.IdTeren,
                        JMBGTR = trening.Trener,
                        JMBGI = trening.Igrac
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;

        }

        public Models.Uprava citajUpravu(int idU)
        {
            Models.Uprava uprava = new Models.Uprava();
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Upravas.ToList().ForEach((x) => {
                        if (x.IdU == idU)
                        {
                            uprava = conversions.ConversionUprava(x);
                        }
                    });
                }
            }
            catch (Exception)
            {
                throw;
            }

            return uprava;

        }

        public List<Models.Trening> citajSveTreninge()
        {
            List<Models.Trening> treninzi = new List<Models.Trening>();
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Trenings.ToList().ForEach(x => treninzi.Add(conversions.ConversionTrening(x)));
                }

            }
            catch (Exception)
            {
                throw;
            }

            return treninzi;
        }

        public int DeleteUprava(int idUprava)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Upravas.ToList().ForEach((x) => {
                        if (x.IdU == idUprava)
                        {
                            db.Upravas.Remove(x);
                        }
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public int DeleteSD(int idSD)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.SDs.ToList().ForEach((x) => {
                        if (x.IdSD == idSD)
                        {
                            db.SDs.Remove(x);
                        }
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public int DeleteKlub(int idKlub)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Klubs.ToList().ForEach((x) => {
                        if (x.IdK == idKlub)
                        {
                            db.Klubs.Remove(x);
                        }
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;

        }

        public int ModifyInfoUprava(Models.Uprava uprava)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.Upravas.ToList().ForEach((x) => {
                        if (x.IdU == uprava.IdU)
                        {
                            x.LOK = uprava.SjedisteUprave;
                            x.OP = uprava.OpisPosla;
                        }
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }

        public int ModifySD(Models.SD sd)
        {
            int ret = -1;
            try
            {
                using (var db = new SportskoDrustvoEntities2())
                {
                    db.SDs.ToList().ForEach((x) => {
                        if (x.IdSD == sd.IdSD)
                        {
                            x.NAZ = sd.Naziv;
                            x.DO = (DateTime)sd.DatumOsnivanja;
                            x.SJ = sd.SjedisteSD;
                        }
                    });

                    ret = db.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ret;
        }
    }
}
