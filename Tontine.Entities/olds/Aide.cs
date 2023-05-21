using System;
using System.Collections.Generic;

namespace Tontine.Entities.olds;

/// <summary>
/// Aide
/// </summary>
public partial class Aide
{
    /// <summary>
    /// Idevts
    /// </summary>
    public int Idevts { get; set; }

    /// <summary>
    /// Libelle de l&apos;evenement
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Lieu ou se deroule l&apos;evenement
    /// </summary>
    public string? Lieu { get; set; }

    /// <summary>
    /// Montant statutaire prevu annuellement pourl&apos;evenement
    /// </summary>
    public decimal Montanttotalevt { get; set; }

    /// <summary>
    /// Montant dedie au deplacement des membres
    /// </summary>
    public decimal Montantroute { get; set; }

    /// <summary>
    /// Liste des membres designes pour le deplacement
    /// </summary>
    public string? Listemandataires { get; set; }

    public virtual Sortiecaisse IdevtsNavigation { get; set; } = null!;
}
