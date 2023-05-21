using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// core_Commandes
/// </summary>
public partial class CoreCommande
{
    /// <summary>
    /// Idcmde
    /// </summary>
    public int Idcmde { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    public string Libelle { get; set; } = null!;

    public virtual ICollection<CoreAutorisation> CoreAutorisations { get; set; } = new List<CoreAutorisation>();
}
