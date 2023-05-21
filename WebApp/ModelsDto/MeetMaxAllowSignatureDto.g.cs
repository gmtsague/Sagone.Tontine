using System;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetMaxAllowSignatureDto
    {
        public int Id { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int AnneeId { get; set; }
        public int TyperubId { get; set; }
        public int MaxSignature { get; set; }
        public CoreAnneeDto Annee { get; set; }
        public MeetTypeRubriqueDto Typerub { get; set; }
    }
}