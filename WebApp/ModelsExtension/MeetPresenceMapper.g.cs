using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class MeetPresenceMapper
    {
        public static MeetPresenceDto AdaptToDto(this MeetPresence p1)
        {
            return p1 == null ? null : new MeetPresenceDto()
            {
                PresenceId = p1.PresenceId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                SeanceId = p1.SeanceId,
                Idinscrit = p1.Idinscrit,
                Dateop = p1.Dateop,
                IsAbsent = p1.IsAbsent,
                Globalverse = p1.Globalverse,
                NumBordero = p1.NumBordero,
                Seance = p1.Seance == null ? null : new MeetSeanceDto()
                {
                    SeanceId = p1.Seance.SeanceId,
                    CreateUid = p1.Seance.CreateUid,
                    UpdateUid = p1.Seance.UpdateUid,
                    AnneeId = p1.Seance.AnneeId,
                    DivisionId = p1.Seance.DivisionId,
                    EtabId = p1.Seance.EtabId,
                    AntenneId = p1.Seance.AntenneId,
                    Opendate = p1.Seance.Opendate,
                    Closedate = p1.Seance.Closedate,
                    TotalEntrees = p1.Seance.TotalEntrees,
                    TotalSorties = p1.Seance.TotalSorties,
                    Depensecollation = p1.Seance.Depensecollation,
                    Compterendu = p1.Seance.Compterendu,
                    Status = p1.Seance.Status
                }
            };
        }
        public static MeetPresenceDto AdaptTo(this MeetPresence p2, MeetPresenceDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            MeetPresenceDto result = p3 ?? new MeetPresenceDto();
            
            result.PresenceId = p2.PresenceId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.SeanceId = p2.SeanceId;
            result.Idinscrit = p2.Idinscrit;
            result.Dateop = p2.Dateop;
            result.IsAbsent = p2.IsAbsent;
            result.Globalverse = p2.Globalverse;
            result.NumBordero = p2.NumBordero;
            result.Seance = funcMain1(p2.Seance, result.Seance);
            return result;
            
        }
        
        private static MeetSeanceDto funcMain1(MeetSeance p4, MeetSeanceDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            MeetSeanceDto result = p5 ?? new MeetSeanceDto();
            
            result.SeanceId = p4.SeanceId;
            result.CreateUid = p4.CreateUid;
            result.UpdateUid = p4.UpdateUid;
            result.AnneeId = p4.AnneeId;
            result.DivisionId = p4.DivisionId;
            result.EtabId = p4.EtabId;
            result.AntenneId = p4.AntenneId;
            result.Opendate = p4.Opendate;
            result.Closedate = p4.Closedate;
            result.TotalEntrees = p4.TotalEntrees;
            result.TotalSorties = p4.TotalSorties;
            result.Depensecollation = p4.Depensecollation;
            result.Compterendu = p4.Compterendu;
            result.Status = p4.Status;
            return result;
            
        }
    }
}