using System;
using System.Collections.Generic;

namespace Tontine.Entities.olds;

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
