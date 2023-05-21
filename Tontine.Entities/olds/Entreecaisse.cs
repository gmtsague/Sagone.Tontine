using System;
using System.Collections.Generic;

namespace Tontine.Entities.olds;

/// <summary>
/// Entreecaisse
/// </summary>
public partial class Entreecaisse
{
    /// <summary>
    /// Idoperation
    /// </summary>
    public int Idoperation { get; set; }

    /// <summary>
    /// Idevts
    /// </summary>
    public int? Idevts { get; set; }

    /// <summary>
    /// Identiifant de la signature
    /// </summary>
    public int Idpresence { get; set; }

    /// <summary>
    /// Identifiant d&apos;une configuration
    /// </summary>
    public int? Idconfig { get; set; }

    /// <summary>
    /// MontantVerse
    /// </summary>
    public decimal Montantverse { get; set; }

    /// <summary>
    /// CumulVerse
    /// </summary>
    public decimal? Cumulverse { get; set; }

    /// <summary>
    /// Reste
    /// </summary>
    public decimal? Reste { get; set; }

    public virtual Annualengagement? IdconfigNavigation { get; set; }

    public virtual Sortiecaisse? IdevtsNavigation { get; set; }

    public virtual Presence IdpresenceNavigation { get; set; } = null!;
}
