using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models1;

public partial class CorePhoto
{
    public long PhotoId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long? EtabId { get; set; }

    public long? PersonId { get; set; }

    public string Image { get; set; } = null!;

    public string? Filename { get; set; }

    public string Fileext { get; set; } = null!;

    public byte[] IsSignature { get; set; } = null!;

    public string? Filepath { get; set; }

    public long MaxAllowLiens { get; set; }

    public long NbActualLiens { get; set; }

    public virtual CoreEtablissement? Etab { get; set; }

    public virtual CorePerson? Person { get; set; }
}
