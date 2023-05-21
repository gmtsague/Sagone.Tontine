using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetPresenceDto
    {
        public int PresenceId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int SeanceId { get; set; }
        public int Idinscrit { get; set; }
        public DateOnly Dateop { get; set; }
        public bool IsAbsent { get; set; }
        public decimal Globalverse { get; set; }
        public string? NumBordero { get; set; }
        public MeetInscriptionDto IdinscritNavigation { get; set; }
        public ICollection<MeetEntreeCaisseDto> MeetEntreeCaisses { get; set; }
        public MeetSeanceDto Seance { get; set; }
    }
}