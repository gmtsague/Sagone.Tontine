using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class CoreSubdivisionMapper
    {
        public static CoreSubdivisionDto AdaptToDto(this CoreSubdivision p1)
        {
            return p1 == null ? null : new CoreSubdivisionDto()
            {
                AnneeId = p1.AnneeId,
                DivisionId = p1.DivisionId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                Libelle = p1.Libelle,
                MonthDate = p1.MonthDate,
                MonthDay = p1.MonthDay,
                Numordre = p1.Numordre,
                Annee = p1.Annee == null ? null : new CoreAnneeDto()
                {
                    AnneeId = p1.Annee.AnneeId,
                    CreateUid = p1.Annee.CreateUid,
                    UpdateUid = p1.Annee.UpdateUid,
                    FrequenceId = p1.Annee.FrequenceId,
                    BureauId = p1.Annee.BureauId,
                    Previous = p1.Annee.Previous,
                    Libelle = p1.Annee.Libelle,
                    Datedebut = p1.Annee.Datedebut,
                    Datefin = p1.Annee.Datefin,
                    IsCurrent = p1.Annee.IsCurrent,
                    IsClosed = p1.Annee.IsClosed,
                    Nbdivision = p1.Annee.Nbdivision,
                    CopyDataFromPrevious = p1.Annee.CopyDataFromPrevious,
                    Bureau = p1.Annee.Bureau == null ? null : new MeetBureauDto()
                    {
                        BureauId = p1.Annee.Bureau.BureauId,
                        CreateUid = p1.Annee.Bureau.CreateUid,
                        UpdateUid = p1.Annee.Bureau.UpdateUid,
                        EtabId = p1.Annee.Bureau.EtabId,
                        Libelle = p1.Annee.Bureau.Libelle,
                        Debut = p1.Annee.Bureau.Debut,
                        Fin = p1.Annee.Bureau.Fin,
                        Nbperson = p1.Annee.Bureau.Nbperson,
                        Nbvotes = p1.Annee.Bureau.Nbvotes,
                        Nbabstention = p1.Annee.Bureau.Nbabstention,
                        Resumevote = p1.Annee.Bureau.Resumevote,
                        Etab = p1.Annee.Bureau.Etab == null ? null : new CoreEtablissementDto()
                        {
                            EtabId = p1.Annee.Bureau.Etab.EtabId,
                            CreateUid = p1.Annee.Bureau.Etab.CreateUid,
                            UpdateUid = p1.Annee.Bureau.Etab.UpdateUid,
                            CountryId = p1.Annee.Bureau.Etab.CountryId,
                            Libelle = p1.Annee.Bureau.Etab.Libelle,
                            Adresse = p1.Annee.Bureau.Etab.Adresse,
                            Creationdate = p1.Annee.Bureau.Etab.Creationdate,
                            DeployedUrl = p1.Annee.Bureau.Etab.DeployedUrl,
                            DatabaseName = p1.Annee.Bureau.Etab.DatabaseName,
                            ConnString = p1.Annee.Bureau.Etab.ConnString,
                            EnableMultiAntenne = p1.Annee.Bureau.Etab.EnableMultiAntenne,
                            Country = p1.Annee.Bureau.Etab.Country == null ? null : new CoreCountryDto()
                            {
                                CountryId = p1.Annee.Bureau.Etab.Country.CountryId,
                                CreateUid = p1.Annee.Bureau.Etab.Country.CreateUid,
                                UpdateUid = p1.Annee.Bureau.Etab.Country.UpdateUid,
                                Libelle = p1.Annee.Bureau.Etab.Country.Libelle,
                                CodeIso2 = p1.Annee.Bureau.Etab.Country.CodeIso2,
                                CodeIso3 = p1.Annee.Bureau.Etab.Country.CodeIso3,
                                PhoneCode = p1.Annee.Bureau.Etab.Country.PhoneCode,
                                Devise = p1.Annee.Bureau.Etab.Country.Devise
                            }
                        }
                    },
                    Frequence = p1.Annee.Frequence == null ? null : new CoreFrequenceDivisionDto()
                    {
                        FrequenceId = p1.Annee.Frequence.FrequenceId,
                        CreateUid = p1.Annee.Frequence.CreateUid,
                        UpdateUid = p1.Annee.Frequence.UpdateUid,
                        Libelle = p1.Annee.Frequence.Libelle,
                        NbDays = p1.Annee.Frequence.NbDays
                    }
                }
            };
        }
        public static CoreSubdivisionDto AdaptTo(this CoreSubdivision p2, CoreSubdivisionDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CoreSubdivisionDto result = p3 ?? new CoreSubdivisionDto();
            
            result.AnneeId = p2.AnneeId;
            result.DivisionId = p2.DivisionId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.Libelle = p2.Libelle;
            result.MonthDate = p2.MonthDate;
            result.MonthDay = p2.MonthDay;
            result.Numordre = p2.Numordre;
            result.Annee = funcMain1(p2.Annee, result.Annee);
            return result;
            
        }
        
        private static CoreAnneeDto funcMain1(CoreAnnee p4, CoreAnneeDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            CoreAnneeDto result = p5 ?? new CoreAnneeDto();
            
            result.AnneeId = p4.AnneeId;
            result.CreateUid = p4.CreateUid;
            result.UpdateUid = p4.UpdateUid;
            result.FrequenceId = p4.FrequenceId;
            result.BureauId = p4.BureauId;
            result.Previous = p4.Previous;
            result.Libelle = p4.Libelle;
            result.Datedebut = p4.Datedebut;
            result.Datefin = p4.Datefin;
            result.IsCurrent = p4.IsCurrent;
            result.IsClosed = p4.IsClosed;
            result.Nbdivision = p4.Nbdivision;
            result.CopyDataFromPrevious = p4.CopyDataFromPrevious;
            result.Bureau = funcMain2(p4.Bureau, result.Bureau);
            result.Frequence = funcMain5(p4.Frequence, result.Frequence);
            return result;
            
        }
        
        private static MeetBureauDto funcMain2(MeetBureau p6, MeetBureauDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            MeetBureauDto result = p7 ?? new MeetBureauDto();
            
            result.BureauId = p6.BureauId;
            result.CreateUid = p6.CreateUid;
            result.UpdateUid = p6.UpdateUid;
            result.EtabId = p6.EtabId;
            result.Libelle = p6.Libelle;
            result.Debut = p6.Debut;
            result.Fin = p6.Fin;
            result.Nbperson = p6.Nbperson;
            result.Nbvotes = p6.Nbvotes;
            result.Nbabstention = p6.Nbabstention;
            result.Resumevote = p6.Resumevote;
            result.Etab = funcMain3(p6.Etab, result.Etab);
            return result;
            
        }
        
        private static CoreFrequenceDivisionDto funcMain5(CoreFrequenceDivision p12, CoreFrequenceDivisionDto p13)
        {
            if (p12 == null)
            {
                return null;
            }
            CoreFrequenceDivisionDto result = p13 ?? new CoreFrequenceDivisionDto();
            
            result.FrequenceId = p12.FrequenceId;
            result.CreateUid = p12.CreateUid;
            result.UpdateUid = p12.UpdateUid;
            result.Libelle = p12.Libelle;
            result.NbDays = p12.NbDays;
            return result;
            
        }
        
        private static CoreEtablissementDto funcMain3(CoreEtablissement p8, CoreEtablissementDto p9)
        {
            if (p8 == null)
            {
                return null;
            }
            CoreEtablissementDto result = p9 ?? new CoreEtablissementDto();
            
            result.EtabId = p8.EtabId;
            result.CreateUid = p8.CreateUid;
            result.UpdateUid = p8.UpdateUid;
            result.CountryId = p8.CountryId;
            result.Libelle = p8.Libelle;
            result.Adresse = p8.Adresse;
            result.Creationdate = p8.Creationdate;
            result.DeployedUrl = p8.DeployedUrl;
            result.DatabaseName = p8.DatabaseName;
            result.ConnString = p8.ConnString;
            result.EnableMultiAntenne = p8.EnableMultiAntenne;
            result.Country = funcMain4(p8.Country, result.Country);
            return result;
            
        }
        
        private static CoreCountryDto funcMain4(CoreCountry p10, CoreCountryDto p11)
        {
            if (p10 == null)
            {
                return null;
            }
            CoreCountryDto result = p11 ?? new CoreCountryDto();
            
            result.CountryId = p10.CountryId;
            result.CreateUid = p10.CreateUid;
            result.UpdateUid = p10.UpdateUid;
            result.Libelle = p10.Libelle;
            result.CodeIso2 = p10.CodeIso2;
            result.CodeIso3 = p10.CodeIso3;
            result.PhoneCode = p10.PhoneCode;
            result.Devise = p10.Devise;
            return result;
            
        }
    }
}