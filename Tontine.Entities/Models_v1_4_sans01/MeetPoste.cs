using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// Poste occupe par un membre de l&apos;association
/// </summary>
public partial class MeetPoste
{
    /// <summary>
    /// Poste_id
    /// </summary>
    public int PosteId { get; set; }

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
    /// Libelle
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Les valeurs autorisees sont: {PRESIDENT, TRESORIER, SG, SGA, CC, CENSOR, MEMBER}
    /// </summary>
    public string Code { get; set; } = null!;

    public virtual ICollection<MeetConfigVisa> MeetConfigVisas { get; set; } = new List<MeetConfigVisa>();

    public virtual ICollection<MeetMembreBureau> MeetMembreBureaus { get; set; } = new List<MeetMembreBureau>();
}
