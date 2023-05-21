using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class CoreBankaccountMapper
    {
        public static CoreBankaccountDto AdaptToDto(this CoreBankaccount p1)
        {
            return p1 == null ? null : new CoreBankaccountDto()
            {
                AccountId = p1.AccountId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                EtabId = p1.EtabId,
                PersonId = p1.PersonId,
                BankId = p1.BankId,
                CompteNo = p1.CompteNo,
                IsActive = p1.IsActive,
                Solde = p1.Solde,
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
        public static CoreBankaccountDto AdaptTo(this CoreBankaccount p2, CoreBankaccountDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CoreBankaccountDto result = p3 ?? new CoreBankaccountDto();
            
            result.AccountId = p2.AccountId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.EtabId = p2.EtabId;
            result.PersonId = p2.PersonId;
            result.BankId = p2.BankId;
            result.CompteNo = p2.CompteNo;
            result.IsActive = p2.IsActive;
            result.Solde = p2.Solde;
            result.Bank = funcMain1(p2.Bank, result.Bank);
            result.Etab = funcMain3(p2.Etab, result.Etab);
            result.Person = funcMain5(p2.Person, result.Person);
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
        
        private static CorePersonDto funcMain5(CorePerson p12, CorePersonDto p13)
        {
            if (p12 == null)
            {
                return null;
            }
            CorePersonDto result = p13 ?? new CorePersonDto();
            
            result.PersonId = p12.PersonId;
            result.CreateUid = p12.CreateUid;
            result.UpdateUid = p12.UpdateUid;
            result.CountryId = p12.CountryId;
            result.EtabId = p12.EtabId;
            result.Nom = p12.Nom;
            result.Prenom = p12.Prenom;
            result.Datenais = p12.Datenais;
            result.Lieunais = p12.Lieunais;
            result.Sexe = p12.Sexe;
            result.Email = p12.Email;
            result.Adresse = p12.Adresse;
            result.AdhesionDate = p12.AdhesionDate;
            result.Nocni = p12.Nocni;
            result.CniExpireDate = p12.CniExpireDate;
            result.IsActive = p12.IsActive;
            result.IsVisible = p12.IsVisible;
            result.AnneePromo = p12.AnneePromo;
            result.Country = funcMain6(p12.Country, result.Country);
            result.Etab = funcMain7(p12.Etab, result.Etab);
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
    }
}