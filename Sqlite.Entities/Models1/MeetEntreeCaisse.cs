using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models1;

public partial class MeetEntreeCaisse
{
    public long OperationId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long PresenceId { get; set; }

    public long? EngagementId { get; set; }

    public byte[] Montantverse { get; set; } = null!;

    public byte[] IsOutcome { get; set; } = null!;

    public virtual MeetEngagement? Engagement { get; set; }

    public virtual MeetPresence Presence { get; set; } = null!;
}
