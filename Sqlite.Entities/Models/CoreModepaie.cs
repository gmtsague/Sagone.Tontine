using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class CoreModepaie
{
    public long ModepaieId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public string Libelle { get; set; } = null!;

    public byte[] IsCash { get; set; } = null!;

    public virtual ICollection<MeetPresence> MeetPresences { get; set; } = new List<MeetPresence>();
}
