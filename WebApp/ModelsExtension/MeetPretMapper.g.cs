using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class MeetPretMapper
    {
        public static MeetPretDto AdaptToDto(this MeetPret p1)
        {
            return p1 == null ? null : new MeetPretDto()
            {
                SortiecaisseId = p1.SortiecaisseId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                Idinscrit = p1.Idinscrit,
                SeanceId = p1.SeanceId,
                RefNo = p1.RefNo,
                DureeInitiale = p1.DureeInitiale,
                MontantInteret = p1.MontantInteret,
                MontantPenalite = p1.MontantPenalite,
                DureeFinale = p1.DureeFinale,
                Dateevts = p1.Dateevts,
                Montantpercu = p1.Montantpercu,
                Note = p1.Note,
                IsClosed = p1.IsClosed,
                Visarestants = p1.Visarestants,
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
        public static MeetPretDto AdaptTo(this MeetPret p2, MeetPretDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            MeetPretDto result = p3 ?? new MeetPretDto();
            
            result.SortiecaisseId = p2.SortiecaisseId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.Idinscrit = p2.Idinscrit;
            result.SeanceId = p2.SeanceId;
            result.RefNo = p2.RefNo;
            result.DureeInitiale = p2.DureeInitiale;
            result.MontantInteret = p2.MontantInteret;
            result.MontantPenalite = p2.MontantPenalite;
            result.DureeFinale = p2.DureeFinale;
            result.Dateevts = p2.Dateevts;
            result.Montantpercu = p2.Montantpercu;
            result.Note = p2.Note;
            result.IsClosed = p2.IsClosed;
            result.Visarestants = p2.Visarestants;
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