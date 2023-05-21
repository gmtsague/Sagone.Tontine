using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class MeetVisaMapper
    {
        public static MeetVisaDto AdaptToDto(this MeetVisa p1)
        {
            return p1 == null ? null : new MeetVisaDto()
            {
                VisaId = p1.VisaId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                Idinscrit = p1.Idinscrit,
                ConfigvisaId = p1.ConfigvisaId,
                SortiecaisseId = p1.SortiecaisseId,
                Datesign = p1.Datesign,
                SignByOrdre = p1.SignByOrdre,
                Receiver = p1.Receiver,
                Configvisa = p1.Configvisa == null ? null : new MeetConfigVisaDto()
                {
                    ConfigvisaId = p1.Configvisa.ConfigvisaId,
                    CreateUid = p1.Configvisa.CreateUid,
                    UpdateUid = p1.Configvisa.UpdateUid,
                    PosteId = p1.Configvisa.PosteId,
                    AnneeId = p1.Configvisa.AnneeId,
                    TyperubId = p1.Configvisa.TyperubId,
                    Numordre = p1.Configvisa.Numordre,
                    SignByOrdre = p1.Configvisa.SignByOrdre,
                    Annee = p1.Configvisa.Annee == null ? null : new CoreAnneeDto()
                    {
                        AnneeId = p1.Configvisa.Annee.AnneeId,
                        CreateUid = p1.Configvisa.Annee.CreateUid,
                        UpdateUid = p1.Configvisa.Annee.UpdateUid,
                        FrequenceId = p1.Configvisa.Annee.FrequenceId,
                        BureauId = p1.Configvisa.Annee.BureauId,
                        Previous = p1.Configvisa.Annee.Previous,
                        Libelle = p1.Configvisa.Annee.Libelle,
                        Datedebut = p1.Configvisa.Annee.Datedebut,
                        Datefin = p1.Configvisa.Annee.Datefin,
                        IsCurrent = p1.Configvisa.Annee.IsCurrent,
                        IsClosed = p1.Configvisa.Annee.IsClosed,
                        Nbdivision = p1.Configvisa.Annee.Nbdivision,
                        CopyDataFromPrevious = p1.Configvisa.Annee.CopyDataFromPrevious,
                        Bureau = p1.Configvisa.Annee.Bureau == null ? null : new MeetBureauDto()
                        {
                            BureauId = p1.Configvisa.Annee.Bureau.BureauId,
                            CreateUid = p1.Configvisa.Annee.Bureau.CreateUid,
                            UpdateUid = p1.Configvisa.Annee.Bureau.UpdateUid,
                            EtabId = p1.Configvisa.Annee.Bureau.EtabId,
                            Libelle = p1.Configvisa.Annee.Bureau.Libelle,
                            Debut = p1.Configvisa.Annee.Bureau.Debut,
                            Fin = p1.Configvisa.Annee.Bureau.Fin,
                            Nbperson = p1.Configvisa.Annee.Bureau.Nbperson,
                            Nbvotes = p1.Configvisa.Annee.Bureau.Nbvotes,
                            Nbabstention = p1.Configvisa.Annee.Bureau.Nbabstention,
                            Resumevote = p1.Configvisa.Annee.Bureau.Resumevote,
                            Etab = p1.Configvisa.Annee.Bureau.Etab == null ? null : new CoreEtablissementDto()
                            {
                                EtabId = p1.Configvisa.Annee.Bureau.Etab.EtabId,
                                CreateUid = p1.Configvisa.Annee.Bureau.Etab.CreateUid,
                                UpdateUid = p1.Configvisa.Annee.Bureau.Etab.UpdateUid,
                                CountryId = p1.Configvisa.Annee.Bureau.Etab.CountryId,
                                Libelle = p1.Configvisa.Annee.Bureau.Etab.Libelle,
                                Adresse = p1.Configvisa.Annee.Bureau.Etab.Adresse,
                                Creationdate = p1.Configvisa.Annee.Bureau.Etab.Creationdate,
                                DeployedUrl = p1.Configvisa.Annee.Bureau.Etab.DeployedUrl,
                                DatabaseName = p1.Configvisa.Annee.Bureau.Etab.DatabaseName,
                                ConnString = p1.Configvisa.Annee.Bureau.Etab.ConnString,
                                EnableMultiAntenne = p1.Configvisa.Annee.Bureau.Etab.EnableMultiAntenne,
                                Country = p1.Configvisa.Annee.Bureau.Etab.Country == null ? null : new CoreCountryDto()
                                {
                                    CountryId = p1.Configvisa.Annee.Bureau.Etab.Country.CountryId,
                                    CreateUid = p1.Configvisa.Annee.Bureau.Etab.Country.CreateUid,
                                    UpdateUid = p1.Configvisa.Annee.Bureau.Etab.Country.UpdateUid,
                                    Libelle = p1.Configvisa.Annee.Bureau.Etab.Country.Libelle,
                                    CodeIso2 = p1.Configvisa.Annee.Bureau.Etab.Country.CodeIso2,
                                    CodeIso3 = p1.Configvisa.Annee.Bureau.Etab.Country.CodeIso3,
                                    PhoneCode = p1.Configvisa.Annee.Bureau.Etab.Country.PhoneCode,
                                    Devise = p1.Configvisa.Annee.Bureau.Etab.Country.Devise
                                }
                            }
                        },
                        Frequence = p1.Configvisa.Annee.Frequence == null ? null : new CoreFrequenceDivisionDto()
                        {
                            FrequenceId = p1.Configvisa.Annee.Frequence.FrequenceId,
                            CreateUid = p1.Configvisa.Annee.Frequence.CreateUid,
                            UpdateUid = p1.Configvisa.Annee.Frequence.UpdateUid,
                            Libelle = p1.Configvisa.Annee.Frequence.Libelle,
                            NbDays = p1.Configvisa.Annee.Frequence.NbDays
                        }
                    },
                    Poste = p1.Configvisa.Poste == null ? null : new MeetPosteDto()
                    {
                        PosteId = p1.Configvisa.Poste.PosteId,
                        CreateUid = p1.Configvisa.Poste.CreateUid,
                        UpdateUid = p1.Configvisa.Poste.UpdateUid,
                        Libelle = p1.Configvisa.Poste.Libelle,
                        Code = p1.Configvisa.Poste.Code
                    },
                    Typerub = p1.Configvisa.Typerub == null ? null : new MeetTypeRubriqueDto()
                    {
                        TyperubId = p1.Configvisa.Typerub.TyperubId,
                        CreateUid = p1.Configvisa.Typerub.CreateUid,
                        UpdateUid = p1.Configvisa.Typerub.UpdateUid,
                        Libelle = p1.Configvisa.Typerub.Libelle,
                        IsOutcome = p1.Configvisa.Typerub.IsOutcome,
                        Nbmandataire = p1.Configvisa.Typerub.Nbmandataire,
                        Montantroute = p1.Configvisa.Typerub.Montantroute,
                        MontantPerson = p1.Configvisa.Typerub.MontantPerson,
                        Montantpenalite = p1.Configvisa.Typerub.Montantpenalite,
                        Code = p1.Configvisa.Typerub.Code,
                        Candelete = p1.Configvisa.Typerub.Candelete,
                        Maxsignature = p1.Configvisa.Typerub.Maxsignature,
                        AutoGenerated = p1.Configvisa.Typerub.AutoGenerated,
                        Required = p1.Configvisa.Typerub.Required,
                        IsActive = p1.Configvisa.Typerub.IsActive,
                        Numordre = p1.Configvisa.Typerub.Numordre
                    }
                },
                Sortiecaisse = p1.Sortiecaisse == null ? null : new MeetSortieCaisseDto()
                {
                    SortiecaisseId = p1.Sortiecaisse.SortiecaisseId,
                    CreateUid = p1.Sortiecaisse.CreateUid,
                    UpdateUid = p1.Sortiecaisse.UpdateUid,
                    Idinscrit = p1.Sortiecaisse.Idinscrit,
                    SeanceId = p1.Sortiecaisse.SeanceId,
                    EngagementId = p1.Sortiecaisse.EngagementId,
                    MontantRoute = p1.Sortiecaisse.MontantRoute,
                    ListeMandataires = p1.Sortiecaisse.ListeMandataires,
                    Dateevts = p1.Sortiecaisse.Dateevts,
                    Montantpercu = p1.Sortiecaisse.Montantpercu,
                    Note = p1.Sortiecaisse.Note,
                    IsClosed = p1.Sortiecaisse.IsClosed,
                    Visarestants = p1.Sortiecaisse.Visarestants,
                    Engagement = p1.Sortiecaisse.Engagement == null ? null : new MeetEngagementDto()
                    {
                        EngagementId = p1.Sortiecaisse.Engagement.EngagementId,
                        CreateUid = p1.Sortiecaisse.Engagement.CreateUid,
                        UpdateUid = p1.Sortiecaisse.Engagement.UpdateUid,
                        RubriqueId = p1.Sortiecaisse.Engagement.RubriqueId,
                        PersonId = p1.Sortiecaisse.Engagement.PersonId,
                        Cumulverse = p1.Sortiecaisse.Engagement.Cumulverse,
                        Solde = p1.Sortiecaisse.Engagement.Solde,
                        IsOutcome = p1.Sortiecaisse.Engagement.IsOutcome,
                        IsClosed = p1.Sortiecaisse.Engagement.IsClosed,
                        EngagementDate = p1.Sortiecaisse.Engagement.EngagementDate,
                        Person = p1.Sortiecaisse.Engagement.Person == null ? null : new CorePersonDto()
                        {
                            PersonId = p1.Sortiecaisse.Engagement.Person.PersonId,
                            CreateUid = p1.Sortiecaisse.Engagement.Person.CreateUid,
                            UpdateUid = p1.Sortiecaisse.Engagement.Person.UpdateUid,
                            CountryId = p1.Sortiecaisse.Engagement.Person.CountryId,
                            EtabId = p1.Sortiecaisse.Engagement.Person.EtabId,
                            Nom = p1.Sortiecaisse.Engagement.Person.Nom,
                            Prenom = p1.Sortiecaisse.Engagement.Person.Prenom,
                            Datenais = p1.Sortiecaisse.Engagement.Person.Datenais,
                            Lieunais = p1.Sortiecaisse.Engagement.Person.Lieunais,
                            Sexe = p1.Sortiecaisse.Engagement.Person.Sexe,
                            Email = p1.Sortiecaisse.Engagement.Person.Email,
                            Adresse = p1.Sortiecaisse.Engagement.Person.Adresse,
                            AdhesionDate = p1.Sortiecaisse.Engagement.Person.AdhesionDate,
                            Nocni = p1.Sortiecaisse.Engagement.Person.Nocni,
                            CniExpireDate = p1.Sortiecaisse.Engagement.Person.CniExpireDate,
                            IsActive = p1.Sortiecaisse.Engagement.Person.IsActive,
                            IsVisible = p1.Sortiecaisse.Engagement.Person.IsVisible,
                            AnneePromo = p1.Sortiecaisse.Engagement.Person.AnneePromo,
                            Country = p1.Sortiecaisse.Engagement.Person.Country == null ? null : new CoreCountryDto()
                            {
                                CountryId = p1.Sortiecaisse.Engagement.Person.Country.CountryId,
                                CreateUid = p1.Sortiecaisse.Engagement.Person.Country.CreateUid,
                                UpdateUid = p1.Sortiecaisse.Engagement.Person.Country.UpdateUid,
                                Libelle = p1.Sortiecaisse.Engagement.Person.Country.Libelle,
                                CodeIso2 = p1.Sortiecaisse.Engagement.Person.Country.CodeIso2,
                                CodeIso3 = p1.Sortiecaisse.Engagement.Person.Country.CodeIso3,
                                PhoneCode = p1.Sortiecaisse.Engagement.Person.Country.PhoneCode,
                                Devise = p1.Sortiecaisse.Engagement.Person.Country.Devise
                            },
                            Etab = p1.Sortiecaisse.Engagement.Person.Etab == null ? null : new CoreEtablissementDto()
                            {
                                EtabId = p1.Sortiecaisse.Engagement.Person.Etab.EtabId,
                                CreateUid = p1.Sortiecaisse.Engagement.Person.Etab.CreateUid,
                                UpdateUid = p1.Sortiecaisse.Engagement.Person.Etab.UpdateUid,
                                CountryId = p1.Sortiecaisse.Engagement.Person.Etab.CountryId,
                                Libelle = p1.Sortiecaisse.Engagement.Person.Etab.Libelle,
                                Adresse = p1.Sortiecaisse.Engagement.Person.Etab.Adresse,
                                Creationdate = p1.Sortiecaisse.Engagement.Person.Etab.Creationdate,
                                DeployedUrl = p1.Sortiecaisse.Engagement.Person.Etab.DeployedUrl,
                                DatabaseName = p1.Sortiecaisse.Engagement.Person.Etab.DatabaseName,
                                ConnString = p1.Sortiecaisse.Engagement.Person.Etab.ConnString,
                                EnableMultiAntenne = p1.Sortiecaisse.Engagement.Person.Etab.EnableMultiAntenne,
                                Country = p1.Sortiecaisse.Engagement.Person.Etab.Country == null ? null : new CoreCountryDto()
                                {
                                    CountryId = p1.Sortiecaisse.Engagement.Person.Etab.Country.CountryId,
                                    CreateUid = p1.Sortiecaisse.Engagement.Person.Etab.Country.CreateUid,
                                    UpdateUid = p1.Sortiecaisse.Engagement.Person.Etab.Country.UpdateUid,
                                    Libelle = p1.Sortiecaisse.Engagement.Person.Etab.Country.Libelle,
                                    CodeIso2 = p1.Sortiecaisse.Engagement.Person.Etab.Country.CodeIso2,
                                    CodeIso3 = p1.Sortiecaisse.Engagement.Person.Etab.Country.CodeIso3,
                                    PhoneCode = p1.Sortiecaisse.Engagement.Person.Etab.Country.PhoneCode,
                                    Devise = p1.Sortiecaisse.Engagement.Person.Etab.Country.Devise
                                }
                            }
                        },
                        Rubrique = p1.Sortiecaisse.Engagement.Rubrique == null ? null : new MeetRubriqueDto()
                        {
                            RubriqueId = p1.Sortiecaisse.Engagement.Rubrique.RubriqueId,
                            CreateUid = p1.Sortiecaisse.Engagement.Rubrique.CreateUid,
                            UpdateUid = p1.Sortiecaisse.Engagement.Rubrique.UpdateUid,
                            AnneeId = p1.Sortiecaisse.Engagement.Rubrique.AnneeId,
                            TyperubId = p1.Sortiecaisse.Engagement.Rubrique.TyperubId,
                            Libelle = p1.Sortiecaisse.Engagement.Rubrique.Libelle,
                            Nbmandataire = p1.Sortiecaisse.Engagement.Rubrique.Nbmandataire,
                            Montantroute = p1.Sortiecaisse.Engagement.Rubrique.Montantroute,
                            MontantPerson = p1.Sortiecaisse.Engagement.Rubrique.MontantPerson,
                            IsOutcome = p1.Sortiecaisse.Engagement.Rubrique.IsOutcome,
                            Commentaire = p1.Sortiecaisse.Engagement.Rubrique.Commentaire,
                            Annee = p1.Sortiecaisse.Engagement.Rubrique.Annee == null ? null : new CoreAnneeDto()
                            {
                                AnneeId = p1.Sortiecaisse.Engagement.Rubrique.Annee.AnneeId,
                                CreateUid = p1.Sortiecaisse.Engagement.Rubrique.Annee.CreateUid,
                                UpdateUid = p1.Sortiecaisse.Engagement.Rubrique.Annee.UpdateUid,
                                FrequenceId = p1.Sortiecaisse.Engagement.Rubrique.Annee.FrequenceId,
                                BureauId = p1.Sortiecaisse.Engagement.Rubrique.Annee.BureauId,
                                Previous = p1.Sortiecaisse.Engagement.Rubrique.Annee.Previous,
                                Libelle = p1.Sortiecaisse.Engagement.Rubrique.Annee.Libelle,
                                Datedebut = p1.Sortiecaisse.Engagement.Rubrique.Annee.Datedebut,
                                Datefin = p1.Sortiecaisse.Engagement.Rubrique.Annee.Datefin,
                                IsCurrent = p1.Sortiecaisse.Engagement.Rubrique.Annee.IsCurrent,
                                IsClosed = p1.Sortiecaisse.Engagement.Rubrique.Annee.IsClosed,
                                Nbdivision = p1.Sortiecaisse.Engagement.Rubrique.Annee.Nbdivision,
                                CopyDataFromPrevious = p1.Sortiecaisse.Engagement.Rubrique.Annee.CopyDataFromPrevious,
                                Bureau = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau == null ? null : new MeetBureauDto()
                                {
                                    BureauId = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.BureauId,
                                    CreateUid = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.CreateUid,
                                    UpdateUid = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.UpdateUid,
                                    EtabId = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.EtabId,
                                    Libelle = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Libelle,
                                    Debut = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Debut,
                                    Fin = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Fin,
                                    Nbperson = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Nbperson,
                                    Nbvotes = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Nbvotes,
                                    Nbabstention = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Nbabstention,
                                    Resumevote = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Resumevote,
                                    Etab = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab == null ? null : new CoreEtablissementDto()
                                    {
                                        EtabId = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.EtabId,
                                        CreateUid = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.CreateUid,
                                        UpdateUid = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.UpdateUid,
                                        CountryId = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.CountryId,
                                        Libelle = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.Libelle,
                                        Adresse = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.Adresse,
                                        Creationdate = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.Creationdate,
                                        DeployedUrl = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.DeployedUrl,
                                        DatabaseName = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.DatabaseName,
                                        ConnString = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.ConnString,
                                        EnableMultiAntenne = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.EnableMultiAntenne,
                                        Country = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.Country == null ? null : new CoreCountryDto()
                                        {
                                            CountryId = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.Country.CountryId,
                                            CreateUid = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.Country.CreateUid,
                                            UpdateUid = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.Country.UpdateUid,
                                            Libelle = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.Country.Libelle,
                                            CodeIso2 = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.Country.CodeIso2,
                                            CodeIso3 = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.Country.CodeIso3,
                                            PhoneCode = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.Country.PhoneCode,
                                            Devise = p1.Sortiecaisse.Engagement.Rubrique.Annee.Bureau.Etab.Country.Devise
                                        }
                                    }
                                },
                                Frequence = p1.Sortiecaisse.Engagement.Rubrique.Annee.Frequence == null ? null : new CoreFrequenceDivisionDto()
                                {
                                    FrequenceId = p1.Sortiecaisse.Engagement.Rubrique.Annee.Frequence.FrequenceId,
                                    CreateUid = p1.Sortiecaisse.Engagement.Rubrique.Annee.Frequence.CreateUid,
                                    UpdateUid = p1.Sortiecaisse.Engagement.Rubrique.Annee.Frequence.UpdateUid,
                                    Libelle = p1.Sortiecaisse.Engagement.Rubrique.Annee.Frequence.Libelle,
                                    NbDays = p1.Sortiecaisse.Engagement.Rubrique.Annee.Frequence.NbDays
                                }
                            },
                            Typerub = p1.Sortiecaisse.Engagement.Rubrique.Typerub == null ? null : new MeetTypeRubriqueDto()
                            {
                                TyperubId = p1.Sortiecaisse.Engagement.Rubrique.Typerub.TyperubId,
                                CreateUid = p1.Sortiecaisse.Engagement.Rubrique.Typerub.CreateUid,
                                UpdateUid = p1.Sortiecaisse.Engagement.Rubrique.Typerub.UpdateUid,
                                Libelle = p1.Sortiecaisse.Engagement.Rubrique.Typerub.Libelle,
                                IsOutcome = p1.Sortiecaisse.Engagement.Rubrique.Typerub.IsOutcome,
                                Nbmandataire = p1.Sortiecaisse.Engagement.Rubrique.Typerub.Nbmandataire,
                                Montantroute = p1.Sortiecaisse.Engagement.Rubrique.Typerub.Montantroute,
                                MontantPerson = p1.Sortiecaisse.Engagement.Rubrique.Typerub.MontantPerson,
                                Montantpenalite = p1.Sortiecaisse.Engagement.Rubrique.Typerub.Montantpenalite,
                                Code = p1.Sortiecaisse.Engagement.Rubrique.Typerub.Code,
                                Candelete = p1.Sortiecaisse.Engagement.Rubrique.Typerub.Candelete,
                                Maxsignature = p1.Sortiecaisse.Engagement.Rubrique.Typerub.Maxsignature,
                                AutoGenerated = p1.Sortiecaisse.Engagement.Rubrique.Typerub.AutoGenerated,
                                Required = p1.Sortiecaisse.Engagement.Rubrique.Typerub.Required,
                                IsActive = p1.Sortiecaisse.Engagement.Rubrique.Typerub.IsActive,
                                Numordre = p1.Sortiecaisse.Engagement.Rubrique.Typerub.Numordre
                            }
                        }
                    },
                    Seance = p1.Sortiecaisse.Seance == null ? null : new MeetSeanceDto()
                    {
                        SeanceId = p1.Sortiecaisse.Seance.SeanceId,
                        CreateUid = p1.Sortiecaisse.Seance.CreateUid,
                        UpdateUid = p1.Sortiecaisse.Seance.UpdateUid,
                        AnneeId = p1.Sortiecaisse.Seance.AnneeId,
                        DivisionId = p1.Sortiecaisse.Seance.DivisionId,
                        EtabId = p1.Sortiecaisse.Seance.EtabId,
                        AntenneId = p1.Sortiecaisse.Seance.AntenneId,
                        Opendate = p1.Sortiecaisse.Seance.Opendate,
                        Closedate = p1.Sortiecaisse.Seance.Closedate,
                        TotalEntrees = p1.Sortiecaisse.Seance.TotalEntrees,
                        TotalSorties = p1.Sortiecaisse.Seance.TotalSorties,
                        Depensecollation = p1.Sortiecaisse.Seance.Depensecollation,
                        Compterendu = p1.Sortiecaisse.Seance.Compterendu,
                        Status = p1.Sortiecaisse.Seance.Status
                    }
                }
            };
        }
        public static MeetVisaDto AdaptTo(this MeetVisa p2, MeetVisaDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            MeetVisaDto result = p3 ?? new MeetVisaDto();
            
            result.VisaId = p2.VisaId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.Idinscrit = p2.Idinscrit;
            result.ConfigvisaId = p2.ConfigvisaId;
            result.SortiecaisseId = p2.SortiecaisseId;
            result.Datesign = p2.Datesign;
            result.SignByOrdre = p2.SignByOrdre;
            result.Receiver = p2.Receiver;
            result.Configvisa = funcMain1(p2.Configvisa, result.Configvisa);
            result.Sortiecaisse = funcMain9(p2.Sortiecaisse, result.Sortiecaisse);
            return result;
            
        }
        
        private static MeetConfigVisaDto funcMain1(MeetConfigVisa p4, MeetConfigVisaDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            MeetConfigVisaDto result = p5 ?? new MeetConfigVisaDto();
            
            result.ConfigvisaId = p4.ConfigvisaId;
            result.CreateUid = p4.CreateUid;
            result.UpdateUid = p4.UpdateUid;
            result.PosteId = p4.PosteId;
            result.AnneeId = p4.AnneeId;
            result.TyperubId = p4.TyperubId;
            result.Numordre = p4.Numordre;
            result.SignByOrdre = p4.SignByOrdre;
            result.Annee = funcMain2(p4.Annee, result.Annee);
            result.Poste = funcMain7(p4.Poste, result.Poste);
            result.Typerub = funcMain8(p4.Typerub, result.Typerub);
            return result;
            
        }
        
        private static MeetSortieCaisseDto funcMain9(MeetSortieCaisse p20, MeetSortieCaisseDto p21)
        {
            if (p20 == null)
            {
                return null;
            }
            MeetSortieCaisseDto result = p21 ?? new MeetSortieCaisseDto();
            
            result.SortiecaisseId = p20.SortiecaisseId;
            result.CreateUid = p20.CreateUid;
            result.UpdateUid = p20.UpdateUid;
            result.Idinscrit = p20.Idinscrit;
            result.SeanceId = p20.SeanceId;
            result.EngagementId = p20.EngagementId;
            result.MontantRoute = p20.MontantRoute;
            result.ListeMandataires = p20.ListeMandataires;
            result.Dateevts = p20.Dateevts;
            result.Montantpercu = p20.Montantpercu;
            result.Note = p20.Note;
            result.IsClosed = p20.IsClosed;
            result.Visarestants = p20.Visarestants;
            result.Engagement = funcMain10(p20.Engagement, result.Engagement);
            result.Seance = funcMain22(p20.Seance, result.Seance);
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
        
        private static MeetPosteDto funcMain7(MeetPoste p16, MeetPosteDto p17)
        {
            if (p16 == null)
            {
                return null;
            }
            MeetPosteDto result = p17 ?? new MeetPosteDto();
            
            result.PosteId = p16.PosteId;
            result.CreateUid = p16.CreateUid;
            result.UpdateUid = p16.UpdateUid;
            result.Libelle = p16.Libelle;
            result.Code = p16.Code;
            return result;
            
        }
        
        private static MeetTypeRubriqueDto funcMain8(MeetTypeRubrique p18, MeetTypeRubriqueDto p19)
        {
            if (p18 == null)
            {
                return null;
            }
            MeetTypeRubriqueDto result = p19 ?? new MeetTypeRubriqueDto();
            
            result.TyperubId = p18.TyperubId;
            result.CreateUid = p18.CreateUid;
            result.UpdateUid = p18.UpdateUid;
            result.Libelle = p18.Libelle;
            result.IsOutcome = p18.IsOutcome;
            result.Nbmandataire = p18.Nbmandataire;
            result.Montantroute = p18.Montantroute;
            result.MontantPerson = p18.MontantPerson;
            result.Montantpenalite = p18.Montantpenalite;
            result.Code = p18.Code;
            result.Candelete = p18.Candelete;
            result.Maxsignature = p18.Maxsignature;
            result.AutoGenerated = p18.AutoGenerated;
            result.Required = p18.Required;
            result.IsActive = p18.IsActive;
            result.Numordre = p18.Numordre;
            return result;
            
        }
        
        private static MeetEngagementDto funcMain10(MeetEngagement p22, MeetEngagementDto p23)
        {
            if (p22 == null)
            {
                return null;
            }
            MeetEngagementDto result = p23 ?? new MeetEngagementDto();
            
            result.EngagementId = p22.EngagementId;
            result.CreateUid = p22.CreateUid;
            result.UpdateUid = p22.UpdateUid;
            result.RubriqueId = p22.RubriqueId;
            result.PersonId = p22.PersonId;
            result.Cumulverse = p22.Cumulverse;
            result.Solde = p22.Solde;
            result.IsOutcome = p22.IsOutcome;
            result.IsClosed = p22.IsClosed;
            result.EngagementDate = p22.EngagementDate;
            result.Person = funcMain11(p22.Person, result.Person);
            result.Rubrique = funcMain15(p22.Rubrique, result.Rubrique);
            return result;
            
        }
        
        private static MeetSeanceDto funcMain22(MeetSeance p46, MeetSeanceDto p47)
        {
            if (p46 == null)
            {
                return null;
            }
            MeetSeanceDto result = p47 ?? new MeetSeanceDto();
            
            result.SeanceId = p46.SeanceId;
            result.CreateUid = p46.CreateUid;
            result.UpdateUid = p46.UpdateUid;
            result.AnneeId = p46.AnneeId;
            result.DivisionId = p46.DivisionId;
            result.EtabId = p46.EtabId;
            result.AntenneId = p46.AntenneId;
            result.Opendate = p46.Opendate;
            result.Closedate = p46.Closedate;
            result.TotalEntrees = p46.TotalEntrees;
            result.TotalSorties = p46.TotalSorties;
            result.Depensecollation = p46.Depensecollation;
            result.Compterendu = p46.Compterendu;
            result.Status = p46.Status;
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
        
        private static CorePersonDto funcMain11(CorePerson p24, CorePersonDto p25)
        {
            if (p24 == null)
            {
                return null;
            }
            CorePersonDto result = p25 ?? new CorePersonDto();
            
            result.PersonId = p24.PersonId;
            result.CreateUid = p24.CreateUid;
            result.UpdateUid = p24.UpdateUid;
            result.CountryId = p24.CountryId;
            result.EtabId = p24.EtabId;
            result.Nom = p24.Nom;
            result.Prenom = p24.Prenom;
            result.Datenais = p24.Datenais;
            result.Lieunais = p24.Lieunais;
            result.Sexe = p24.Sexe;
            result.Email = p24.Email;
            result.Adresse = p24.Adresse;
            result.AdhesionDate = p24.AdhesionDate;
            result.Nocni = p24.Nocni;
            result.CniExpireDate = p24.CniExpireDate;
            result.IsActive = p24.IsActive;
            result.IsVisible = p24.IsVisible;
            result.AnneePromo = p24.AnneePromo;
            result.Country = funcMain12(p24.Country, result.Country);
            result.Etab = funcMain13(p24.Etab, result.Etab);
            return result;
            
        }
        
        private static MeetRubriqueDto funcMain15(MeetRubrique p32, MeetRubriqueDto p33)
        {
            if (p32 == null)
            {
                return null;
            }
            MeetRubriqueDto result = p33 ?? new MeetRubriqueDto();
            
            result.RubriqueId = p32.RubriqueId;
            result.CreateUid = p32.CreateUid;
            result.UpdateUid = p32.UpdateUid;
            result.AnneeId = p32.AnneeId;
            result.TyperubId = p32.TyperubId;
            result.Libelle = p32.Libelle;
            result.Nbmandataire = p32.Nbmandataire;
            result.Montantroute = p32.Montantroute;
            result.MontantPerson = p32.MontantPerson;
            result.IsOutcome = p32.IsOutcome;
            result.Commentaire = p32.Commentaire;
            result.Annee = funcMain16(p32.Annee, result.Annee);
            result.Typerub = funcMain21(p32.Typerub, result.Typerub);
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
        
        private static CoreCountryDto funcMain12(CoreCountry p26, CoreCountryDto p27)
        {
            if (p26 == null)
            {
                return null;
            }
            CoreCountryDto result = p27 ?? new CoreCountryDto();
            
            result.CountryId = p26.CountryId;
            result.CreateUid = p26.CreateUid;
            result.UpdateUid = p26.UpdateUid;
            result.Libelle = p26.Libelle;
            result.CodeIso2 = p26.CodeIso2;
            result.CodeIso3 = p26.CodeIso3;
            result.PhoneCode = p26.PhoneCode;
            result.Devise = p26.Devise;
            return result;
            
        }
        
        private static CoreEtablissementDto funcMain13(CoreEtablissement p28, CoreEtablissementDto p29)
        {
            if (p28 == null)
            {
                return null;
            }
            CoreEtablissementDto result = p29 ?? new CoreEtablissementDto();
            
            result.EtabId = p28.EtabId;
            result.CreateUid = p28.CreateUid;
            result.UpdateUid = p28.UpdateUid;
            result.CountryId = p28.CountryId;
            result.Libelle = p28.Libelle;
            result.Adresse = p28.Adresse;
            result.Creationdate = p28.Creationdate;
            result.DeployedUrl = p28.DeployedUrl;
            result.DatabaseName = p28.DatabaseName;
            result.ConnString = p28.ConnString;
            result.EnableMultiAntenne = p28.EnableMultiAntenne;
            result.Country = funcMain14(p28.Country, result.Country);
            return result;
            
        }
        
        private static CoreAnneeDto funcMain16(CoreAnnee p34, CoreAnneeDto p35)
        {
            if (p34 == null)
            {
                return null;
            }
            CoreAnneeDto result = p35 ?? new CoreAnneeDto();
            
            result.AnneeId = p34.AnneeId;
            result.CreateUid = p34.CreateUid;
            result.UpdateUid = p34.UpdateUid;
            result.FrequenceId = p34.FrequenceId;
            result.BureauId = p34.BureauId;
            result.Previous = p34.Previous;
            result.Libelle = p34.Libelle;
            result.Datedebut = p34.Datedebut;
            result.Datefin = p34.Datefin;
            result.IsCurrent = p34.IsCurrent;
            result.IsClosed = p34.IsClosed;
            result.Nbdivision = p34.Nbdivision;
            result.CopyDataFromPrevious = p34.CopyDataFromPrevious;
            result.Bureau = funcMain17(p34.Bureau, result.Bureau);
            result.Frequence = funcMain20(p34.Frequence, result.Frequence);
            return result;
            
        }
        
        private static MeetTypeRubriqueDto funcMain21(MeetTypeRubrique p44, MeetTypeRubriqueDto p45)
        {
            if (p44 == null)
            {
                return null;
            }
            MeetTypeRubriqueDto result = p45 ?? new MeetTypeRubriqueDto();
            
            result.TyperubId = p44.TyperubId;
            result.CreateUid = p44.CreateUid;
            result.UpdateUid = p44.UpdateUid;
            result.Libelle = p44.Libelle;
            result.IsOutcome = p44.IsOutcome;
            result.Nbmandataire = p44.Nbmandataire;
            result.Montantroute = p44.Montantroute;
            result.MontantPerson = p44.MontantPerson;
            result.Montantpenalite = p44.Montantpenalite;
            result.Code = p44.Code;
            result.Candelete = p44.Candelete;
            result.Maxsignature = p44.Maxsignature;
            result.AutoGenerated = p44.AutoGenerated;
            result.Required = p44.Required;
            result.IsActive = p44.IsActive;
            result.Numordre = p44.Numordre;
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
        
        private static CoreCountryDto funcMain14(CoreCountry p30, CoreCountryDto p31)
        {
            if (p30 == null)
            {
                return null;
            }
            CoreCountryDto result = p31 ?? new CoreCountryDto();
            
            result.CountryId = p30.CountryId;
            result.CreateUid = p30.CreateUid;
            result.UpdateUid = p30.UpdateUid;
            result.Libelle = p30.Libelle;
            result.CodeIso2 = p30.CodeIso2;
            result.CodeIso3 = p30.CodeIso3;
            result.PhoneCode = p30.PhoneCode;
            result.Devise = p30.Devise;
            return result;
            
        }
        
        private static MeetBureauDto funcMain17(MeetBureau p36, MeetBureauDto p37)
        {
            if (p36 == null)
            {
                return null;
            }
            MeetBureauDto result = p37 ?? new MeetBureauDto();
            
            result.BureauId = p36.BureauId;
            result.CreateUid = p36.CreateUid;
            result.UpdateUid = p36.UpdateUid;
            result.EtabId = p36.EtabId;
            result.Libelle = p36.Libelle;
            result.Debut = p36.Debut;
            result.Fin = p36.Fin;
            result.Nbperson = p36.Nbperson;
            result.Nbvotes = p36.Nbvotes;
            result.Nbabstention = p36.Nbabstention;
            result.Resumevote = p36.Resumevote;
            result.Etab = funcMain18(p36.Etab, result.Etab);
            return result;
            
        }
        
        private static CoreFrequenceDivisionDto funcMain20(CoreFrequenceDivision p42, CoreFrequenceDivisionDto p43)
        {
            if (p42 == null)
            {
                return null;
            }
            CoreFrequenceDivisionDto result = p43 ?? new CoreFrequenceDivisionDto();
            
            result.FrequenceId = p42.FrequenceId;
            result.CreateUid = p42.CreateUid;
            result.UpdateUid = p42.UpdateUid;
            result.Libelle = p42.Libelle;
            result.NbDays = p42.NbDays;
            return result;
            
        }
        
        private static CoreEtablissementDto funcMain18(CoreEtablissement p38, CoreEtablissementDto p39)
        {
            if (p38 == null)
            {
                return null;
            }
            CoreEtablissementDto result = p39 ?? new CoreEtablissementDto();
            
            result.EtabId = p38.EtabId;
            result.CreateUid = p38.CreateUid;
            result.UpdateUid = p38.UpdateUid;
            result.CountryId = p38.CountryId;
            result.Libelle = p38.Libelle;
            result.Adresse = p38.Adresse;
            result.Creationdate = p38.Creationdate;
            result.DeployedUrl = p38.DeployedUrl;
            result.DatabaseName = p38.DatabaseName;
            result.ConnString = p38.ConnString;
            result.EnableMultiAntenne = p38.EnableMultiAntenne;
            result.Country = funcMain19(p38.Country, result.Country);
            return result;
            
        }
        
        private static CoreCountryDto funcMain19(CoreCountry p40, CoreCountryDto p41)
        {
            if (p40 == null)
            {
                return null;
            }
            CoreCountryDto result = p41 ?? new CoreCountryDto();
            
            result.CountryId = p40.CountryId;
            result.CreateUid = p40.CreateUid;
            result.UpdateUid = p40.UpdateUid;
            result.Libelle = p40.Libelle;
            result.CodeIso2 = p40.CodeIso2;
            result.CodeIso3 = p40.CodeIso3;
            result.PhoneCode = p40.PhoneCode;
            result.Devise = p40.Devise;
            return result;
            
        }
    }
}