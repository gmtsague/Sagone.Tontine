using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetSortieCaisseDto
    {
        public int SortiecaisseId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int? Idinscrit { get; set; }
        public int SeanceId { get; set; }
        public int EngagementId { get; set; }
        public decimal MontantRoute { get; set; }
        public string? ListeMandataires { get; set; }
        public DateOnly Dateevts { get; set; }
        public decimal Montantpercu { get; set; }
        public string? Note { get; set; }
        public bool IsClosed { get; set; }
        public int Visarestants { get; set; }
        public MeetEngagementDto Engagement { get; set; }
        public MeetInscriptionDto? IdinscritNavigation { get; set; }
        public ICollection<MeetVisaDto> MeetVisas { get; set; }
        public MeetSeanceDto Seance { get; set; }
    }
}