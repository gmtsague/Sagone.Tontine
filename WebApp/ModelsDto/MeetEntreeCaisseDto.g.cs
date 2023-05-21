using System;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetEntreeCaisseDto
    {
        public int OperationId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int PresenceId { get; set; }
        public int? EngagementId { get; set; }
        public int ModepaieId { get; set; }
        public decimal Montantverse { get; set; }
        public bool IsOutcome { get; set; }
        public MeetEngagementDto? Engagement { get; set; }
        public CoreModepaieDto Modepaie { get; set; }
        public MeetPresenceDto Presence { get; set; }
    }
}