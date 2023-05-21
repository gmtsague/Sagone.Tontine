using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Represente le decoupage mensuel de l&apos;annee
/// </summary>
[PrimaryKey("annee_id", "division_id")]
[Table("core_subdivision", Schema = "tontine_v14")]
[Index("month_date", Name = "ak_uniq_subdivision_core_sub", IsUnique = true)]
[Index("annee_id", Name = "association_1_fk")]
[Index("annee_id", "division_id", Name = "core_subdivision_pk", IsUnique = true)]
public partial class core_subdivision
{
    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Key]
    public int annee_id { get; set; }

    /// <summary>
    /// Identifiant de la division
    /// </summary>
    [Key]
    public int division_id { get; set; }

    /// <summary>
    /// create_uid
    /// </summary>
    public long? create_uid { get; set; }

    /// <summary>
    /// update_uid
    /// </summary>
    public long? update_uid { get; set; }

    /// <summary>
    /// Create_at
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime create_at { get; set; }

    /// <summary>
    /// Update_at
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime update_at { get; set; }

    /// <summary>
    /// Libelle de la division
    /// </summary>
    [StringLength(128)]
    public string libelle { get; set; } = null!;

    /// <summary>
    /// Date de debut de la division
    /// </summary>
    public DateOnly month_date { get; set; }

    /// <summary>
    /// Jour du mois ou aura lieu la reunion
    /// </summary>
    public int? month_day { get; set; }

    /// <summary>
    /// Numero d&apos;ordre de la division
    /// </summary>
    public int numordre { get; set; }

    [ForeignKey("annee_id")]
    [InverseProperty("core_subdivisions")]
    public virtual core_annee annee { get; set; } = null!;

    [InverseProperty("core_subdivision")]
    public virtual ICollection<meet_ordre_passage> meet_ordre_passages { get; set; } = new List<meet_ordre_passage>();

    [InverseProperty("core_subdivision")]
    public virtual ICollection<meet_seance> meet_seances { get; set; } = new List<meet_seance>();
}
