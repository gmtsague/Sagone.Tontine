using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class MeetInscriptionMapper
    {
        public static MeetInscriptionDto AdaptToDto(this MeetInscription p1)
        {
            return p1 == null ? null : new MeetInscriptionDto()
            {
                Idinscrit = p1.Idinscrit,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                EtabId = p1.EtabId,
                AntenneId = p1.AntenneId,
                PersonId = p1.PersonId,
                AnneeId = p1.AnneeId,
                Dateinscrit = p1.Dateinscrit,
                Datesuspension = p1.Datesuspension,
                IsActive = p1.IsActive,
                Nocni = p1.Nocni,
                Soldedebut = p1.Soldedebut,
                Soldefin = p1.Soldefin,
                Tauxcotisation = p1.Tauxcotisation,
                TotalVerse = p1.TotalVerse,
                Cumuldettes = p1.Cumuldettes,
                Cumulpenalites = p1.Cumulpenalites,
                Endette = p1.Endette,
                ReportNouveau = p1.ReportNouveau,
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
                Person = p1.Person == null ? null : new CorePersonDto()
                {
                    PersonId = p1.Person.PersonId,
                    CreateUid = p1.Person.CreateUid,
                    UpdateUid = p1.Person.UpdateUid,
                    CountryId = p1.Person.CountryId,
                    EtabId = p1.Person.EtabId,
                    Nom = p1.Person.Nom,
                    Prenom = p1.Person.Prenom,
                    Datenais = p1.Person.Datenais,
                    Lieunais = p1.Person.Lieunais,
                    Sexe = p1.Person.Sexe,
                    Email = p1.Person.Email,
                    Adresse = p1.Person.Adresse,
                    AdhesionDate = p1.Person.AdhesionDate,
                    Nocni = p1.Person.Nocni,
                    CniExpireDate = p1.Person.CniExpireDate,
                    IsActive = p1.Person.IsActive,
                    IsVisible = p1.Person.IsVisible,
                    AnneePromo = p1.Person.AnneePromo,
                    Country = p1.Person.Country == null ? null : new CoreCountryDto()
                    {
                        CountryId = p1.Person.Country.CountryId,
                        CreateUid = p1.Person.Country.CreateUid,
                        UpdateUid = p1.Person.Country.UpdateUid,
                        Libelle = p1.Person.Country.Libelle,
                        CodeIso2 = p1.Person.Country.CodeIso2,
                        CodeIso3 = p1.Person.Country.CodeIso3,
                        PhoneCode = p1.Person.Country.PhoneCode,
                        Devise = p1.Person.Country.Devise
                    },
                    Etab = p1.Person.Etab == null ? null : new CoreEtablissementDto()
                    {
                        EtabId = p1.Person.Etab.EtabId,
                        CreateUid = p1.Person.Etab.CreateUid,
                        UpdateUid = p1.Person.Etab.UpdateUid,
                        CountryId = p1.Person.Etab.CountryId,
                        Libelle = p1.Person.Etab.Libelle,
                        Adresse = p1.Person.Etab.Adresse,
                        Creationdate = p1.Person.Etab.Creationdate,
                        DeployedUrl = p1.Person.Etab.DeployedUrl,
                        DatabaseName = p1.Person.Etab.DatabaseName,
                        ConnString = p1.Person.Etab.ConnString,
                        EnableMultiAntenne = p1.Person.Etab.EnableMultiAntenne,
                        Country = p1.Person.Etab.Country == null ? null : new CoreCountryDto()
                        {
                            CountryId = p1.Person.Etab.Country.CountryId,
                            CreateUid = p1.Person.Etab.Country.CreateUid,
                            UpdateUid = p1.Person.Etab.Country.UpdateUid,
                            Libelle = p1.Person.Etab.Country.Libelle,
                            CodeIso2 = p1.Person.Etab.Country.CodeIso2,
                            CodeIso3 = p1.Person.Etab.Country.CodeIso3,
                            PhoneCode = p1.Person.Etab.Country.PhoneCode,
                            Devise = p1.Person.Etab.Country.Devise
                        }
                    }
                }
            };
        }
        public static MeetInscriptionDto AdaptTo(this MeetInscription p2, MeetInscriptionDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            MeetInscriptionDto result = p3 ?? new MeetInscriptionDto();
            
            result.Idinscrit = p2.Idinscrit;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.EtabId = p2.EtabId;
            result.AntenneId = p2.AntenneId;
            result.PersonId = p2.PersonId;
            result.AnneeId = p2.AnneeId;
            result.Dateinscrit = p2.Dateinscrit;
            result.Datesuspension = p2.Datesuspension;
            result.IsActive = p2.IsActive;
            result.Nocni = p2.Nocni;
            result.Soldedebut = p2.Soldedebut;
            result.Soldefin = p2.Soldefin;
            result.Tauxcotisation = p2.Tauxcotisation;
            result.TotalVerse = p2.TotalVerse;
            result.Cumuldettes = p2.Cumuldettes;
            result.Cumulpenalites = p2.Cumulpenalites;
            result.Endette = p2.Endette;
            result.ReportNouveau = p2.ReportNouveau;
            result.Annee = funcMain1(p2.Annee, result.Annee);
            result.Person = funcMain6(p2.Person, result.Person);
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
        
        private static CorePersonDto funcMain6(CorePerson p14, CorePersonDto p15)
        {
            if (p14 == null)
            {
                return null;
            }
            CorePersonDto result = p15 ?? new CorePersonDto();
            
            result.PersonId = p14.PersonId;
            result.CreateUid = p14.CreateUid;
            result.UpdateUid = p14.UpdateUid;
            result.CountryId = p14.CountryId;
            result.EtabId = p14.EtabId;
            result.Nom = p14.Nom;
            result.Prenom = p14.Prenom;
            result.Datenais = p14.Datenais;
            result.Lieunais = p14.Lieunais;
            result.Sexe = p14.Sexe;
            result.Email = p14.Email;
            result.Adresse = p14.Adresse;
            result.AdhesionDate = p14.AdhesionDate;
            result.Nocni = p14.Nocni;
            result.CniExpireDate = p14.CniExpireDate;
            result.IsActive = p14.IsActive;
            result.IsVisible = p14.IsVisible;
            result.AnneePromo = p14.AnneePromo;
            result.Country = funcMain7(p14.Country, result.Country);
            result.Etab = funcMain8(p14.Etab, result.Etab);
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
        
        private static CoreEtablissementDto funcMain8(CoreEtablissement p18, CoreEtablissementDto p19)
        {
            if (p18 == null)
            {
                return null;
            }
            CoreEtablissementDto result = p19 ?? new CoreEtablissementDto();
            
            result.EtabId = p18.EtabId;
            result.CreateUid = p18.CreateUid;
            result.UpdateUid = p18.UpdateUid;
            result.CountryId = p18.CountryId;
            result.Libelle = p18.Libelle;
            result.Adresse = p18.Adresse;
            result.Creationdate = p18.Creationdate;
            result.DeployedUrl = p18.DeployedUrl;
            result.DatabaseName = p18.DatabaseName;
            result.ConnString = p18.ConnString;
            result.EnableMultiAntenne = p18.EnableMultiAntenne;
            result.Country = funcMain9(p18.Country, result.Country);
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
        
        private static CoreCountryDto funcMain9(CoreCountry p20, CoreCountryDto p21)
        {
            if (p20 == null)
            {
                return null;
            }
            CoreCountryDto result = p21 ?? new CoreCountryDto();
            
            result.CountryId = p20.CountryId;
            result.CreateUid = p20.CreateUid;
            result.UpdateUid = p20.UpdateUid;
            result.Libelle = p20.Libelle;
            result.CodeIso2 = p20.CodeIso2;
            result.CodeIso3 = p20.CodeIso3;
            result.PhoneCode = p20.PhoneCode;
            result.Devise = p20.Devise;
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