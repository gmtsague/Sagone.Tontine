using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models1;

public partial class MeetSortieCaisse
{
    public long SortiecaisseId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long? Idinscrit { get; set; }

    public long SeanceId { get; set; }

    public long EngagementId { get; set; }

    public string RefNo { get; set; } = null!;

    public byte[] Dateevts { get; set; } = null!;

    public byte[] Montantpercu { get; set; } = null!;

    public string? Note { get; set; }

    public byte[] IsClosed { get; set; } = null!;

    public byte[] BenefPrincipal { get; set; } = null!;

    public long Visarestants { get; set; }

    public virtual MeetEngagement Engagement { get; set; } = null!;

    public virtual MeetInscription? IdinscritNavigation { get; set; }

    public virtual ICollection<MeetVisa> MeetVisas { get; set; } = new List<MeetVisa>();

    public virtual MeetSeance Seance { get; set; } = null!;
}
