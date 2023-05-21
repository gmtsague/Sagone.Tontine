using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetAntenneDto
    {
        public int EtabId { get; set; }
        public int AntenneId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Libelle { get; set; }
        public DateOnly? Creationdate { get; set; }
        public CoreEtablissementDto Etab { get; set; }
        public ICollection<MeetInscriptionDto> MeetInscriptions { get; set; }
        public ICollection<MeetSeanceDto> MeetSeances { get; set; }
    }
}