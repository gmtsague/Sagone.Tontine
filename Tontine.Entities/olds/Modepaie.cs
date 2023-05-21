using System;
using System.Collections.Generic;

namespace Tontine.Entities.olds;

/// <summary>
/// Mode de paiement utilise par un membre
/// </summary>
public partial class Modepaie
{
    /// <summary>
    /// Identifiant du mode de paiement
    /// </summary>
    public int Idmode { get; set; }

    /// <summary>
    /// Libelle du mode de paiement
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Indique si le mode represnte le CASH
    /// </summary>
    public bool Iscash { get; set; }

    public virtual ICollection<Presence> Presences { get; set; } = new List<Presence>();
}
