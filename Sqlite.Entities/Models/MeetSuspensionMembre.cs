using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class MeetSuspensionMembre
{
    public long SuspensionId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long PersonId { get; set; }

    public byte[] DateSuspension { get; set; } = null!;

    public byte[]? DateRetour { get; set; }

    public byte[] IsActive { get; set; } = null!;

    public virtual CorePerson Person { get; set; } = null!;
}
