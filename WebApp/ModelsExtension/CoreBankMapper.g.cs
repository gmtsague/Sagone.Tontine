using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class CoreBankMapper
    {
        public static CoreBankDto AdaptToDto(this CoreBank p1)
        {
            return p1 == null ? null : new CoreBankDto()
            {
                BankId = p1.BankId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                CountryId = p1.CountryId,
                Libelle = p1.Libelle,
                Adresse = p1.Adresse,
                Email = p1.Email,
                Coderib = p1.Coderib,
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
                }
            };
        }
        public static CoreBankDto AdaptTo(this CoreBank p2, CoreBankDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CoreBankDto result = p3 ?? new CoreBankDto();
            
            result.BankId = p2.BankId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.CountryId = p2.CountryId;
            result.Libelle = p2.Libelle;
            result.Adresse = p2.Adresse;
            result.Email = p2.Email;
            result.Coderib = p2.Coderib;
            result.Country = funcMain1(p2.Country, result.Country);
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
    }
}