using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class MeetEngagement
{
    public long EngagementId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long RubriqueId { get; set; }

    public long PersonId { get; set; }

    public byte[] Cumulverse { get; set; } = null!;

    public byte[] ToPay { get; set; } = null!;

    public byte[] IsOutcome { get; set; } = null!;

    public byte[] IsClosed { get; set; } = null!;

    public byte[]? EngagementDate { get; set; }

    public byte[] CustomAmount { get; set; } = null!;

    public long NbReqSeances { get; set; }

    public virtual ICollection<MeetEntreeCaisse> MeetEntreeCaisses { get; set; } = new List<MeetEntreeCaisse>();

    public virtual ICollection<MeetSortieCaisse> MeetSortieCaisses { get; set; } = new List<MeetSortieCaisse>();

    public virtual CorePerson Person { get; set; } = null!;

    public virtual MeetRubrique Rubrique { get; set; } = null!;
}
