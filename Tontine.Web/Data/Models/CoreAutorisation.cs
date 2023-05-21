using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models;

/// <summary>
/// core_Autorisations
/// </summary>
public partial class CoreAutorisation
{
    /// <summary>
    /// Idchoix
    /// </summary>
    public int Idchoix { get; set; }

    /// <summary>
    /// Idprofil
    /// </summary>
    public int Idprofil { get; set; }

    /// <summary>
    /// Idcmde
    /// </summary>
    public int Idcmde { get; set; }

    /// <summary>
    /// Isactive
    /// </summary>
    public bool Isactive { get; set; }

    public virtual CoreCommande IdcmdeNavigation { get; set; } = null!;

    public virtual CoreProfil IdprofilNavigation { get; set; } = null!;
}
