using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class CoreCountryMapper
    {
        public static CoreCountryDto AdaptToDto(this CoreCountry p1)
        {
            return p1 == null ? null : new CoreCountryDto()
            {
                CountryId = p1.CountryId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                Libelle = p1.Libelle,
                CodeIso2 = p1.CodeIso2,
                CodeIso3 = p1.CodeIso3,
                PhoneCode = p1.PhoneCode,
                Devise = p1.Devise
            };
        }
        public static CoreCountryDto AdaptTo(this CoreCountry p2, CoreCountryDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CoreCountryDto result = p3 ?? new CoreCountryDto();
            
            result.CountryId = p2.CountryId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.Libelle = p2.Libelle;
            result.CodeIso2 = p2.CodeIso2;
            result.CodeIso3 = p2.CodeIso3;
            result.PhoneCode = p2.PhoneCode;
            result.Devise = p2.Devise;
            return result;
            
        }
    }
}