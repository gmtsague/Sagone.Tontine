using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetEngagementDto
    {
        public int EngagementId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int RubriqueId { get; set; }
        public int PersonId { get; set; }
        public decimal Cumulverse { get; set; }
        public decimal Solde { get; set; }
        public bool IsOutcome { get; set; }
        public bool IsClosed { get; set; }
        public DateOnly? EngagementDate { get; set; }
        public ICollection<MeetEntreeCaisseDto> MeetEntreeCaisses { get; set; }
        public ICollection<MeetSortieCaisseDto> MeetSortieCaisses { get; set; }
        public CorePersonDto Person { get; set; }
        public MeetRubriqueDto Rubrique { get; set; }
    }
}