using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models1;

public partial class MeetSeance
{
    public long SeanceId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long DivisionId { get; set; }

    public long? AntenneId { get; set; }

    public byte[]? Opendate { get; set; }

    public byte[]? Closedate { get; set; }

    public byte[] TotalEntrees { get; set; } = null!;

    public byte[] TotalSorties { get; set; } = null!;

    public byte[] Depensecollation { get; set; } = null!;

    public string? Compterendu { get; set; }

    public long? Status { get; set; }

    public virtual MeetAntenne? Antenne { get; set; }

    public virtual CoreSubdivision Division { get; set; } = null!;

    public virtual ICollection<MeetPresence> MeetPresences { get; set; } = new List<MeetPresence>();

    public virtual ICollection<MeetPret> MeetPrets { get; set; } = new List<MeetPret>();

    public virtual ICollection<MeetSortieCaisse> MeetSortieCaisses { get; set; } = new List<MeetSortieCaisse>();
}
