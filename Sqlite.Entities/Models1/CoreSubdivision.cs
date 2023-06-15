using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models1;

public partial class CoreSubdivision
{
    public long DivisionId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long AnneeId { get; set; }

    public string Libelle { get; set; } = null!;

    public byte[] MonthDate { get; set; } = null!;

    public long? MonthDay { get; set; }

    public long Numordre { get; set; }

    public virtual CoreAnnee Annee { get; set; } = null!;

    public virtual ICollection<MeetOrdrePassage> MeetOrdrePassages { get; set; } = new List<MeetOrdrePassage>();

    public virtual ICollection<MeetSeance> MeetSeances { get; set; } = new List<MeetSeance>();
}
