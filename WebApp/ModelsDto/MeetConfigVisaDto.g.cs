using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetConfigVisaDto
    {
        public int ConfigvisaId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int PosteId { get; set; }
        public int AnneeId { get; set; }
        public int TyperubId { get; set; }
        public int Numordre { get; set; }
        public bool SignByOrdre { get; set; }
        public CoreAnneeDto Annee { get; set; }
        public ICollection<MeetVisaDto> MeetVisas { get; set; }
        public MeetPosteDto Poste { get; set; }
        public MeetTypeRubriqueDto Typerub { get; set; }
    }
}