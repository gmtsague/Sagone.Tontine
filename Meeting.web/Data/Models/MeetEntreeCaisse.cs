using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MeetingEntities.Models;

/// <summary>
/// Meet_Entree_caisse
/// </summary>
[Table("meet_entree_caisse", Schema = "tontine_v14")]
//[Index("ModepaieId", Name = "association_18_fk")]
[Index("PresenceId", Name = "association_20_fk")]
[Index("EngagementId", Name = "association_52_fk")]
[Index("OperationId", Name = "meet_entree_caisse_pk", IsUnique = true)]
[Index("PresenceId", "EngagementId", Name = "uniq_versement", IsUnique = true)]
public partial class MeetEntreeCaisse
{
    /// <summary>
    /// Operation_id
    /// </summary>
    [Key]
    [Column("operation_id")]
    public int OperationId { get; set; }

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
    /// Identiifant de la signature
    /// </summary>
    [Column("presence_id")]
    public int PresenceId { get; set; }

    /// <summary>
    /// Engagement_id
    /// </summary>
    [Column("engagement_id")]
    public int? EngagementId { get; set; }

    /// <summary>
    /// Identifiant du mode de paiement
    /// </summary>
    [Column("modepaie_id")]
    public int? ModepaieId { get; set; }

    /// <summary>
    /// MontantVerse
    /// </summary>
    [Column("montantverse")]
    public decimal Montantverse { get; set; }

    /// <summary>
    /// Indique si le type represente une sortie de caisse
    /// </summary>
    [Column("is_outcome")]
    public bool IsOutcome { get; set; }

    [ForeignKey("EngagementId")]
    [InverseProperty("MeetEntreeCaisses")]
    public virtual MeetEngagement? Engagement { get; set; }

    //[ForeignKey("ModepaieId")]
    //[InverseProperty("MeetEntreeCaisses")]
    //public virtual CoreModepaie? Modepaie { get; set; }

    [ForeignKey("PresenceId")]
    [InverseProperty("MeetEntreeCaisses")]
    public virtual MeetPresence Presence { get; set; } = null!;
}
