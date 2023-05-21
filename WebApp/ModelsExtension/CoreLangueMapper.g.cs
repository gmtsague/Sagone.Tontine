using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class CoreLangueMapper
    {
        public static CoreLangueDto AdaptToDto(this CoreLangue p1)
        {
            return p1 == null ? null : new CoreLangueDto()
            {
                LangueId = p1.LangueId,
                Libelle = p1.Libelle,
                Isocode = p1.Isocode,
                IsDefault = p1.IsDefault,
                IsActive = p1.IsActive
            };
        }
        public static CoreLangueDto AdaptTo(this CoreLangue p2, CoreLangueDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CoreLangueDto result = p3 ?? new CoreLangueDto();
            
            result.LangueId = p2.LangueId;
            result.Libelle = p2.Libelle;
            result.Isocode = p2.Isocode;
            result.IsDefault = p2.IsDefault;
            result.IsActive = p2.IsActive;
            return result;
            
        }
    }
}