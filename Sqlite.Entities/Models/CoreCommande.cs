using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class CoreCommande
{
    public long Idcmde { get; set; }

    public byte[] Libelle { get; set; } = null!;

    public virtual ICollection<CoreAutorisation> CoreAutorisations { get; set; } = new List<CoreAutorisation>();
}
