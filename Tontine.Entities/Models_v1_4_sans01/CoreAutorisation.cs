using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// core_Autorisations
/// </summary>
public partial class CoreAutorisation
{
    /// <summary>
    /// Choix_id
    /// </summary>
    public int ChoixId { get; set; }

    /// <summary>
    /// Profil_id
    /// </summary>
    public int ProfilId { get; set; }

    /// <summary>
    /// Idcmde
    /// </summary>
    public int Idcmde { get; set; }

    /// <summary>
    /// Is_active
    /// </summary>
    public bool IsActive { get; set; }

    public virtual CoreCommande IdcmdeNavigation { get; set; } = null!;

    public virtual CoreProfil Profil { get; set; } = null!;
}
