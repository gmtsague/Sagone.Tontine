using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class MeetPosteMapper
    {
        public static MeetPosteDto AdaptToDto(this MeetPoste p1)
        {
            return p1 == null ? null : new MeetPosteDto()
            {
                PosteId = p1.PosteId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                Libelle = p1.Libelle,
                Code = p1.Code
            };
        }
        public static MeetPosteDto AdaptTo(this MeetPoste p2, MeetPosteDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            MeetPosteDto result = p3 ?? new MeetPosteDto();
            
            result.PosteId = p2.PosteId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.Libelle = p2.Libelle;
            result.Code = p2.Code;
            return result;
            
        }
    }
}