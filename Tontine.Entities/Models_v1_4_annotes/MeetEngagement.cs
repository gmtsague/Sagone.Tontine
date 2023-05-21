using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Meet_Engagement
/// </summary>
[Table("meet_engagement", Schema = "tontine_v14")]
[Index("RubriqueId", Name = "association_2_fk")]
[Index("PersonId", Name = "association_59_fk")]
[Index("EngagementId", Name = "meet_engagement_pk", IsUnique = true)]
public partial class MeetEngagement
{
    /// <summary>
    /// Engagement_id
    /// </summary>
    [Key]
    [Column("engagement_id")]
    public int EngagementId { get; set; }

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
    /// Identifiant d&apos;une configuration
    /// </summary>
    [Column("rubrique_id")]
    public int RubriqueId { get; set; }

    /// <summary>
    /// Person_id
    /// </summary>
    [Column("person_id")]
    public int PersonId { get; set; }

    /// <summary>
    /// Cumul des versements sur une rubrique
    /// </summary>
    [Column("cumulverse")]
    public decimal Cumulverse { get; set; }

    /// <summary>
    /// Solde
    /// </summary>
    [Column("solde")]
    public decimal Solde { get; set; }

    /// <summary>
    /// Indique si le type represente une sortie de caisse
    /// </summary>
    [Column("is_outcome")]
    public bool IsOutcome { get; set; }

    /// <summary>
    /// Indique que l&apos;evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)
    /// </summary>
    [Column("is_closed")]
    public bool IsClosed { get; set; }

    /// <summary>
    /// Engagement_Date
    /// </summary>
    [Column("engagement_date")]
    public DateOnly? EngagementDate { get; set; }

    [InverseProperty("Engagement")]
    public virtual ICollection<MeetEntreeCaisse> MeetEntreeCaisses { get; set; } = new List<MeetEntreeCaisse>();

    [InverseProperty("Engagement")]
    public virtual ICollection<MeetSortieCaisse> MeetSortieCaisses { get; set; } = new List<MeetSortieCaisse>();

    [ForeignKey("PersonId")]
    [InverseProperty("MeetEngagements")]
    public virtual CorePerson Person { get; set; } = null!;

    [ForeignKey("RubriqueId")]
    [InverseProperty("MeetEngagements")]
    public virtual MeetRubrique Rubrique { get; set; } = null!;
}
