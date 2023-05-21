using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Meet_Suspension_Membre
/// </summary>
[Table("meet_suspension_membre", Schema = "tontine_v14")]
[Index("person_id", Name = "association_56_fk")]
[Index("suspension_id", Name = "meet_suspension_membre_pk", IsUnique = true)]
public partial class meet_suspension_membre
{
    /// <summary>
    /// Suspension_id
    /// </summary>
    [Key]
    public int suspension_id { get; set; }

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
    /// Person_id
    /// </summary>
    public int person_id { get; set; }

    /// <summary>
    /// Date_suspension
    /// </summary>
    public DateOnly date_suspension { get; set; }

    /// <summary>
    /// Date_retour
    /// </summary>
    public DateOnly? date_retour { get; set; }

    /// <summary>
    /// Is_active
    /// </summary>
    public bool is_active { get; set; }

    [ForeignKey("person_id")]
    [InverseProperty("meet_suspension_membres")]
    public virtual core_person person { get; set; } = null!;
}
