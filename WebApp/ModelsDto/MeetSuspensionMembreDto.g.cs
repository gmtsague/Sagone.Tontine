using System;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetSuspensionMembreDto
    {
        public int SuspensionId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int PersonId { get; set; }
        public DateOnly DateSuspension { get; set; }
        public DateOnly? DateRetour { get; set; }
        public bool IsActive { get; set; }
        public CorePersonDto Person { get; set; }
    }
}