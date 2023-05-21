using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class CorePhotoMapper
    {
        public static CorePhotoDto AdaptToDto(this CorePhoto p1)
        {
            return p1 == null ? null : new CorePhotoDto()
            {
                PhotoId = p1.PhotoId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                EtabId = p1.EtabId,
                PersonId = p1.PersonId,
                Image = p1.Image,
                Filename = p1.Filename,
                Fileext = p1.Fileext,
                IsSignature = p1.IsSignature,
                Filepath = p1.Filepath,
                MaxAllowLiens = p1.MaxAllowLiens,
                NbActualLiens = p1.NbActualLiens,
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
        public static CorePhotoDto AdaptTo(this CorePhoto p2, CorePhotoDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CorePhotoDto result = p3 ?? new CorePhotoDto();
            
            result.PhotoId = p2.PhotoId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.EtabId = p2.EtabId;
            result.PersonId = p2.PersonId;
            result.Image = p2.Image;
            result.Filename = p2.Filename;
            result.Fileext = p2.Fileext;
            result.IsSignature = p2.IsSignature;
            result.Filepath = p2.Filepath;
            result.MaxAllowLiens = p2.MaxAllowLiens;
            result.NbActualLiens = p2.NbActualLiens;
            result.Etab = funcMain1(p2.Etab, result.Etab);
            result.Person = funcMain3(p2.Person, result.Person);
            return result;
            
        }
        
        private static CoreEtablissementDto funcMain1(CoreEtablissement p4, CoreEtablissementDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            CoreEtablissementDto result = p5 ?? new CoreEtablissementDto();
            
            result.EtabId = p4.EtabId;
            result.CreateUid = p4.CreateUid;
            result.UpdateUid = p4.UpdateUid;
            result.CountryId = p4.CountryId;
            result.Libelle = p4.Libelle;
            result.Adresse = p4.Adresse;
            result.Creationdate = p4.Creationdate;
            result.DeployedUrl = p4.DeployedUrl;
            result.DatabaseName = p4.DatabaseName;
            result.ConnString = p4.ConnString;
            result.EnableMultiAntenne = p4.EnableMultiAntenne;
            result.Country = funcMain2(p4.Country, result.Country);
            return result;
            
        }
        
        private static CorePersonDto funcMain3(CorePerson p8, CorePersonDto p9)
        {
            if (p8 == null)
            {
                return null;
            }
            CorePersonDto result = p9 ?? new CorePersonDto();
            
            result.PersonId = p8.PersonId;
            result.CreateUid = p8.CreateUid;
            result.UpdateUid = p8.UpdateUid;
            result.CountryId = p8.CountryId;
            result.EtabId = p8.EtabId;
            result.Nom = p8.Nom;
            result.Prenom = p8.Prenom;
            result.Datenais = p8.Datenais;
            result.Lieunais = p8.Lieunais;
            result.Sexe = p8.Sexe;
            result.Email = p8.Email;
            result.Adresse = p8.Adresse;
            result.AdhesionDate = p8.AdhesionDate;
            result.Nocni = p8.Nocni;
            result.CniExpireDate = p8.CniExpireDate;
            result.IsActive = p8.IsActive;
            result.IsVisible = p8.IsVisible;
            result.AnneePromo = p8.AnneePromo;
            result.Country = funcMain4(p8.Country, result.Country);
            result.Etab = funcMain5(p8.Etab, result.Etab);
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
        
        private static CoreEtablissementDto funcMain5(CoreEtablissement p12, CoreEtablissementDto p13)
        {
            if (p12 == null)
            {
                return null;
            }
            CoreEtablissementDto result = p13 ?? new CoreEtablissementDto();
            
            result.EtabId = p12.EtabId;
            result.CreateUid = p12.CreateUid;
            result.UpdateUid = p12.UpdateUid;
            result.CountryId = p12.CountryId;
            result.Libelle = p12.Libelle;
            result.Adresse = p12.Adresse;
            result.Creationdate = p12.Creationdate;
            result.DeployedUrl = p12.DeployedUrl;
            result.DatabaseName = p12.DatabaseName;
            result.ConnString = p12.ConnString;
            result.EnableMultiAntenne = p12.EnableMultiAntenne;
            result.Country = funcMain6(p12.Country, result.Country);
            return result;
            
        }
        
        private static CoreCountryDto funcMain6(CoreCountry p14, CoreCountryDto p15)
        {
            if (p14 == null)
            {
                return null;
            }
            CoreCountryDto result = p15 ?? new CoreCountryDto();
            
            result.CountryId = p14.CountryId;
            result.CreateUid = p14.CreateUid;
            result.UpdateUid = p14.UpdateUid;
            result.Libelle = p14.Libelle;
            result.CodeIso2 = p14.CodeIso2;
            result.CodeIso3 = p14.CodeIso3;
            result.PhoneCode = p14.PhoneCode;
            result.Devise = p14.Devise;
            return result;
            
        }
    }
}