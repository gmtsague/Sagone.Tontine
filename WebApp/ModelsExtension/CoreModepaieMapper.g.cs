using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class CoreModepaieMapper
    {
        public static CoreModepaieDto AdaptToDto(this CoreModepaie p1)
        {
            return p1 == null ? null : new CoreModepaieDto()
            {
                ModepaieId = p1.ModepaieId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                Libelle = p1.Libelle,
                IsCash = p1.IsCash
            };
        }
        public static CoreModepaieDto AdaptTo(this CoreModepaie p2, CoreModepaieDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CoreModepaieDto result = p3 ?? new CoreModepaieDto();
            
            result.ModepaieId = p2.ModepaieId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.Libelle = p2.Libelle;
            result.IsCash = p2.IsCash;
            return result;
            
        }
    }
}