using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class CoreFrequenceDivisionMapper
    {
        public static CoreFrequenceDivisionDto AdaptToDto(this CoreFrequenceDivision p1)
        {
            return p1 == null ? null : new CoreFrequenceDivisionDto()
            {
                FrequenceId = p1.FrequenceId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                Libelle = p1.Libelle,
                NbDays = p1.NbDays
            };
        }
        public static CoreFrequenceDivisionDto AdaptTo(this CoreFrequenceDivision p2, CoreFrequenceDivisionDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CoreFrequenceDivisionDto result = p3 ?? new CoreFrequenceDivisionDto();
            
            result.FrequenceId = p2.FrequenceId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.Libelle = p2.Libelle;
            result.NbDays = p2.NbDays;
            return result;
            
        }
    }
}