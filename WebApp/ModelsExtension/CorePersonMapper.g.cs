using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class CorePersonMapper
    {
        public static CorePersonDto AdaptToDto(this CorePerson p1)
        {
            return p1 == null ? null : new CorePersonDto()
            {
                PersonId = p1.PersonId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                CountryId = p1.CountryId,
                EtabId = p1.EtabId,
                Nom = p1.Nom,
                Prenom = p1.Prenom,
                Datenais = p1.Datenais,
                Lieunais = p1.Lieunais,
                Sexe = p1.Sexe,
                Email = p1.Email,
                Adresse = p1.Adresse,
                AdhesionDate = p1.AdhesionDate,
                Nocni = p1.Nocni,
                CniExpireDate = p1.CniExpireDate,
                IsActive = p1.IsActive,
                IsVisible = p1.IsVisible,
                AnneePromo = p1.AnneePromo,
                Country = p1.Country == null ? null : new CoreCountryDto()
                {
                    CountryId = p1.Country.CountryId,
                    CreateUid = p1.Country.CreateUid,
                    UpdateUid = p1.Country.UpdateUid,
                    Libelle = p1.Country.Libelle,
                    CodeIso2 = p1.Country.CodeIso2,
                    CodeIso3 = p1.Country.CodeIso3,
                    PhoneCode = p1.Country.PhoneCode,
                    Devise = p1.Country.Devise
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
        public static CorePersonDto AdaptTo(this CorePerson p2, CorePersonDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CorePersonDto result = p3 ?? new CorePersonDto();
            
            result.PersonId = p2.PersonId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.CountryId = p2.CountryId;
            result.EtabId = p2.EtabId;
            result.Nom = p2.Nom;
            result.Prenom = p2.Prenom;
            result.Datenais = p2.Datenais;
            result.Lieunais = p2.Lieunais;
            result.Sexe = p2.Sexe;
            result.Email = p2.Email;
            result.Adresse = p2.Adresse;
            result.AdhesionDate = p2.AdhesionDate;
            result.Nocni = p2.Nocni;
            result.CniExpireDate = p2.CniExpireDate;
            result.IsActive = p2.IsActive;
            result.IsVisible = p2.IsVisible;
            result.AnneePromo = p2.AnneePromo;
            result.Country = funcMain1(p2.Country, result.Country);
            result.Etab = funcMain2(p2.Etab, result.Etab);
            return result;
            
        }
        
        private static CoreCountryDto funcMain1(CoreCountry p4, CoreCountryDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            CoreCountryDto result = p5 ?? new CoreCountryDto();
            
            result.CountryId = p4.CountryId;
            result.CreateUid = p4.CreateUid;
            result.UpdateUid = p4.UpdateUid;
            result.Libelle = p4.Libelle;
            result.CodeIso2 = p4.CodeIso2;
            result.CodeIso3 = p4.CodeIso3;
            result.PhoneCode = p4.PhoneCode;
            result.Devise = p4.Devise;
            return result;
            
        }
        
        private static CoreEtablissementDto funcMain2(CoreEtablissement p6, CoreEtablissementDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            CoreEtablissementDto result = p7 ?? new CoreEtablissementDto();
            
            result.EtabId = p6.EtabId;
            result.CreateUid = p6.CreateUid;
            result.UpdateUid = p6.UpdateUid;
            result.CountryId = p6.CountryId;
            result.Libelle = p6.Libelle;
            result.Adresse = p6.Adresse;
            result.Creationdate = p6.Creationdate;
            result.DeployedUrl = p6.DeployedUrl;
            result.DatabaseName = p6.DatabaseName;
            result.ConnString = p6.ConnString;
            result.EnableMultiAntenne = p6.EnableMultiAntenne;
            result.Country = funcMain3(p6.Country, result.Country);
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
    }
}