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
[Index("PersonId", Name = "association_56_fk")]
[Index("SuspensionId", Name = "meet_suspension_membre_pk", IsUnique = true)]
public partial class MeetSuspensionMembre
{
    /// <summary>
    /// Suspension_id
    /// </summary>
    [Key]
    [Column("suspension_id")]
    public int SuspensionId { get; set; }

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
    /// Person_id
    /// </summary>
    [Column("person_id")]
    public int PersonId { get; set; }

    /// <summary>
    /// Date_suspension
    /// </summary>
    [Column("date_suspension")]
    public DateOnly DateSuspension { get; set; }

    /// <summary>
    /// Date_retour
    /// </summary>
    [Column("date_retour")]
    public DateOnly? DateRetour { get; set; }

    /// <summary>
    /// Is_active
    /// </summary>
    [Column("is_active")]
    public bool IsActive { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("MeetSuspensionMembres")]
    public virtual CorePerson Person { get; set; } = null!;
}
