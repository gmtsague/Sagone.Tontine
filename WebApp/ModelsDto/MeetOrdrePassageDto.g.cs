using System;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetOrdrePassageDto
    {
        public int PassageId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int AnneeId { get; set; }
        public int DivisionId { get; set; }
        public int Idinscrit { get; set; }
        public decimal Montantpercu { get; set; }
        public DateOnly? Heuredebut { get; set; }
        public string? Commentaire { get; set; }
        public CoreSubdivisionDto CoreSubdivision { get; set; }
        public MeetInscriptionDto IdinscritNavigation { get; set; }
    }
}