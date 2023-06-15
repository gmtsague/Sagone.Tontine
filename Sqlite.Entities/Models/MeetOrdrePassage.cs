using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class MeetOrdrePassage
{
    public long PassageId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long DivisionId { get; set; }

    public long Idinscrit { get; set; }

    public byte[] Montantpercu { get; set; } = null!;

    public byte[]? Heuredebut { get; set; }

    public string? Commentaire { get; set; }

    public virtual CoreSubdivision Division { get; set; } = null!;

    public virtual MeetInscription IdinscritNavigation { get; set; } = null!;
}
