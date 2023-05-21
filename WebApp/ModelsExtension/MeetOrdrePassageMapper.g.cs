using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class MeetOrdrePassageMapper
    {
        public static MeetOrdrePassageDto AdaptToDto(this MeetOrdrePassage p1)
        {
            return p1 == null ? null : new MeetOrdrePassageDto()
            {
                PassageId = p1.PassageId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                AnneeId = p1.AnneeId,
                DivisionId = p1.DivisionId,
                Idinscrit = p1.Idinscrit,
                Montantpercu = p1.Montantpercu,
                Heuredebut = p1.Heuredebut,
                Commentaire = p1.Commentaire
            };
        }
        public static MeetOrdrePassageDto AdaptTo(this MeetOrdrePassage p2, MeetOrdrePassageDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            MeetOrdrePassageDto result = p3 ?? new MeetOrdrePassageDto();
            
            result.PassageId = p2.PassageId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.AnneeId = p2.AnneeId;
            result.DivisionId = p2.DivisionId;
            result.Idinscrit = p2.Idinscrit;
            result.Montantpercu = p2.Montantpercu;
            result.Heuredebut = p2.Heuredebut;
            result.Commentaire = p2.Commentaire;
            return result;
            
        }
    }
}