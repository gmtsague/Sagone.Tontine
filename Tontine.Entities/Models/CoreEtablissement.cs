using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// core_Etablissement
/// </summary>
[Table("core_etablissement", Schema = "tontine")]
[Index("PaysId", Name = "association_42_fk")]
[Index("Idetab", Name = "core_etablissement_pk", IsUnique = true)]
public partial class CoreEtablissement
{
    /// <summary>
    /// Idetab
    /// </summary>
    [Key]
    [Column("idetab")]
    public int Idetab { get; set; }

    /// <summary>
    /// Identifiant du pays
    /// </summary>
    [Column("pays_id")]
    public long? PaysId { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    [Column("libelle")]
    [StringLength(254)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Agrement
    /// </summary>
    [Column("agrement")]
    [StringLength(254)]
    public string? Agrement { get; set; }

    /// <summary>
    /// Dossierfiscale
    /// </summary>
    [Column("dossierfiscale")]
    [StringLength(254)]
    public string? Dossierfiscale { get; set; }

    [InverseProperty("IdetabNavigation")]
    public virtual ICollection<CoreAnnualetabparam> CoreAnnualetabparams { get; set; } = new List<CoreAnnualetabparam>();

    [InverseProperty("IdetabNavigation")]
    public virtual ICollection<CoreBankaccount> CoreBankaccounts { get; set; } = new List<CoreBankaccount>();

    [InverseProperty("IdetabNavigation")]
    public virtual ICollection<CorePhoto> CorePhotos { get; set; } = new List<CorePhoto>();

    [ForeignKey("PaysId")]
    [InverseProperty("CoreEtablissements")]
    public virtual CorePay? Pays { get; set; }
}
