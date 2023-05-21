using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class MeetEngagementMapper
    {
        public static MeetEngagementDto AdaptToDto(this MeetEngagement p1)
        {
            return p1 == null ? null : new MeetEngagementDto()
            {
                EngagementId = p1.EngagementId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                RubriqueId = p1.RubriqueId,
                PersonId = p1.PersonId,
                Cumulverse = p1.Cumulverse,
                Solde = p1.Solde,
                IsOutcome = p1.IsOutcome,
                IsClosed = p1.IsClosed,
                EngagementDate = p1.EngagementDate,
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
                },
                Rubrique = p1.Rubrique == null ? null : new MeetRubriqueDto()
                {
                    RubriqueId = p1.Rubrique.RubriqueId,
                    CreateUid = p1.Rubrique.CreateUid,
                    UpdateUid = p1.Rubrique.UpdateUid,
                    AnneeId = p1.Rubrique.AnneeId,
                    TyperubId = p1.Rubrique.TyperubId,
                    Libelle = p1.Rubrique.Libelle,
                    Nbmandataire = p1.Rubrique.Nbmandataire,
                    Montantroute = p1.Rubrique.Montantroute,
                    MontantPerson = p1.Rubrique.MontantPerson,
                    IsOutcome = p1.Rubrique.IsOutcome,
                    Commentaire = p1.Rubrique.Commentaire,
                    Annee = p1.Rubrique.Annee == null ? null : new CoreAnneeDto()
                    {
                        AnneeId = p1.Rubrique.Annee.AnneeId,
                        CreateUid = p1.Rubrique.Annee.CreateUid,
                        UpdateUid = p1.Rubrique.Annee.UpdateUid,
                        FrequenceId = p1.Rubrique.Annee.FrequenceId,
                        BureauId = p1.Rubrique.Annee.BureauId,
                        Previous = p1.Rubrique.Annee.Previous,
                        Libelle = p1.Rubrique.Annee.Libelle,
                        Datedebut = p1.Rubrique.Annee.Datedebut,
                        Datefin = p1.Rubrique.Annee.Datefin,
                        IsCurrent = p1.Rubrique.Annee.IsCurrent,
                        IsClosed = p1.Rubrique.Annee.IsClosed,
                        Nbdivision = p1.Rubrique.Annee.Nbdivision,
                        CopyDataFromPrevious = p1.Rubrique.Annee.CopyDataFromPrevious,
                        Bureau = p1.Rubrique.Annee.Bureau == null ? null : new MeetBureauDto()
                        {
                            BureauId = p1.Rubrique.Annee.Bureau.BureauId,
                            CreateUid = p1.Rubrique.Annee.Bureau.CreateUid,
                            UpdateUid = p1.Rubrique.Annee.Bureau.UpdateUid,
                            EtabId = p1.Rubrique.Annee.Bureau.EtabId,
                            Libelle = p1.Rubrique.Annee.Bureau.Libelle,
                            Debut = p1.Rubrique.Annee.Bureau.Debut,
                            Fin = p1.Rubrique.Annee.Bureau.Fin,
                            Nbperson = p1.Rubrique.Annee.Bureau.Nbperson,
                            Nbvotes = p1.Rubrique.Annee.Bureau.Nbvotes,
                            Nbabstention = p1.Rubrique.Annee.Bureau.Nbabstention,
                            Resumevote = p1.Rubrique.Annee.Bureau.Resumevote,
                            Etab = p1.Rubrique.Annee.Bureau.Etab == null ? null : new CoreEtablissementDto()
                            {
                                EtabId = p1.Rubrique.Annee.Bureau.Etab.EtabId,
                                CreateUid = p1.Rubrique.Annee.Bureau.Etab.CreateUid,
                                UpdateUid = p1.Rubrique.Annee.Bureau.Etab.UpdateUid,
                                CountryId = p1.Rubrique.Annee.Bureau.Etab.CountryId,
                                Libelle = p1.Rubrique.Annee.Bureau.Etab.Libelle,
                                Adresse = p1.Rubrique.Annee.Bureau.Etab.Adresse,
                                Creationdate = p1.Rubrique.Annee.Bureau.Etab.Creationdate,
                                DeployedUrl = p1.Rubrique.Annee.Bureau.Etab.DeployedUrl,
                                DatabaseName = p1.Rubrique.Annee.Bureau.Etab.DatabaseName,
                                ConnString = p1.Rubrique.Annee.Bureau.Etab.ConnString,
                                EnableMultiAntenne = p1.Rubrique.Annee.Bureau.Etab.EnableMultiAntenne,
                                Country = p1.Rubrique.Annee.Bureau.Etab.Country == null ? null : new CoreCountryDto()
                                {
                                    CountryId = p1.Rubrique.Annee.Bureau.Etab.Country.CountryId,
                                    CreateUid = p1.Rubrique.Annee.Bureau.Etab.Country.CreateUid,
                                    UpdateUid = p1.Rubrique.Annee.Bureau.Etab.Country.UpdateUid,
                                    Libelle = p1.Rubrique.Annee.Bureau.Etab.Country.Libelle,
                                    CodeIso2 = p1.Rubrique.Annee.Bureau.Etab.Country.CodeIso2,
                                    CodeIso3 = p1.Rubrique.Annee.Bureau.Etab.Country.CodeIso3,
                                    PhoneCode = p1.Rubrique.Annee.Bureau.Etab.Country.PhoneCode,
                                    Devise = p1.Rubrique.Annee.Bureau.Etab.Country.Devise
                                }
                            }
                        },
                        Frequence = p1.Rubrique.Annee.Frequence == null ? null : new CoreFrequenceDivisionDto()
                        {
                            FrequenceId = p1.Rubrique.Annee.Frequence.FrequenceId,
                            CreateUid = p1.Rubrique.Annee.Frequence.CreateUid,
                            UpdateUid = p1.Rubrique.Annee.Frequence.UpdateUid,
                            Libelle = p1.Rubrique.Annee.Frequence.Libelle,
                            NbDays = p1.Rubrique.Annee.Frequence.NbDays
                        }
                    },
                    Typerub = p1.Rubrique.Typerub == null ? null : new MeetTypeRubriqueDto()
                    {
                        TyperubId = p1.Rubrique.Typerub.TyperubId,
                        CreateUid = p1.Rubrique.Typerub.CreateUid,
                        UpdateUid = p1.Rubrique.Typerub.UpdateUid,
                        Libelle = p1.Rubrique.Typerub.Libelle,
                        IsOutcome = p1.Rubrique.Typerub.IsOutcome,
                        Nbmandataire = p1.Rubrique.Typerub.Nbmandataire,
                        Montantroute = p1.Rubrique.Typerub.Montantroute,
                        MontantPerson = p1.Rubrique.Typerub.MontantPerson,
                        Montantpenalite = p1.Rubrique.Typerub.Montantpenalite,
                        Code = p1.Rubrique.Typerub.Code,
                        Candelete = p1.Rubrique.Typerub.Candelete,
                        Maxsignature = p1.Rubrique.Typerub.Maxsignature,
                        AutoGenerated = p1.Rubrique.Typerub.AutoGenerated,
                        Required = p1.Rubrique.Typerub.Required,
                        IsActive = p1.Rubrique.Typerub.IsActive,
                        Numordre = p1.Rubrique.Typerub.Numordre
                    }
                }
            };
        }
        public static MeetEngagementDto AdaptTo(this MeetEngagement p2, MeetEngagementDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            MeetEngagementDto result = p3 ?? new MeetEngagementDto();
            
            result.EngagementId = p2.EngagementId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.RubriqueId = p2.RubriqueId;
            result.PersonId = p2.PersonId;
            result.Cumulverse = p2.Cumulverse;
            result.Solde = p2.Solde;
            result.IsOutcome = p2.IsOutcome;
            result.IsClosed = p2.IsClosed;
            result.EngagementDate = p2.EngagementDate;
            result.Person = funcMain1(p2.Person, result.Person);
            result.Rubrique = funcMain5(p2.Rubrique, result.Rubrique);
            return result;
            
        }
        
        private static CorePersonDto funcMain1(CorePerson p4, CorePersonDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            CorePersonDto result = p5 ?? new CorePersonDto();
            
            result.PersonId = p4.PersonId;
            result.CreateUid = p4.CreateUid;
            result.UpdateUid = p4.UpdateUid;
            result.CountryId = p4.CountryId;
            result.EtabId = p4.EtabId;
            result.Nom = p4.Nom;
            result.Prenom = p4.Prenom;
            result.Datenais = p4.Datenais;
            result.Lieunais = p4.Lieunais;
            result.Sexe = p4.Sexe;
            result.Email = p4.Email;
            result.Adresse = p4.Adresse;
            result.AdhesionDate = p4.AdhesionDate;
            result.Nocni = p4.Nocni;
            result.CniExpireDate = p4.CniExpireDate;
            result.IsActive = p4.IsActive;
            result.IsVisible = p4.IsVisible;
            result.AnneePromo = p4.AnneePromo;
            result.Country = funcMain2(p4.Country, result.Country);
            result.Etab = funcMain3(p4.Etab, result.Etab);
            return result;
            
        }
        
        private static MeetRubriqueDto funcMain5(MeetRubrique p12, MeetRubriqueDto p13)
        {
            if (p12 == null)
            {
                return null;
            }
            MeetRubriqueDto result = p13 ?? new MeetRubriqueDto();
            
            result.RubriqueId = p12.RubriqueId;
            result.CreateUid = p12.CreateUid;
            result.UpdateUid = p12.UpdateUid;
            result.AnneeId = p12.AnneeId;
            result.TyperubId = p12.TyperubId;
            result.Libelle = p12.Libelle;
            result.Nbmandataire = p12.Nbmandataire;
            result.Montantroute = p12.Montantroute;
            result.MontantPerson = p12.MontantPerson;
            result.IsOutcome = p12.IsOutcome;
            result.Commentaire = p12.Commentaire;
            result.Annee = funcMain6(p12.Annee, result.Annee);
            result.Typerub = funcMain11(p12.Typerub, result.Typerub);
            return result;
            
        }
        
        private static CoreCountryDto funcMain2(CoreCountry p6, CoreCountryDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            CoreCountryDto result = p7 ?? new CoreCountryDto();
            
            result.CountryId = p6.CountryId;
            result.CreateUid = p6.CreateUid;
            result.UpdateUid = p6.UpdateUid;
            result.Libelle = p6.Libelle;
            result.CodeIso2 = p6.CodeIso2;
            result.CodeIso3 = p6.CodeIso3;
            result.PhoneCode = p6.PhoneCode;
            result.Devise = p6.Devise;
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
        
        private static CoreAnneeDto funcMain6(CoreAnnee p14, CoreAnneeDto p15)
        {
            if (p14 == null)
            {
                return null;
            }
            CoreAnneeDto result = p15 ?? new CoreAnneeDto();
            
            result.AnneeId = p14.AnneeId;
            result.CreateUid = p14.CreateUid;
            result.UpdateUid = p14.UpdateUid;
            result.FrequenceId = p14.FrequenceId;
            result.BureauId = p14.BureauId;
            result.Previous = p14.Previous;
            result.Libelle = p14.Libelle;
            result.Datedebut = p14.Datedebut;
            result.Datefin = p14.Datefin;
            result.IsCurrent = p14.IsCurrent;
            result.IsClosed = p14.IsClosed;
            result.Nbdivision = p14.Nbdivision;
            result.CopyDataFromPrevious = p14.CopyDataFromPrevious;
            result.Bureau = funcMain7(p14.Bureau, result.Bureau);
            result.Frequence = funcMain10(p14.Frequence, result.Frequence);
            return result;
            
        }
        
        private static MeetTypeRubriqueDto funcMain11(MeetTypeRubrique p24, MeetTypeRubriqueDto p25)
        {
            if (p24 == null)
            {
                return null;
            }
            MeetTypeRubriqueDto result = p25 ?? new MeetTypeRubriqueDto();
            
            result.TyperubId = p24.TyperubId;
            result.CreateUid = p24.CreateUid;
            result.UpdateUid = p24.UpdateUid;
            result.Libelle = p24.Libelle;
            result.IsOutcome = p24.IsOutcome;
            result.Nbmandataire = p24.Nbmandataire;
            result.Montantroute = p24.Montantroute;
            result.MontantPerson = p24.MontantPerson;
            result.Montantpenalite = p24.Montantpenalite;
            result.Code = p24.Code;
            result.Candelete = p24.Candelete;
            result.Maxsignature = p24.Maxsignature;
            result.AutoGenerated = p24.AutoGenerated;
            result.Required = p24.Required;
            result.IsActive = p24.IsActive;
            result.Numordre = p24.Numordre;
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
        
        private static MeetBureauDto funcMain7(MeetBureau p16, MeetBureauDto p17)
        {
            if (p16 == null)
            {
                return null;
            }
            MeetBureauDto result = p17 ?? new MeetBureauDto();
            
            result.BureauId = p16.BureauId;
            result.CreateUid = p16.CreateUid;
            result.UpdateUid = p16.UpdateUid;
            result.EtabId = p16.EtabId;
            result.Libelle = p16.Libelle;
            result.Debut = p16.Debut;
            result.Fin = p16.Fin;
            result.Nbperson = p16.Nbperson;
            result.Nbvotes = p16.Nbvotes;
            result.Nbabstention = p16.Nbabstention;
            result.Resumevote = p16.Resumevote;
            result.Etab = funcMain8(p16.Etab, result.Etab);
            return result;
            
        }
        
        private static CoreFrequenceDivisionDto funcMain10(CoreFrequenceDivision p22, CoreFrequenceDivisionDto p23)
        {
            if (p22 == null)
            {
                return null;
            }
            CoreFrequenceDivisionDto result = p23 ?? new CoreFrequenceDivisionDto();
            
            result.FrequenceId = p22.FrequenceId;
            result.CreateUid = p22.CreateUid;
            result.UpdateUid = p22.UpdateUid;
            result.Libelle = p22.Libelle;
            result.NbDays = p22.NbDays;
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
    }
}