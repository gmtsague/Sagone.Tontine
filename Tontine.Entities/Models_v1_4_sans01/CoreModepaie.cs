using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// Mode de paiement utilise par un membre
/// </summary>
public partial class CoreModepaie
{
    /// <summary>
    /// Identifiant du mode de paiement
    /// </summary>
    public int ModepaieId { get; set; }

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
    /// Libelle du mode de paiement
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Indique si le mode represnte le CASH
    /// </summary>
    public bool IsCash { get; set; }

    public virtual ICollection<MeetEntreeCaisse> MeetEntreeCaisses { get; set; } = new List<MeetEntreeCaisse>();
}
