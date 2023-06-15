using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models1;

public partial class MeetMaxAllowSignature
{
    public long Id { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long AnneeId { get; set; }

    public long TyperubId { get; set; }

    public long MaxSignature { get; set; }

    public virtual CoreAnnee Annee { get; set; } = null!;

    public virtual MeetTypeRubrique Typerub { get; set; } = null!;
}
