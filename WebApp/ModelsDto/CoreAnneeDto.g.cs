using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CoreAnneeDto
    {
        public int AnneeId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public int FrequenceId { get; set; }
        public int? BureauId { get; set; }
        public int? Previous { get; set; }
        public string Libelle { get; set; }
        public DateOnly Datedebut { get; set; }
        public DateOnly Datefin { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsClosed { get; set; }
        public int Nbdivision { get; set; }
        public bool CopyDataFromPrevious { get; set; }
        public MeetBureauDto? Bureau { get; set; }
        public ICollection<CoreAnnualSettingDto> CoreAnnualSettings { get; set; }
        public ICollection<CoreSubdivisionDto> CoreSubdivisions { get; set; }
        public CoreFrequenceDivisionDto Frequence { get; set; }
        public ICollection<CoreAnneeDto> InversePreviousNavigation { get; set; }
        public ICollection<MeetConfigVisaDto> MeetConfigVisas { get; set; }
        public ICollection<MeetInscriptionDto> MeetInscriptions { get; set; }
        public ICollection<MeetMaxAllowSignatureDto> MeetMaxAllowSignatures { get; set; }
        public ICollection<MeetRubriqueDto> MeetRubriques { get; set; }
        public CoreAnneeDto? PreviousNavigation { get; set; }
    }
}