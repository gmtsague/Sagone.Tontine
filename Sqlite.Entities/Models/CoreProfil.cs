using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class CoreProfil
{
    public long ProfilId { get; set; }

    public byte[] Libelle { get; set; } = null!;

    public byte[] Candelete { get; set; } = null!;

    public virtual ICollection<CoreAutorisation> CoreAutorisations { get; set; } = new List<CoreAutorisation>();

    public virtual ICollection<CoreUser> CoreUsers { get; set; } = new List<CoreUser>();
}
