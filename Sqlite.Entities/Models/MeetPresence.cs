using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class MeetPresence
{
    public long PresenceId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long SeanceId { get; set; }

    public long? ModepaieId { get; set; }

    public long Idinscrit { get; set; }

    public byte[] Dateop { get; set; } = null!;

    public byte[] IsAbsent { get; set; } = null!;

    public byte[] VerseCash { get; set; } = null!;

    public byte[] VerseTransfert { get; set; } = null!;

    public byte[] Globalverse { get; set; } = null!;

    public string? NumBordero { get; set; }

    public virtual MeetInscription IdinscritNavigation { get; set; } = null!;

    public virtual ICollection<MeetEntreeCaisse> MeetEntreeCaisses { get; set; } = new List<MeetEntreeCaisse>();

    public virtual CoreModepaie? Modepaie { get; set; }

    public virtual MeetSeance Seance { get; set; } = null!;
}
