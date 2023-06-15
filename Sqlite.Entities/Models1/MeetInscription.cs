using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models1;

public partial class MeetInscription
{
    public long Idinscrit { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long AntenneId { get; set; }

    public long PersonId { get; set; }

    public long AnneeId { get; set; }

    public byte[] Dateinscrit { get; set; } = null!;

    public byte[]? Datesuspension { get; set; }

    public byte[] IsActive { get; set; } = null!;

    public string Nocni { get; set; } = null!;

    public byte[] Soldedebut { get; set; } = null!;

    public byte[] Soldefin { get; set; } = null!;

    public byte[] Tauxcotisation { get; set; } = null!;

    public byte[] TotalVerse { get; set; } = null!;

    public byte[] Cumuldettes { get; set; } = null!;

    public byte[] Cumulpenalites { get; set; } = null!;

    public byte[] Endette { get; set; } = null!;

    public byte[] ReportNouveau { get; set; } = null!;

    public virtual CoreAnnee Annee { get; set; } = null!;

    public virtual MeetAntenne Antenne { get; set; } = null!;

    public virtual ICollection<MeetMembreBureau> MeetMembreBureaus { get; set; } = new List<MeetMembreBureau>();

    public virtual ICollection<MeetOrdrePassage> MeetOrdrePassages { get; set; } = new List<MeetOrdrePassage>();

    public virtual ICollection<MeetPresence> MeetPresences { get; set; } = new List<MeetPresence>();

    public virtual ICollection<MeetPret> MeetPrets { get; set; } = new List<MeetPret>();

    public virtual ICollection<MeetSortieCaisse> MeetSortieCaisses { get; set; } = new List<MeetSortieCaisse>();

    public virtual ICollection<MeetVisa> MeetVisas { get; set; } = new List<MeetVisa>();

    public virtual CorePerson Person { get; set; } = null!;
}
