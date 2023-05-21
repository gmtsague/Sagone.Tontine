using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// Meet_Entree_caisse
/// </summary>
public partial class MeetEntreeCaisse
{
    /// <summary>
    /// Operation_id
    /// </summary>
    public int OperationId { get; set; }

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
    /// Identiifant de la signature
    /// </summary>
    public int PresenceId { get; set; }

    /// <summary>
    /// Engagement_id
    /// </summary>
    public int? EngagementId { get; set; }

    /// <summary>
    /// Identifiant du mode de paiement
    /// </summary>
    public int ModepaieId { get; set; }

    /// <summary>
    /// MontantVerse
    /// </summary>
    public decimal Montantverse { get; set; }

    /// <summary>
    /// Indique si le type represente une sortie de caisse
    /// </summary>
    public bool IsOutcome { get; set; }

    public virtual MeetEngagement? Engagement { get; set; }

    public virtual CoreModepaie Modepaie { get; set; } = null!;

    public virtual MeetPresence Presence { get; set; } = null!;
}
