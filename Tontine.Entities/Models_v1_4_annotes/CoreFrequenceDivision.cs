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
[Index("NbDays", Name = "ak_alt_key_frequence_core_fre", IsUnique = true)]
[Index("FrequenceId", Name = "core_frequence_division_pk", IsUnique = true)]
public partial class CoreFrequenceDivision
{
    /// <summary>
    /// Frequence_id
    /// </summary>
    [Key]
    [Column("frequence_id")]
    public int FrequenceId { get; set; }

    /// <summary>
    /// create_uid
    /// </summary>
    [Column("create_uid")]
    public long? CreateUid { get; set; }

    /// <summary>
    /// update_uid
    /// </summary>
    [Column("update_uid")]
    public long? UpdateUid { get; set; }

    /// <summary>
    /// Create_at
    /// </summary>
    [Column("create_at", TypeName = "timestamp without time zone")]
    public DateTime CreateAt { get; set; }

    /// <summary>
    /// Update_at
    /// </summary>
    [Column("update_at", TypeName = "timestamp without time zone")]
    public DateTime UpdateAt { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    [Column("libelle")]
    [StringLength(128)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Nb_Days
    /// </summary>
    [Column("nb_days")]
    public int NbDays { get; set; }

    [InverseProperty("Frequence")]
    public virtual ICollection<CoreAnnee> CoreAnnees { get; set; } = new List<CoreAnnee>();
}
