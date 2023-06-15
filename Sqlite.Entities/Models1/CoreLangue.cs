using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models1;

public partial class CoreLangue
{
    public long LangueId { get; set; }

    public byte[] Libelle { get; set; } = null!;

    public string Isocode { get; set; } = null!;

    public byte[] IsDefault { get; set; } = null!;

    public byte[] IsActive { get; set; } = null!;

    public virtual ICollection<CoreUser> CoreUsers { get; set; } = new List<CoreUser>();
}
