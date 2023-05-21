using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class MeetEntreeCaisseMapper
    {
        public static MeetEntreeCaisseDto AdaptToDto(this MeetEntreeCaisse p1)
        {
            return p1 == null ? null : new MeetEntreeCaisseDto()
            {
                OperationId = p1.OperationId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                PresenceId = p1.PresenceId,
                EngagementId = p1.EngagementId,
                ModepaieId = p1.ModepaieId,
                Montantverse = p1.Montantverse,
                IsOutcome = p1.IsOutcome,
                Engagement = p1.Engagement == null ? null : new MeetEngagementDto()
                {
                    EngagementId = p1.Engagement.EngagementId,
                    CreateUid = p1.Engagement.CreateUid,
                    UpdateUid = p1.Engagement.UpdateUid,
                    RubriqueId = p1.Engagement.RubriqueId,
                    PersonId = p1.Engagement.PersonId,
                    Cumulverse = p1.Engagement.Cumulverse,
                    Solde = p1.Engagement.Solde,
                    IsOutcome = p1.Engagement.IsOutcome,
                    IsClosed = p1.Engagement.IsClosed,
                    EngagementDate = p1.Engagement.EngagementDate,
                    Person = p1.Engagement.Person == null ? null : new CorePersonDto()
                    {
                        PersonId = p1.Engagement.Person.PersonId,
                        CreateUid = p1.Engagement.Person.CreateUid,
                        UpdateUid = p1.Engagement.Person.UpdateUid,
                        CountryId = p1.Engagement.Person.CountryId,
                        EtabId = p1.Engagement.Person.EtabId,
                        Nom = p1.Engagement.Person.Nom,
                        Prenom = p1.Engagement.Person.Prenom,
                        Datenais = p1.Engagement.Person.Datenais,
                        Lieunais = p1.Engagement.Person.Lieunais,
                        Sexe = p1.Engagement.Person.Sexe,
                        Email = p1.Engagement.Person.Email,
                        Adresse = p1.Engagement.Person.Adresse,
                        AdhesionDate = p1.Engagement.Person.AdhesionDate,
                        Nocni = p1.Engagement.Person.Nocni,
                        CniExpireDate = p1.Engagement.Person.CniExpireDate,
                        IsActive = p1.Engagement.Person.IsActive,
                        IsVisible = p1.Engagement.Person.IsVisible,
                        AnneePromo = p1.Engagement.Person.AnneePromo,
                        Country = p1.Engagement.Person.Country == null ? null : new CoreCountryDto()
                        {
                            CountryId = p1.Engagement.Person.Country.CountryId,
                            CreateUid = p1.Engagement.Person.Country.CreateUid,
                            UpdateUid = p1.Engagement.Person.Country.UpdateUid,
                            Libelle = p1.Engagement.Person.Country.Libelle,
                            CodeIso2 = p1.Engagement.Person.Country.CodeIso2,
                            CodeIso3 = p1.Engagement.Person.Country.CodeIso3,
                            PhoneCode = p1.Engagement.Person.Country.PhoneCode,
                            Devise = p1.Engagement.Person.Country.Devise
                        },
                        Etab = p1.Engagement.Person.Etab == null ? null : new CoreEtablissementDto()
                        {
                            EtabId = p1.Engagement.Person.Etab.EtabId,
                            CreateUid = p1.Engagement.Person.Etab.CreateUid,
                            UpdateUid = p1.Engagement.Person.Etab.UpdateUid,
                            CountryId = p1.Engagement.Person.Etab.CountryId,
                            Libelle = p1.Engagement.Person.Etab.Libelle,
                            Adresse = p1.Engagement.Person.Etab.Adresse,
                            Creationdate = p1.Engagement.Person.Etab.Creationdate,
                            DeployedUrl = p1.Engagement.Person.Etab.DeployedUrl,
                            DatabaseName = p1.Engagement.Person.Etab.DatabaseName,
                            ConnString = p1.Engagement.Person.Etab.ConnString,
                            EnableMultiAntenne = p1.Engagement.Person.Etab.EnableMultiAntenne,
                            Country = p1.Engagement.Person.Etab.Country == null ? null : new CoreCountryDto()
                            {
                                CountryId = p1.Engagement.Person.Etab.Country.CountryId,
                                CreateUid = p1.Engagement.Person.Etab.Country.CreateUid,
                                UpdateUid = p1.Engagement.Person.Etab.Country.UpdateUid,
                                Libelle = p1.Engagement.Person.Etab.Country.Libelle,
                                CodeIso2 = p1.Engagement.Person.Etab.Country.CodeIso2,
                                CodeIso3 = p1.Engagement.Person.Etab.Country.CodeIso3,
                                PhoneCode = p1.Engagement.Person.Etab.Country.PhoneCode,
                                Devise = p1.Engagement.Person.Etab.Country.Devise
                            }
                        }
                    },
                    Rubrique = p1.Engagement.Rubrique == null ? null : new MeetRubriqueDto()
                    {
                        RubriqueId = p1.Engagement.Rubrique.RubriqueId,
                        CreateUid = p1.Engagement.Rubrique.CreateUid,
                        UpdateUid = p1.Engagement.Rubrique.UpdateUid,
                        AnneeId = p1.Engagement.Rubrique.AnneeId,
                        TyperubId = p1.Engagement.Rubrique.TyperubId,
                        Libelle = p1.Engagement.Rubrique.Libelle,
                        Nbmandataire = p1.Engagement.Rubrique.Nbmandataire,
                        Montantroute = p1.Engagement.Rubrique.Montantroute,
                        MontantPerson = p1.Engagement.Rubrique.MontantPerson,
                        IsOutcome = p1.Engagement.Rubrique.IsOutcome,
                        Commentaire = p1.Engagement.Rubrique.Commentaire,
                        Annee = p1.Engagement.Rubrique.Annee == null ? null : new CoreAnneeDto()
                        {
                            AnneeId = p1.Engagement.Rubrique.Annee.AnneeId,
                            CreateUid = p1.Engagement.Rubrique.Annee.CreateUid,
                            UpdateUid = p1.Engagement.Rubrique.Annee.UpdateUid,
                            FrequenceId = p1.Engagement.Rubrique.Annee.FrequenceId,
                            BureauId = p1.Engagement.Rubrique.Annee.BureauId,
                            Previous = p1.Engagement.Rubrique.Annee.Previous,
                            Libelle = p1.Engagement.Rubrique.Annee.Libelle,
                            Datedebut = p1.Engagement.Rubrique.Annee.Datedebut,
                            Datefin = p1.Engagement.Rubrique.Annee.Datefin,
                            IsCurrent = p1.Engagement.Rubrique.Annee.IsCurrent,
                            IsClosed = p1.Engagement.Rubrique.Annee.IsClosed,
                            Nbdivision = p1.Engagement.Rubrique.Annee.Nbdivision,
                            CopyDataFromPrevious = p1.Engagement.Rubrique.Annee.CopyDataFromPrevious,
                            Bureau = p1.Engagement.Rubrique.Annee.Bureau == null ? null : new MeetBureauDto()
                            {
                                BureauId = p1.Engagement.Rubrique.Annee.Bureau.BureauId,
                                CreateUid = p1.Engagement.Rubrique.Annee.Bureau.CreateUid,
                                UpdateUid = p1.Engagement.Rubrique.Annee.Bureau.UpdateUid,
                                EtabId = p1.Engagement.Rubrique.Annee.Bureau.EtabId,
                                Libelle = p1.Engagement.Rubrique.Annee.Bureau.Libelle,
                                Debut = p1.Engagement.Rubrique.Annee.Bureau.Debut,
                                Fin = p1.Engagement.Rubrique.Annee.Bureau.Fin,
                                Nbperson = p1.Engagement.Rubrique.Annee.Bureau.Nbperson,
                                Nbvotes = p1.Engagement.Rubrique.Annee.Bureau.Nbvotes,
                                Nbabstention = p1.Engagement.Rubrique.Annee.Bureau.Nbabstention,
                                Resumevote = p1.Engagement.Rubrique.Annee.Bureau.Resumevote,
                                Etab = p1.Engagement.Rubrique.Annee.Bureau.Etab == null ? null : new CoreEtablissementDto()
                                {
                                    EtabId = p1.Engagement.Rubrique.Annee.Bureau.Etab.EtabId,
                                    CreateUid = p1.Engagement.Rubrique.Annee.Bureau.Etab.CreateUid,
                                    UpdateUid = p1.Engagement.Rubrique.Annee.Bureau.Etab.UpdateUid,
                                    CountryId = p1.Engagement.Rubrique.Annee.Bureau.Etab.CountryId,
                                    Libelle = p1.Engagement.Rubrique.Annee.Bureau.Etab.Libelle,
                                    Adresse = p1.Engagement.Rubrique.Annee.Bureau.Etab.Adresse,
                                    Creationdate = p1.Engagement.Rubrique.Annee.Bureau.Etab.Creationdate,
                                    DeployedUrl = p1.Engagement.Rubrique.Annee.Bureau.Etab.DeployedUrl,
                                    DatabaseName = p1.Engagement.Rubrique.Annee.Bureau.Etab.DatabaseName,
                                    ConnString = p1.Engagement.Rubrique.Annee.Bureau.Etab.ConnString,
                                    EnableMultiAntenne = p1.Engagement.Rubrique.Annee.Bureau.Etab.EnableMultiAntenne,
                                    Country = p1.Engagement.Rubrique.Annee.Bureau.Etab.Country == null ? null : new CoreCountryDto()
                                    {
                                        CountryId = p1.Engagement.Rubrique.Annee.Bureau.Etab.Country.CountryId,
                                        CreateUid = p1.Engagement.Rubrique.Annee.Bureau.Etab.Country.CreateUid,
                                        UpdateUid = p1.Engagement.Rubrique.Annee.Bureau.Etab.Country.UpdateUid,
                                        Libelle = p1.Engagement.Rubrique.Annee.Bureau.Etab.Country.Libelle,
                                        CodeIso2 = p1.Engagement.Rubrique.Annee.Bureau.Etab.Country.CodeIso2,
                                        CodeIso3 = p1.Engagement.Rubrique.Annee.Bureau.Etab.Country.CodeIso3,
                                        PhoneCode = p1.Engagement.Rubrique.Annee.Bureau.Etab.Country.PhoneCode,
                                        Devise = p1.Engagement.Rubrique.Annee.Bureau.Etab.Country.Devise
                                    }
                                }
                            },
                            Frequence = p1.Engagement.Rubrique.Annee.Frequence == null ? null : new CoreFrequenceDivisionDto()
                            {
                                FrequenceId = p1.Engagement.Rubrique.Annee.Frequence.FrequenceId,
                                CreateUid = p1.Engagement.Rubrique.Annee.Frequence.CreateUid,
                                UpdateUid = p1.Engagement.Rubrique.Annee.Frequence.UpdateUid,
                                Libelle = p1.Engagement.Rubrique.Annee.Frequence.Libelle,
                                NbDays = p1.Engagement.Rubrique.Annee.Frequence.NbDays
                            }
                        },
                        Typerub = p1.Engagement.Rubrique.Typerub == null ? null : new MeetTypeRubriqueDto()
                        {
                            TyperubId = p1.Engagement.Rubrique.Typerub.TyperubId,
                            CreateUid = p1.Engagement.Rubrique.Typerub.CreateUid,
                            UpdateUid = p1.Engagement.Rubrique.Typerub.UpdateUid,
                            Libelle = p1.Engagement.Rubrique.Typerub.Libelle,
                            IsOutcome = p1.Engagement.Rubrique.Typerub.IsOutcome,
                            Nbmandataire = p1.Engagement.Rubrique.Typerub.Nbmandataire,
                            Montantroute = p1.Engagement.Rubrique.Typerub.Montantroute,
                            MontantPerson = p1.Engagement.Rubrique.Typerub.MontantPerson,
                            Montantpenalite = p1.Engagement.Rubrique.Typerub.Montantpenalite,
                            Code = p1.Engagement.Rubrique.Typerub.Code,
                            Candelete = p1.Engagement.Rubrique.Typerub.Candelete,
                            Maxsignature = p1.Engagement.Rubrique.Typerub.Maxsignature,
                            AutoGenerated = p1.Engagement.Rubrique.Typerub.AutoGenerated,
                            Required = p1.Engagement.Rubrique.Typerub.Required,
                            IsActive = p1.Engagement.Rubrique.Typerub.IsActive,
                            Numordre = p1.Engagement.Rubrique.Typerub.Numordre
                        }
                    }
                },
                Modepaie = p1.Modepaie == null ? null : new CoreModepaieDto()
                {
                    ModepaieId = p1.Modepaie.ModepaieId,
                    CreateUid = p1.Modepaie.CreateUid,
                    UpdateUid = p1.Modepaie.UpdateUid,
                    Libelle = p1.Modepaie.Libelle,
                    IsCash = p1.Modepaie.IsCash
                },
                Presence = p1.Presence == null ? null : new MeetPresenceDto()
                {
                    PresenceId = p1.Presence.PresenceId,
                    CreateUid = p1.Presence.CreateUid,
                    UpdateUid = p1.Presence.UpdateUid,
                    SeanceId = p1.Presence.SeanceId,
                    Idinscrit = p1.Presence.Idinscrit,
                    Dateop = p1.Presence.Dateop,
                    IsAbsent = p1.Presence.IsAbsent,
                    Globalverse = p1.Presence.Globalverse,
                    NumBordero = p1.Presence.NumBordero,
                    Seance = p1.Presence.Seance == null ? null : new MeetSeanceDto()
                    {
                        SeanceId = p1.Presence.Seance.SeanceId,
                        CreateUid = p1.Presence.Seance.CreateUid,
                        UpdateUid = p1.Presence.Seance.UpdateUid,
                        AnneeId = p1.Presence.Seance.AnneeId,
                        DivisionId = p1.Presence.Seance.DivisionId,
                        EtabId = p1.Presence.Seance.EtabId,
                        AntenneId = p1.Presence.Seance.AntenneId,
                        Opendate = p1.Presence.Seance.Opendate,
                        Closedate = p1.Presence.Seance.Closedate,
                        TotalEntrees = p1.Presence.Seance.TotalEntrees,
                        TotalSorties = p1.Presence.Seance.TotalSorties,
                        Depensecollation = p1.Presence.Seance.Depensecollation,
                        Compterendu = p1.Presence.Seance.Compterendu,
                        Status = p1.Presence.Seance.Status
                    }
                }
            };
        }
        public static MeetEntreeCaisseDto AdaptTo(this MeetEntreeCaisse p2, MeetEntreeCaisseDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            MeetEntreeCaisseDto result = p3 ?? new MeetEntreeCaisseDto();
            
            result.OperationId = p2.OperationId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.PresenceId = p2.PresenceId;
            result.EngagementId = p2.EngagementId;
            result.ModepaieId = p2.ModepaieId;
            result.Montantverse = p2.Montantverse;
            result.IsOutcome = p2.IsOutcome;
            result.Engagement = funcMain1(p2.Engagement, result.Engagement);
            result.Modepaie = funcMain13(p2.Modepaie, result.Modepaie);
            result.Presence = funcMain14(p2.Presence, result.Presence);
            return result;
            
        }
        
        private static MeetEngagementDto funcMain1(MeetEngagement p4, MeetEngagementDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            MeetEngagementDto result = p5 ?? new MeetEngagementDto();
            
            result.EngagementId = p4.EngagementId;
            result.CreateUid = p4.CreateUid;
            result.UpdateUid = p4.UpdateUid;
            result.RubriqueId = p4.RubriqueId;
            result.PersonId = p4.PersonId;
            result.Cumulverse = p4.Cumulverse;
            result.Solde = p4.Solde;
            result.IsOutcome = p4.IsOutcome;
            result.IsClosed = p4.IsClosed;
            result.EngagementDate = p4.EngagementDate;
            result.Person = funcMain2(p4.Person, result.Person);
            result.Rubrique = funcMain6(p4.Rubrique, result.Rubrique);
            return result;
            
        }
        
        private static CoreModepaieDto funcMain13(CoreModepaie p28, CoreModepaieDto p29)
        {
            if (p28 == null)
            {
                return null;
            }
            CoreModepaieDto result = p29 ?? new CoreModepaieDto();
            
            result.ModepaieId = p28.ModepaieId;
            result.CreateUid = p28.CreateUid;
            result.UpdateUid = p28.UpdateUid;
            result.Libelle = p28.Libelle;
            result.IsCash = p28.IsCash;
            return result;
            
        }
        
        private static MeetPresenceDto funcMain14(MeetPresence p30, MeetPresenceDto p31)
        {
            if (p30 == null)
            {
                return null;
            }
            MeetPresenceDto result = p31 ?? new MeetPresenceDto();
            
            result.PresenceId = p30.PresenceId;
            result.CreateUid = p30.CreateUid;
            result.UpdateUid = p30.UpdateUid;
            result.SeanceId = p30.SeanceId;
            result.Idinscrit = p30.Idinscrit;
            result.Dateop = p30.Dateop;
            result.IsAbsent = p30.IsAbsent;
            result.Globalverse = p30.Globalverse;
            result.NumBordero = p30.NumBordero;
            result.Seance = funcMain15(p30.Seance, result.Seance);
            return result;
            
        }
        
        private static CorePersonDto funcMain2(CorePerson p6, CorePersonDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            CorePersonDto result = p7 ?? new CorePersonDto();
            
            result.PersonId = p6.PersonId;
            result.CreateUid = p6.CreateUid;
            result.UpdateUid = p6.UpdateUid;
            result.CountryId = p6.CountryId;
            result.EtabId = p6.EtabId;
            result.Nom = p6.Nom;
            result.Prenom = p6.Prenom;
            result.Datenais = p6.Datenais;
            result.Lieunais = p6.Lieunais;
            result.Sexe = p6.Sexe;
            result.Email = p6.Email;
            result.Adresse = p6.Adresse;
            result.AdhesionDate = p6.AdhesionDate;
            result.Nocni = p6.Nocni;
            result.CniExpireDate = p6.CniExpireDate;
            result.IsActive = p6.IsActive;
            result.IsVisible = p6.IsVisible;
            result.AnneePromo = p6.AnneePromo;
            result.Country = funcMain3(p6.Country, result.Country);
            result.Etab = funcMain4(p6.Etab, result.Etab);
            return result;
            
        }
        
        private static MeetRubriqueDto funcMain6(MeetRubrique p14, MeetRubriqueDto p15)
        {
            if (p14 == null)
            {
                return null;
            }
            MeetRubriqueDto result = p15 ?? new MeetRubriqueDto();
            
            result.RubriqueId = p14.RubriqueId;
            result.CreateUid = p14.CreateUid;
            result.UpdateUid = p14.UpdateUid;
            result.AnneeId = p14.AnneeId;
            result.TyperubId = p14.TyperubId;
            result.Libelle = p14.Libelle;
            result.Nbmandataire = p14.Nbmandataire;
            result.Montantroute = p14.Montantroute;
            result.MontantPerson = p14.MontantPerson;
            result.IsOutcome = p14.IsOutcome;
            result.Commentaire = p14.Commentaire;
            result.Annee = funcMain7(p14.Annee, result.Annee);
            result.Typerub = funcMain12(p14.Typerub, result.Typerub);
            return result;
            
        }
        
        private static MeetSeanceDto funcMain15(MeetSeance p32, MeetSeanceDto p33)
        {
            if (p32 == null)
            {
                return null;
            }
            MeetSeanceDto result = p33 ?? new MeetSeanceDto();
            
            result.SeanceId = p32.SeanceId;
            result.CreateUid = p32.CreateUid;
            result.UpdateUid = p32.UpdateUid;
            result.AnneeId = p32.AnneeId;
            result.DivisionId = p32.DivisionId;
            result.EtabId = p32.EtabId;
            result.AntenneId = p32.AntenneId;
            result.Opendate = p32.Opendate;
            result.Closedate = p32.Closedate;
            result.TotalEntrees = p32.TotalEntrees;
            result.TotalSorties = p32.TotalSorties;
            result.Depensecollation = p32.Depensecollation;
            result.Compterendu = p32.Compterendu;
            result.Status = p32.Status;
            return result;
            
        }
        
        private static CoreCountryDto funcMain3(CoreCountry p8, CoreCountryDto p9)
        {
            if (p8 == null)
            {
                return null;
            }
            CoreCountryDto result = p9 ?? new CoreCountryDto();
            
            result.CountryId = p8.CountryId;
            result.CreateUid = p8.CreateUid;
            result.UpdateUid = p8.UpdateUid;
            result.Libelle = p8.Libelle;
            result.CodeIso2 = p8.CodeIso2;
            result.CodeIso3 = p8.CodeIso3;
            result.PhoneCode = p8.PhoneCode;
            result.Devise = p8.Devise;
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
        
        private static CoreAnneeDto funcMain7(CoreAnnee p16, CoreAnneeDto p17)
        {
            if (p16 == null)
            {
                return null;
            }
            CoreAnneeDto result = p17 ?? new CoreAnneeDto();
            
            result.AnneeId = p16.AnneeId;
            result.CreateUid = p16.CreateUid;
            result.UpdateUid = p16.UpdateUid;
            result.FrequenceId = p16.FrequenceId;
            result.BureauId = p16.BureauId;
            result.Previous = p16.Previous;
            result.Libelle = p16.Libelle;
            result.Datedebut = p16.Datedebut;
            result.Datefin = p16.Datefin;
            result.IsCurrent = p16.IsCurrent;
            result.IsClosed = p16.IsClosed;
            result.Nbdivision = p16.Nbdivision;
            result.CopyDataFromPrevious = p16.CopyDataFromPrevious;
            result.Bureau = funcMain8(p16.Bureau, result.Bureau);
            result.Frequence = funcMain11(p16.Frequence, result.Frequence);
            return result;
            
        }
        
        private static MeetTypeRubriqueDto funcMain12(MeetTypeRubrique p26, MeetTypeRubriqueDto p27)
        {
            if (p26 == null)
            {
                return null;
            }
            MeetTypeRubriqueDto result = p27 ?? new MeetTypeRubriqueDto();
            
            result.TyperubId = p26.TyperubId;
            result.CreateUid = p26.CreateUid;
            result.UpdateUid = p26.UpdateUid;
            result.Libelle = p26.Libelle;
            result.IsOutcome = p26.IsOutcome;
            result.Nbmandataire = p26.Nbmandataire;
            result.Montantroute = p26.Montantroute;
            result.MontantPerson = p26.MontantPerson;
            result.Montantpenalite = p26.Montantpenalite;
            result.Code = p26.Code;
            result.Candelete = p26.Candelete;
            result.Maxsignature = p26.Maxsignature;
            result.AutoGenerated = p26.AutoGenerated;
            result.Required = p26.Required;
            result.IsActive = p26.IsActive;
            result.Numordre = p26.Numordre;
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
        
        private static MeetBureauDto funcMain8(MeetBureau p18, MeetBureauDto p19)
        {
            if (p18 == null)
            {
                return null;
            }
            MeetBureauDto result = p19 ?? new MeetBureauDto();
            
            result.BureauId = p18.BureauId;
            result.CreateUid = p18.CreateUid;
            result.UpdateUid = p18.UpdateUid;
            result.EtabId = p18.EtabId;
            result.Libelle = p18.Libelle;
            result.Debut = p18.Debut;
            result.Fin = p18.Fin;
            result.Nbperson = p18.Nbperson;
            result.Nbvotes = p18.Nbvotes;
            result.Nbabstention = p18.Nbabstention;
            result.Resumevote = p18.Resumevote;
            result.Etab = funcMain9(p18.Etab, result.Etab);
            return result;
            
        }
        
        private static CoreFrequenceDivisionDto funcMain11(CoreFrequenceDivision p24, CoreFrequenceDivisionDto p25)
        {
            if (p24 == null)
            {
                return null;
            }
            CoreFrequenceDivisionDto result = p25 ?? new CoreFrequenceDivisionDto();
            
            result.FrequenceId = p24.FrequenceId;
            result.CreateUid = p24.CreateUid;
            result.UpdateUid = p24.UpdateUid;
            result.Libelle = p24.Libelle;
            result.NbDays = p24.NbDays;
            return result;
            
        }
        
        private static CoreEtablissementDto funcMain9(CoreEtablissement p20, CoreEtablissementDto p21)
        {
            if (p20 == null)
            {
                return null;
            }
            CoreEtablissementDto result = p21 ?? new CoreEtablissementDto();
            
            result.EtabId = p20.EtabId;
            result.CreateUid = p20.CreateUid;
            result.UpdateUid = p20.UpdateUid;
            result.CountryId = p20.CountryId;
            result.Libelle = p20.Libelle;
            result.Adresse = p20.Adresse;
            result.Creationdate = p20.Creationdate;
            result.DeployedUrl = p20.DeployedUrl;
            result.DatabaseName = p20.DatabaseName;
            result.ConnString = p20.ConnString;
            result.EnableMultiAntenne = p20.EnableMultiAntenne;
            result.Country = funcMain10(p20.Country, result.Country);
            return result;
            
        }
        
        private static CoreCountryDto funcMain10(CoreCountry p22, CoreCountryDto p23)
        {
            if (p22 == null)
            {
                return null;
            }
            CoreCountryDto result = p23 ?? new CoreCountryDto();
            
            result.CountryId = p22.CountryId;
            result.CreateUid = p22.CreateUid;
            result.UpdateUid = p22.UpdateUid;
            result.Libelle = p22.Libelle;
            result.CodeIso2 = p22.CodeIso2;
            result.CodeIso3 = p22.CodeIso3;
            result.PhoneCode = p22.PhoneCode;
            result.Devise = p22.Devise;
            return result;
            
        }
    }
}