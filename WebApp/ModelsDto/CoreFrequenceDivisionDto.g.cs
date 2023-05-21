using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CoreFrequenceDivisionDto
    {
        public int FrequenceId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Libelle { get; set; }
        public int NbDays { get; set; }
        public ICollection<CoreAnneeDto> CoreAnnees { get; set; }
    }
}