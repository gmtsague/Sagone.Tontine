using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetTypeRubriqueDto
    {
        public int TyperubId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Libelle { get; set; }
        public bool IsOutcome { get; set; }
        public int Nbmandataire { get; set; }
        public decimal Montantroute { get; set; }
        public decimal MontantPerson { get; set; }
        public decimal Montantpenalite { get; set; }
        public string Code { get; set; }
        public bool Candelete { get; set; }
        public int Maxsignature { get; set; }
        public bool AutoGenerated { get; set; }
        public bool Required { get; set; }
        public bool IsActive { get; set; }
        public int Numordre { get; set; }
        public ICollection<MeetConfigVisaDto> MeetConfigVisas { get; set; }
        public ICollection<MeetMaxAllowSignatureDto> MeetMaxAllowSignatures { get; set; }
        public ICollection<MeetRubriqueDto> MeetRubriques { get; set; }
    }
}