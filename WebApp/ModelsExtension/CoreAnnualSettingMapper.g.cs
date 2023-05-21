using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class CoreAnnualSettingMapper
    {
        public static CoreAnnualSettingDto AdaptToDto(this CoreAnnualSetting p1)
        {
            return p1 == null ? null : new CoreAnnualSettingDto()
            {
                SettingId = p1.SettingId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                AnneeId = p1.AnneeId,
                EtabId = p1.EtabId,
                MaxAllowPhotoLiens = p1.MaxAllowPhotoLiens,
                Copyengagements = p1.Copyengagements,
                Copymembers = p1.Copymembers,
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
                },
                Etab = p1.Etab == null ? null : new CoreEtablissementDto()
                {
                    EtabId = p1.Etab.EtabId,
                    CreateUid = p1.Etab.CreateUid,
                    UpdateUid = p1.Etab.UpdateUid,
                    CountryId = p1.Etab.CountryId,
                    Libelle = p1.Etab.Libelle,
                    Adresse = p1.Etab.Adresse,
                    Creationdate = p1.Etab.Creationdate,
                    DeployedUrl = p1.Etab.DeployedUrl,
                    DatabaseName = p1.Etab.DatabaseName,
                    ConnString = p1.Etab.ConnString,
                    EnableMultiAntenne = p1.Etab.EnableMultiAntenne,
                    Country = p1.Etab.Country == null ? null : new CoreCountryDto()
                    {
                        CountryId = p1.Etab.Country.CountryId,
                        CreateUid = p1.Etab.Country.CreateUid,
                        UpdateUid = p1.Etab.Country.UpdateUid,
                        Libelle = p1.Etab.Country.Libelle,
                        CodeIso2 = p1.Etab.Country.CodeIso2,
                        CodeIso3 = p1.Etab.Country.CodeIso3,
                        PhoneCode = p1.Etab.Country.PhoneCode,
                        Devise = p1.Etab.Country.Devise
                    }
                }
            };
        }
        public static CoreAnnualSettingDto AdaptTo(this CoreAnnualSetting p2, CoreAnnualSettingDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CoreAnnualSettingDto result = p3 ?? new CoreAnnualSettingDto();
            
            result.SettingId = p2.SettingId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.AnneeId = p2.AnneeId;
            result.EtabId = p2.EtabId;
            result.MaxAllowPhotoLiens = p2.MaxAllowPhotoLiens;
            result.Copyengagements = p2.Copyengagements;
            result.Copymembers = p2.Copymembers;
            result.Annee = funcMain1(p2.Annee, result.Annee);
            result.Etab = funcMain6(p2.Etab, result.Etab);
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
        
        private static CoreEtablissementDto funcMain6(CoreEtablissement p14, CoreEtablissementDto p15)
        {
            if (p14 == null)
            {
                return null;
            }
            CoreEtablissementDto result = p15 ?? new CoreEtablissementDto();
            
            result.EtabId = p14.EtabId;
            result.CreateUid = p14.CreateUid;
            result.UpdateUid = p14.UpdateUid;
            result.CountryId = p14.CountryId;
            result.Libelle = p14.Libelle;
            result.Adresse = p14.Adresse;
            result.Creationdate = p14.Creationdate;
            result.DeployedUrl = p14.DeployedUrl;
            result.DatabaseName = p14.DatabaseName;
            result.ConnString = p14.ConnString;
            result.EnableMultiAntenne = p14.EnableMultiAntenne;
            result.Country = funcMain7(p14.Country, result.Country);
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
        
        private static CoreCountryDto funcMain7(CoreCountry p16, CoreCountryDto p17)
        {
            if (p16 == null)
            {
                return null;
            }
            CoreCountryDto result = p17 ?? new CoreCountryDto();
            
            result.CountryId = p16.CountryId;
            result.CreateUid = p16.CreateUid;
            result.UpdateUid = p16.UpdateUid;
            result.Libelle = p16.Libelle;
            result.CodeIso2 = p16.CodeIso2;
            result.CodeIso3 = p16.CodeIso3;
            result.PhoneCode = p16.PhoneCode;
            result.Devise = p16.Devise;
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