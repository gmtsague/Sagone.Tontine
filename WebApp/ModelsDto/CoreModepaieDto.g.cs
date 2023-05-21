using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CoreModepaieDto
    {
        public int ModepaieId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Libelle { get; set; }
        public bool IsCash { get; set; }
        public ICollection<MeetEntreeCaisseDto> MeetEntreeCaisses { get; set; }
    }
}