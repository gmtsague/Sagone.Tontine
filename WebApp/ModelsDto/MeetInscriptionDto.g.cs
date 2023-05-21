using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetInscriptionDto
    {
        public int Idinscrit { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int EtabId { get; set; }
        public int AntenneId { get; set; }
        public int PersonId { get; set; }
        public int AnneeId { get; set; }
        public DateOnly Dateinscrit { get; set; }
        public DateOnly? Datesuspension { get; set; }
        public bool IsActive { get; set; }
        public string Nocni { get; set; }
        public decimal Soldedebut { get; set; }
        public decimal? Soldefin { get; set; }
        public decimal Tauxcotisation { get; set; }
        public decimal TotalVerse { get; set; }
        public decimal? Cumuldettes { get; set; }
        public decimal? Cumulpenalites { get; set; }
        public bool Endette { get; set; }
        public decimal ReportNouveau { get; set; }
        public CoreAnneeDto Annee { get; set; }
        public MeetAntenneDto MeetAntenne { get; set; }
        public ICollection<MeetMembreBureauDto> MeetMembreBureaus { get; set; }
        public ICollection<MeetOrdrePassageDto> MeetOrdrePassages { get; set; }
        public ICollection<MeetPresenceDto> MeetPresences { get; set; }
        public ICollection<MeetPretDto> MeetPrets { get; set; }
        public ICollection<MeetSortieCaisseDto> MeetSortieCaisses { get; set; }
        public ICollection<MeetVisaDto> MeetVisas { get; set; }
        public CorePersonDto Person { get; set; }
    }
}