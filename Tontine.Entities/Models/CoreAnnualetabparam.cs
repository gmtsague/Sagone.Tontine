using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// core_AnnualEtabParams
/// </summary>
[Table("core_annualetabparams", Schema = "tontine")]
[Index("Idetab", Name = "association_40_fk")]
[Index("Idannee", Name = "association_41_fk")]
[Index("SchoolparamsId", Name = "core_annualetabparams_pk", IsUnique = true)]
public partial class CoreAnnualetabparam
{
    /// <summary>
    /// Identifiant de l&apos;entite
    /// </summary>
    [Key]
    [Column("schoolparams_id")]
    public long SchoolparamsId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Column("idannee")]
    public int Idannee { get; set; }

    /// <summary>
    /// Idetab
    /// </summary>
    [Column("idetab")]
    public int Idetab { get; set; }

    /// <summary>
    /// Nombre max de liens autorises pour la photo d&apos;une personne
    /// </summary>
    [Column("maxphotoallow_liens")]
    public int MaxphotoallowLiens { get; set; }

    [ForeignKey("Idannee")]
    [InverseProperty("CoreAnnualetabparams")]
    public virtual CoreAnnee IdanneeNavigation { get; set; } = null!;

    [ForeignKey("Idetab")]
    [InverseProperty("CoreAnnualetabparams")]
    public virtual CoreEtablissement IdetabNavigation { get; set; } = null!;
}
