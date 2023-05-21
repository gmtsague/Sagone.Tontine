using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// core_Frequence_Division
/// </summary>
[Table("core_frequence_division", Schema = "tontine_v14")]
[Index("nb_days", Name = "ak_alt_key_frequence_core_fre", IsUnique = true)]
[Index("frequence_id", Name = "core_frequence_division_pk", IsUnique = true)]
public partial class core_frequence_division
{
    /// <summary>
    /// Frequence_id
    /// </summary>
    [Key]
    public int frequence_id { get; set; }

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
    /// Libelle
    /// </summary>
    [StringLength(128)]
    public string libelle { get; set; } = null!;

    /// <summary>
    /// Nb_Days
    /// </summary>
    public int nb_days { get; set; }

    [InverseProperty("frequence")]
    public virtual ICollection<core_annee> core_annees { get; set; } = new List<core_annee>();
}
