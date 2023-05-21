using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models;

/// <summary>
/// Pret
/// </summary>
public partial class Pret
{
    /// <summary>
    /// Idevts
    /// </summary>
    public int Idevts { get; set; }

    /// <summary>
    /// Indique si l&apos;evenement est un pret
    /// </summary>
    public bool Ispret { get; set; }

    /// <summary>
    /// Duree du pret en nombre de mois
    /// </summary>
    public int Dureepret { get; set; }

    /// <summary>
    /// Montant de l&apos;interet
    /// </summary>
    public decimal Montantinteret { get; set; }

    /// <summary>
    /// Montant applicable en cas de penalite sur les interets ou en cas d&apos;absence de cotisation
    /// </summary>
    public decimal Montantpenalite { get; set; }

    public virtual Sortiecaisse IdevtsNavigation { get; set; } = null!;
}
