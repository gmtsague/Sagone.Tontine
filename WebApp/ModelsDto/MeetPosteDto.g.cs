using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetPosteDto
    {
        public int PosteId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Libelle { get; set; }
        public string Code { get; set; }
        public ICollection<MeetConfigVisaDto> MeetConfigVisas { get; set; }
        public ICollection<MeetMembreBureauDto> MeetMembreBureaus { get; set; }
    }
}