using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// Meet_Engagement
/// </summary>
public partial class MeetEngagement
{
    /// <summary>
    /// Engagement_id
    /// </summary>
    public int EngagementId { get; set; }

    /// <summary>
    /// create_uid
    /// </summary>
    public long? CreateUid { get; set; }

    /// <summary>
    /// update_uid
    /// </summary>
    public long? UpdateUid { get; set; }

    /// <summary>
    /// Create_at
    /// </summary>
    public DateTime CreateAt { get; set; }

    /// <summary>
    /// Update_at
    /// </summary>
    public DateTime UpdateAt { get; set; }

    /// <summary>
    /// Identifiant d&apos;une configuration
    /// </summary>
    public int RubriqueId { get; set; }

    /// <summary>
    /// Person_id
    /// </summary>
    public int PersonId { get; set; }

    /// <summary>
    /// Cumul des versements sur une rubrique
    /// </summary>
    public decimal Cumulverse { get; set; }

    /// <summary>
    /// Solde
    /// </summary>
    public decimal Solde { get; set; }

    /// <summary>
    /// Indique si le type represente une sortie de caisse
    /// </summary>
    public bool IsOutcome { get; set; }

    /// <summary>
    /// Indique que l&apos;evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)
    /// </summary>
    public bool IsClosed { get; set; }

    /// <summary>
    /// Engagement_Date
    /// </summary>
    public DateOnly? EngagementDate { get; set; }

    public virtual ICollection<MeetEntreeCaisse> MeetEntreeCaisses { get; set; } = new List<MeetEntreeCaisse>();

    public virtual ICollection<MeetSortieCaisse> MeetSortieCaisses { get; set; } = new List<MeetSortieCaisse>();

    public virtual CorePerson Person { get; set; } = null!;

    public virtual MeetRubrique Rubrique { get; set; } = null!;
}
