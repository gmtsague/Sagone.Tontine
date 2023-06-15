using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class MeetVisa
{
    public long VisaId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long Idinscrit { get; set; }

    public long ConfigvisaId { get; set; }

    public long? SortiecaisseId { get; set; }

    public long? MeetOperation { get; set; }

    public byte[] Datesign { get; set; } = null!;

    public byte[] SignByOrdre { get; set; } = null!;

    public byte[] Receiver { get; set; } = null!;

    public virtual MeetConfigVisa Configvisa { get; set; } = null!;

    public virtual MeetInscription IdinscritNavigation { get; set; } = null!;

    public virtual MeetPret? MeetOperationNavigation { get; set; }

    public virtual MeetSortieCaisse? Sortiecaisse { get; set; }
}
