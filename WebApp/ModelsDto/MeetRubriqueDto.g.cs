using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetRubriqueDto
    {
        public int RubriqueId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int AnneeId { get; set; }
        public int TyperubId { get; set; }
        public string Libelle { get; set; }
        public int Nbmandataire { get; set; }
        public decimal Montantroute { get; set; }
        public decimal MontantPerson { get; set; }
        public bool IsOutcome { get; set; }
        public string? Commentaire { get; set; }
        public CoreAnneeDto Annee { get; set; }
        public ICollection<MeetEngagementDto> MeetEngagements { get; set; }
        public MeetTypeRubriqueDto Typerub { get; set; }
    }
}