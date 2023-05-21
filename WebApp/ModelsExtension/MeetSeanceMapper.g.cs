using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class MeetSeanceMapper
    {
        public static MeetSeanceDto AdaptToDto(this MeetSeance p1)
        {
            return p1 == null ? null : new MeetSeanceDto()
            {
                SeanceId = p1.SeanceId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                AnneeId = p1.AnneeId,
                DivisionId = p1.DivisionId,
                EtabId = p1.EtabId,
                AntenneId = p1.AntenneId,
                Opendate = p1.Opendate,
                Closedate = p1.Closedate,
                TotalEntrees = p1.TotalEntrees,
                TotalSorties = p1.TotalSorties,
                Depensecollation = p1.Depensecollation,
                Compterendu = p1.Compterendu,
                Status = p1.Status
            };
        }
        public static MeetSeanceDto AdaptTo(this MeetSeance p2, MeetSeanceDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            MeetSeanceDto result = p3 ?? new MeetSeanceDto();
            
            result.SeanceId = p2.SeanceId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.AnneeId = p2.AnneeId;
            result.DivisionId = p2.DivisionId;
            result.EtabId = p2.EtabId;
            result.AntenneId = p2.AntenneId;
            result.Opendate = p2.Opendate;
            result.Closedate = p2.Closedate;
            result.TotalEntrees = p2.TotalEntrees;
            result.TotalSorties = p2.TotalSorties;
            result.Depensecollation = p2.Depensecollation;
            result.Compterendu = p2.Compterendu;
            result.Status = p2.Status;
            return result;
            
        }
    }
}