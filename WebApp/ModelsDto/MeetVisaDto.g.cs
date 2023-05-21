using System;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetVisaDto
    {
        public int VisaId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int Idinscrit { get; set; }
        public int ConfigvisaId { get; set; }
        public int? SortiecaisseId { get; set; }
        public int? MeetOperation { get; set; }
        public DateOnly Datesign { get; set; }
        public bool SignByOrdre { get; set; }
        public bool Receiver { get; set; }
        public MeetConfigVisaDto Configvisa { get; set; }
        public MeetInscriptionDto IdinscritNavigation { get; set; }
        public MeetPretDto? MeetOperationNavigation { get; set; }
        public MeetSortieCaisseDto? Sortiecaisse { get; set; }
    }
}