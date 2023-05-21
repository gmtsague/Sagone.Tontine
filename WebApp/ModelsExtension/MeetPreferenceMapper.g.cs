using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class MeetPreferenceMapper
    {
        public static MeetPreferenceDto AdaptToDto(this MeetPreference p1)
        {
            return p1 == null ? null : new MeetPreferenceDto()
            {
                SettingId = p1.SettingId,
                TauxInteretMensuel = p1.TauxInteretMensuel,
                TauxInteretPenalite = p1.TauxInteretPenalite,
                TauxPenaliteCotisation = p1.TauxPenaliteCotisation,
                EnableAutoGenPresence = p1.EnableAutoGenPresence,
                EnableSigningOutcome = p1.EnableSigningOutcome,
                EnableMaxDelayPenalites = p1.EnableMaxDelayPenalites,
                EnableAutoDispatchIncome = p1.EnableAutoDispatchIncome,
                EnableFixedAmountFees = p1.EnableFixedAmountFees,
                EnableSecoursInsurance = p1.EnableSecoursInsurance,
                EnableFixedFeesByAnten = p1.EnableFixedFeesByAnten,
                Setting = p1.Setting == null ? null : new CoreAnnualSettingDto()
                {
                    SettingId = p1.Setting.SettingId,
                    CreateUid = p1.Setting.CreateUid,
                    UpdateUid = p1.Setting.UpdateUid,
                    AnneeId = p1.Setting.AnneeId,
                    EtabId = p1.Setting.EtabId,
                    MaxAllowPhotoLiens = p1.Setting.MaxAllowPhotoLiens,
                    Copyengagements = p1.Setting.Copyengagements,
                    Copymembers = p1.Setting.Copymembers,
                    Annee = p1.Setting.Annee == null ? null : new CoreAnneeDto()
                    {
                        AnneeId = p1.Setting.Annee.AnneeId,
                        CreateUid = p1.Setting.Annee.CreateUid,
                        UpdateUid = p1.Setting.Annee.UpdateUid,
                        FrequenceId = p1.Setting.Annee.FrequenceId,
                        BureauId = p1.Setting.Annee.BureauId,
                        Previous = p1.Setting.Annee.Previous,
                        Libelle = p1.Setting.Annee.Libelle,
                        Datedebut = p1.Setting.Annee.Datedebut,
                        Datefin = p1.Setting.Annee.Datefin,
                        IsCurrent = p1.Setting.Annee.IsCurrent,
                        IsClosed = p1.Setting.Annee.IsClosed,
                        Nbdivision = p1.Setting.Annee.Nbdivision,
                        CopyDataFromPrevious = p1.Setting.Annee.CopyDataFromPrevious,
                        Bureau = p1.Setting.Annee.Bureau == null ? null : new MeetBureauDto()
                        {
                            BureauId = p1.Setting.Annee.Bureau.BureauId,
                            CreateUid = p1.Setting.Annee.Bureau.CreateUid,
                            UpdateUid = p1.Setting.Annee.Bureau.UpdateUid,
                            EtabId = p1.Setting.Annee.Bureau.EtabId,
                            Libelle = p1.Setting.Annee.Bureau.Libelle,
                            Debut = p1.Setting.Annee.Bureau.Debut,
                            Fin = p1.Setting.Annee.Bureau.Fin,
                            Nbperson = p1.Setting.Annee.Bureau.Nbperson,
                            Nbvotes = p1.Setting.Annee.Bureau.Nbvotes,
                            Nbabstention = p1.Setting.Annee.Bureau.Nbabstention,
                            Resumevote = p1.Setting.Annee.Bureau.Resumevote,
                            Etab = p1.Setting.Annee.Bureau.Etab == null ? null : new CoreEtablissementDto()
                            {
                                EtabId = p1.Setting.Annee.Bureau.Etab.EtabId,
                                CreateUid = p1.Setting.Annee.Bureau.Etab.CreateUid,
                                UpdateUid = p1.Setting.Annee.Bureau.Etab.UpdateUid,
                                CountryId = p1.Setting.Annee.Bureau.Etab.CountryId,
                                Libelle = p1.Setting.Annee.Bureau.Etab.Libelle,
                                Adresse = p1.Setting.Annee.Bureau.Etab.Adresse,
                                Creationdate = p1.Setting.Annee.Bureau.Etab.Creationdate,
                                DeployedUrl = p1.Setting.Annee.Bureau.Etab.DeployedUrl,
                                DatabaseName = p1.Setting.Annee.Bureau.Etab.DatabaseName,
                                ConnString = p1.Setting.Annee.Bureau.Etab.ConnString,
                                EnableMultiAntenne = p1.Setting.Annee.Bureau.Etab.EnableMultiAntenne,
                                Country = p1.Setting.Annee.Bureau.Etab.Country == null ? null : new CoreCountryDto()
                                {
                                    CountryId = p1.Setting.Annee.Bureau.Etab.Country.CountryId,
                                    CreateUid = p1.Setting.Annee.Bureau.Etab.Country.CreateUid,
                                    UpdateUid = p1.Setting.Annee.Bureau.Etab.Country.UpdateUid,
                                    Libelle = p1.Setting.Annee.Bureau.Etab.Country.Libelle,
                                    CodeIso2 = p1.Setting.Annee.Bureau.Etab.Country.CodeIso2,
                                    CodeIso3 = p1.Setting.Annee.Bureau.Etab.Country.CodeIso3,
                                    PhoneCode = p1.Setting.Annee.Bureau.Etab.Country.PhoneCode,
                                    Devise = p1.Setting.Annee.Bureau.Etab.Country.Devise
                                }
                            }
                        },
                        Frequence = p1.Setting.Annee.Frequence == null ? null : new CoreFrequenceDivisionDto()
                        {
                            FrequenceId = p1.Setting.Annee.Frequence.FrequenceId,
                            CreateUid = p1.Setting.Annee.Frequence.CreateUid,
                            UpdateUid = p1.Setting.Annee.Frequence.UpdateUid,
                            Libelle = p1.Setting.Annee.Frequence.Libelle,
                            NbDays = p1.Setting.Annee.Frequence.NbDays
                        }
                    },
                    Etab = p1.Setting.Etab == null ? null : new CoreEtablissementDto()
                    {
                        EtabId = p1.Setting.Etab.EtabId,
                        CreateUid = p1.Setting.Etab.CreateUid,
                        UpdateUid = p1.Setting.Etab.UpdateUid,
                        CountryId = p1.Setting.Etab.CountryId,
                        Libelle = p1.Setting.Etab.Libelle,
                        Adresse = p1.Setting.Etab.Adresse,
                        Creationdate = p1.Setting.Etab.Creationdate,
                        DeployedUrl = p1.Setting.Etab.DeployedUrl,
                        DatabaseName = p1.Setting.Etab.DatabaseName,
                        ConnString = p1.Setting.Etab.ConnString,
                        EnableMultiAntenne = p1.Setting.Etab.EnableMultiAntenne,
                        Country = p1.Setting.Etab.Country == null ? null : new CoreCountryDto()
                        {
                            CountryId = p1.Setting.Etab.Country.CountryId,
                            CreateUid = p1.Setting.Etab.Country.CreateUid,
                            UpdateUid = p1.Setting.Etab.Country.UpdateUid,
                            Libelle = p1.Setting.Etab.Country.Libelle,
                            CodeIso2 = p1.Setting.Etab.Country.CodeIso2,
                            CodeIso3 = p1.Setting.Etab.Country.CodeIso3,
                            PhoneCode = p1.Setting.Etab.Country.PhoneCode,
                            Devise = p1.Setting.Etab.Country.Devise
                        }
                    }
                }
            };
        }
        public static MeetPreferenceDto AdaptTo(this MeetPreference p2, MeetPreferenceDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            MeetPreferenceDto result = p3 ?? new MeetPreferenceDto();
            
            result.SettingId = p2.SettingId;
            result.TauxInteretMensuel = p2.TauxInteretMensuel;
            result.TauxInteretPenalite = p2.TauxInteretPenalite;
            result.TauxPenaliteCotisation = p2.TauxPenaliteCotisation;
            result.EnableAutoGenPresence = p2.EnableAutoGenPresence;
            result.EnableSigningOutcome = p2.EnableSigningOutcome;
            result.EnableMaxDelayPenalites = p2.EnableMaxDelayPenalites;
            result.EnableAutoDispatchIncome = p2.EnableAutoDispatchIncome;
            result.EnableFixedAmountFees = p2.EnableFixedAmountFees;
            result.EnableSecoursInsurance = p2.EnableSecoursInsurance;
            result.EnableFixedFeesByAnten = p2.EnableFixedFeesByAnten;
            result.Setting = funcMain1(p2.Setting, result.Setting);
            return result;
            
        }
        
        private static CoreAnnualSettingDto funcMain1(CoreAnnualSetting p4, CoreAnnualSettingDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            CoreAnnualSettingDto result = p5 ?? new CoreAnnualSettingDto();
            
            result.SettingId = p4.SettingId;
            result.CreateUid = p4.CreateUid;
            result.UpdateUid = p4.UpdateUid;
            result.AnneeId = p4.AnneeId;
            result.EtabId = p4.EtabId;
            result.MaxAllowPhotoLiens = p4.MaxAllowPhotoLiens;
            result.Copyengagements = p4.Copyengagements;
            result.Copymembers = p4.Copymembers;
            result.Annee = funcMain2(p4.Annee, result.Annee);
            result.Etab = funcMain7(p4.Etab, result.Etab);
            return result;
            
        }
        
        private static CoreAnneeDto funcMain2(CoreAnnee p6, CoreAnneeDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            CoreAnneeDto result = p7 ?? new CoreAnneeDto();
            
            result.AnneeId = p6.AnneeId;
            result.CreateUid = p6.CreateUid;
            result.UpdateUid = p6.UpdateUid;
            result.FrequenceId = p6.FrequenceId;
            result.BureauId = p6.BureauId;
            result.Previous = p6.Previous;
            result.Libelle = p6.Libelle;
            result.Datedebut = p6.Datedebut;
            result.Datefin = p6.Datefin;
            result.IsCurrent = p6.IsCurrent;
            result.IsClosed = p6.IsClosed;
            result.Nbdivision = p6.Nbdivision;
            result.CopyDataFromPrevious = p6.CopyDataFromPrevious;
            result.Bureau = funcMain3(p6.Bureau, result.Bureau);
            result.Frequence = funcMain6(p6.Frequence, result.Frequence);
            return result;
            
        }
        
        private static CoreEtablissementDto funcMain7(CoreEtablissement p16, CoreEtablissementDto p17)
        {
            if (p16 == null)
            {
                return null;
            }
            CoreEtablissementDto result = p17 ?? new CoreEtablissementDto();
            
            result.EtabId = p16.EtabId;
            result.CreateUid = p16.CreateUid;
            result.UpdateUid = p16.UpdateUid;
            result.CountryId = p16.CountryId;
            result.Libelle = p16.Libelle;
            result.Adresse = p16.Adresse;
            result.Creationdate = p16.Creationdate;
            result.DeployedUrl = p16.DeployedUrl;
            result.DatabaseName = p16.DatabaseName;
            result.ConnString = p16.ConnString;
            result.EnableMultiAntenne = p16.EnableMultiAntenne;
            result.Country = funcMain8(p16.Country, result.Country);
            return result;
            
        }
        
        private static MeetBureauDto funcMain3(MeetBureau p8, MeetBureauDto p9)
        {
            if (p8 == null)
            {
                return null;
            }
            MeetBureauDto result = p9 ?? new MeetBureauDto();
            
            result.BureauId = p8.BureauId;
            result.CreateUid = p8.CreateUid;
            result.UpdateUid = p8.UpdateUid;
            result.EtabId = p8.EtabId;
            result.Libelle = p8.Libelle;
            result.Debut = p8.Debut;
            result.Fin = p8.Fin;
            result.Nbperson = p8.Nbperson;
            result.Nbvotes = p8.Nbvotes;
            result.Nbabstention = p8.Nbabstention;
            result.Resumevote = p8.Resumevote;
            result.Etab = funcMain4(p8.Etab, result.Etab);
            return result;
            
        }
        
        private static CoreFrequenceDivisionDto funcMain6(CoreFrequenceDivision p14, CoreFrequenceDivisionDto p15)
        {
            if (p14 == null)
            {
                return null;
            }
            CoreFrequenceDivisionDto result = p15 ?? new CoreFrequenceDivisionDto();
            
            result.FrequenceId = p14.FrequenceId;
            result.CreateUid = p14.CreateUid;
            result.UpdateUid = p14.UpdateUid;
            result.Libelle = p14.Libelle;
            result.NbDays = p14.NbDays;
            return result;
            
        }
        
        private static CoreCountryDto funcMain8(CoreCountry p18, CoreCountryDto p19)
        {
            if (p18 == null)
            {
                return null;
            }
            CoreCountryDto result = p19 ?? new CoreCountryDto();
            
            result.CountryId = p18.CountryId;
            result.CreateUid = p18.CreateUid;
            result.UpdateUid = p18.UpdateUid;
            result.Libelle = p18.Libelle;
            result.CodeIso2 = p18.CodeIso2;
            result.CodeIso3 = p18.CodeIso3;
            result.PhoneCode = p18.PhoneCode;
            result.Devise = p18.Devise;
            return result;
            
        }
        
        private static CoreEtablissementDto funcMain4(CoreEtablissement p10, CoreEtablissementDto p11)
        {
            if (p10 == null)
            {
                return null;
            }
            CoreEtablissementDto result = p11 ?? new CoreEtablissementDto();
            
            result.EtabId = p10.EtabId;
            result.CreateUid = p10.CreateUid;
            result.UpdateUid = p10.UpdateUid;
            result.CountryId = p10.CountryId;
            result.Libelle = p10.Libelle;
            result.Adresse = p10.Adresse;
            result.Creationdate = p10.Creationdate;
            result.DeployedUrl = p10.DeployedUrl;
            result.DatabaseName = p10.DatabaseName;
            result.ConnString = p10.ConnString;
            result.EnableMultiAntenne = p10.EnableMultiAntenne;
            result.Country = funcMain5(p10.Country, result.Country);
            return result;
            
        }
        
        private static CoreCountryDto funcMain5(CoreCountry p12, CoreCountryDto p13)
        {
            if (p12 == null)
            {
                return null;
            }
            CoreCountryDto result = p13 ?? new CoreCountryDto();
            
            result.CountryId = p12.CountryId;
            result.CreateUid = p12.CreateUid;
            result.UpdateUid = p12.UpdateUid;
            result.Libelle = p12.Libelle;
            result.CodeIso2 = p12.CodeIso2;
            result.CodeIso3 = p12.CodeIso3;
            result.PhoneCode = p12.PhoneCode;
            result.Devise = p12.Devise;
            return result;
            
        }
    }
}