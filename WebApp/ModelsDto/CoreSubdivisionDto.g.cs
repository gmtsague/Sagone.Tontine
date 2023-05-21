using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CoreSubdivisionDto
    {
        public int AnneeId { get; set; }
        public int DivisionId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public string Libelle { get; set; }
        public DateOnly MonthDate { get; set; }
        public int? MonthDay { get; set; }
        public int Numordre { get; set; }
        public CoreAnneeDto Annee { get; set; }
        public ICollection<MeetOrdrePassageDto> MeetOrdrePassages { get; set; }
        public ICollection<MeetSeanceDto> MeetSeances { get; set; }
    }
}