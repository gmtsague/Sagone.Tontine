using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class CoreAutorisation
{
    public long ChoixId { get; set; }

    public long ProfilId { get; set; }

    public long Idcmde { get; set; }

    public byte[] IsActive { get; set; } = null!;

    public virtual CoreCommande IdcmdeNavigation { get; set; } = null!;

    public virtual CoreProfil Profil { get; set; } = null!;
}
