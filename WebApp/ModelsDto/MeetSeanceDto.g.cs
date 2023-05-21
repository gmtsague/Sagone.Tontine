using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetSeanceDto
    {
        public int SeanceId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int AnneeId { get; set; }
        public int DivisionId { get; set; }
        public int? EtabId { get; set; }
        public int? AntenneId { get; set; }
        public DateTime? Opendate { get; set; }
        public DateTime? Closedate { get; set; }
        public decimal TotalEntrees { get; set; }
        public decimal TotalSorties { get; set; }
        public decimal Depensecollation { get; set; }
        public string? Compterendu { get; set; }
        public int? Status { get; set; }
        public CoreSubdivisionDto CoreSubdivision { get; set; }
        public MeetAntenneDto? MeetAntenne { get; set; }
        public ICollection<MeetPresenceDto> MeetPresences { get; set; }
        public ICollection<MeetPretDto> MeetPrets { get; set; }
        public ICollection<MeetSortieCaisseDto> MeetSortieCaisses { get; set; }
    }
}