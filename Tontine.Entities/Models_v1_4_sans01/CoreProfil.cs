using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// core_Profil
/// </summary>
public partial class CoreProfil
{
    /// <summary>
    /// Profil_id
    /// </summary>
    public int ProfilId { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Candelete
    /// </summary>
    public bool Candelete { get; set; }

    public virtual ICollection<CoreAutorisation> CoreAutorisations { get; set; } = new List<CoreAutorisation>();

    public virtual ICollection<CoreUser> CoreUsers { get; set; } = new List<CoreUser>();
}
