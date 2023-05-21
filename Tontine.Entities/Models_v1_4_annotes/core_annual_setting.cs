using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// core_Annual_setting
/// </summary>
[Table("core_annual_setting", Schema = "tontine_v14")]
[Index("etab_id", Name = "association_40_fk")]
[Index("annee_id", Name = "association_41_fk")]
[Index("setting_id", Name = "core_annual_setting_pk", IsUnique = true)]
public partial class core_annual_setting
{
    /// <summary>
    /// Identifiant de l&apos;entite
    /// </summary>
    [Key]
    public int setting_id { get; set; }

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
    /// Identifiant de l&apos;annee
    /// </summary>
    public int annee_id { get; set; }

    /// <summary>
    /// Etab_id
    /// </summary>
    public int etab_id { get; set; }

    /// <summary>
    /// Nombre max de liens autorises pour la photo d&apos;une personne
    /// </summary>
    public int max_allow_photo_liens { get; set; }

    /// <summary>
    /// CopyEngagements
    /// </summary>
    public bool copyengagements { get; set; }

    /// <summary>
    /// CopyMembers
    /// </summary>
    public bool copymembers { get; set; }

    [ForeignKey("annee_id")]
    [InverseProperty("core_annual_settings")]
    public virtual core_annee annee { get; set; } = null!;

    [ForeignKey("etab_id")]
    [InverseProperty("core_annual_settings")]
    public virtual core_etablissement etab { get; set; } = null!;

    [InverseProperty("setting")]
    public virtual meet_preference? meet_preference { get; set; }
}
