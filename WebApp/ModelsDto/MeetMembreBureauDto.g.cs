using System;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetMembreBureauDto
    {
        public int BureaudetailsId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int Idinscrit { get; set; }
        public int PosteId { get; set; }
        public int BureauId { get; set; }
        public MeetBureauDto Bureau { get; set; }
        public MeetInscriptionDto IdinscritNavigation { get; set; }
        public MeetPosteDto Poste { get; set; }
    }
}