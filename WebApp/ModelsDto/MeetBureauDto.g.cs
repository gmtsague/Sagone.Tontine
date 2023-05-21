using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetBureauDto
    {
        public int BureauId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int? EtabId { get; set; }
        public string Libelle { get; set; }
        public DateOnly Debut { get; set; }
        public DateOnly Fin { get; set; }
        public int Nbperson { get; set; }
        public int Nbvotes { get; set; }
        public int Nbabstention { get; set; }
        public string? Resumevote { get; set; }
        public ICollection<CoreAnneeDto> CoreAnnees { get; set; }
        public CoreEtablissementDto? Etab { get; set; }
        public ICollection<MeetMembreBureauDto> MeetMembreBureaus { get; set; }
    }
}