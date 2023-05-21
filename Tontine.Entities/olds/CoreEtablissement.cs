using System;
using System.Collections.Generic;

namespace Tontine.Entities.olds;

/// <summary>
/// core_Etablissement
/// </summary>
public partial class CoreEtablissement
{
    /// <summary>
    /// Idetab
    /// </summary>
    public int Idetab { get; set; }

    /// <summary>
    /// Identifiant du pays
    /// </summary>
    public long? PaysId { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Agrement
    /// </summary>
    public string? Agrement { get; set; }

    /// <summary>
    /// Dossierfiscale
    /// </summary>
    public string? Dossierfiscale { get; set; }

    public virtual ICollection<CoreAnnualetabparam> CoreAnnualetabparams { get; set; } = new List<CoreAnnualetabparam>();

    public virtual ICollection<CoreBankaccount> CoreBankaccounts { get; set; } = new List<CoreBankaccount>();

    public virtual ICollection<CorePhoto> CorePhotos { get; set; } = new List<CorePhoto>();

    public virtual CorePay? Pays { get; set; }
}
