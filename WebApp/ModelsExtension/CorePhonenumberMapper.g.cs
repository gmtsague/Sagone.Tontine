using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class CorePhonenumberMapper
    {
        public static CorePhonenumberDto AdaptToDto(this CorePhonenumber p1)
        {
            return p1 == null ? null : new CorePhonenumberDto()
            {
                PhoneId = p1.PhoneId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                CountryId = p1.CountryId,
                BankId = p1.BankId,
                PersonId = p1.PersonId,
                PhoneNo = p1.PhoneNo,
                IsDefaut = p1.IsDefaut,
                Bank = p1.Bank == null ? null : new CoreBankDto()
                {
                    BankId = p1.Bank.BankId,
                    CreateUid = p1.Bank.CreateUid,
                    UpdateUid = p1.Bank.UpdateUid,
                    CountryId = p1.Bank.CountryId,
                    Libelle = p1.Bank.Libelle,
                    Adresse = p1.Bank.Adresse,
                    Email = p1.Bank.Email,
                    Coderib = p1.Bank.Coderib,
                    Country = p1.Bank.Country == null ? null : new CoreCountryDto()
                    {
                        CountryId = p1.Bank.Country.CountryId,
                        CreateUid = p1.Bank.Country.CreateUid,
                        UpdateUid = p1.Bank.Country.UpdateUid,
                        Libelle = p1.Bank.Country.Libelle,
                        CodeIso2 = p1.Bank.Country.CodeIso2,
                        CodeIso3 = p1.Bank.Country.CodeIso3,
                        PhoneCode = p1.Bank.Country.PhoneCode,
                        Devise = p1.Bank.Country.Devise
                    }
                },
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
        public static CorePhonenumberDto AdaptTo(this CorePhonenumber p2, CorePhonenumberDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CorePhonenumberDto result = p3 ?? new CorePhonenumberDto();
            
            result.PhoneId = p2.PhoneId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.CountryId = p2.CountryId;
            result.BankId = p2.BankId;
            result.PersonId = p2.PersonId;
            result.PhoneNo = p2.PhoneNo;
            result.IsDefaut = p2.IsDefaut;
            result.Bank = funcMain1(p2.Bank, result.Bank);
            result.Country = funcMain3(p2.Country, result.Country);
            result.Person = funcMain4(p2.Person, result.Person);
            return result;
            
        }
        
        private static CoreBankDto funcMain1(CoreBank p4, CoreBankDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            CoreBankDto result = p5 ?? new CoreBankDto();
            
            result.BankId = p4.BankId;
            result.CreateUid = p4.CreateUid;
            result.UpdateUid = p4.UpdateUid;
            result.CountryId = p4.CountryId;
            result.Libelle = p4.Libelle;
            result.Adresse = p4.Adresse;
            result.Email = p4.Email;
            result.Coderib = p4.Coderib;
            result.Country = funcMain2(p4.Country, result.Country);
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
        
        private static CorePersonDto funcMain4(CorePerson p10, CorePersonDto p11)
        {
            if (p10 == null)
            {
                return null;
            }
            CorePersonDto result = p11 ?? new CorePersonDto();
            
            result.PersonId = p10.PersonId;
            result.CreateUid = p10.CreateUid;
            result.UpdateUid = p10.UpdateUid;
            result.CountryId = p10.CountryId;
            result.EtabId = p10.EtabId;
            result.Nom = p10.Nom;
            result.Prenom = p10.Prenom;
            result.Datenais = p10.Datenais;
            result.Lieunais = p10.Lieunais;
            result.Sexe = p10.Sexe;
            result.Email = p10.Email;
            result.Adresse = p10.Adresse;
            result.AdhesionDate = p10.AdhesionDate;
            result.Nocni = p10.Nocni;
            result.CniExpireDate = p10.CniExpireDate;
            result.IsActive = p10.IsActive;
            result.IsVisible = p10.IsVisible;
            result.AnneePromo = p10.AnneePromo;
            result.Country = funcMain5(p10.Country, result.Country);
            result.Etab = funcMain6(p10.Etab, result.Etab);
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
    }
}