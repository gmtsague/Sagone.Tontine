using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans;

/// <summary>
/// Meet_Suspension_Membre
/// </summary>
public partial class MeetSuspensionMembre
{
    /// <summary>
    /// Suspension_id
    /// </summary>
    public int SuspensionId { get; set; }

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
    /// Person_id
    /// </summary>
    public int PersonId { get; set; }

    /// <summary>
    /// Date_suspension
    /// </summary>
    public DateOnly DateSuspension { get; set; }

    /// <summary>
    /// Date_retour
    /// </summary>
    public DateOnly? DateRetour { get; set; }

    /// <summary>
    /// Is_active
    /// </summary>
    public bool IsActive { get; set; }

    public virtual CorePerson Person { get; set; } = null!;
}
