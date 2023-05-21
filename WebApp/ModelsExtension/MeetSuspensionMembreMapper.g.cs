using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class MeetSuspensionMembreMapper
    {
        public static MeetSuspensionMembreDto AdaptToDto(this MeetSuspensionMembre p1)
        {
            return p1 == null ? null : new MeetSuspensionMembreDto()
            {
                SuspensionId = p1.SuspensionId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                PersonId = p1.PersonId,
                DateSuspension = p1.DateSuspension,
                DateRetour = p1.DateRetour,
                IsActive = p1.IsActive,
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
        public static MeetSuspensionMembreDto AdaptTo(this MeetSuspensionMembre p2, MeetSuspensionMembreDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            MeetSuspensionMembreDto result = p3 ?? new MeetSuspensionMembreDto();
            
            result.SuspensionId = p2.SuspensionId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.PersonId = p2.PersonId;
            result.DateSuspension = p2.DateSuspension;
            result.DateRetour = p2.DateRetour;
            result.IsActive = p2.IsActive;
            result.Person = funcMain1(p2.Person, result.Person);
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