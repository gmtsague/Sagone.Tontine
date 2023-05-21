using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans;

/// <summary>
/// Meet_Membre_Bureau
/// </summary>
public partial class MeetMembreBureau
{
    /// <summary>
    /// bureaudetails_id
    /// </summary>
    public int BureaudetailsId { get; set; }

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
    /// Identifiant de l&apos;inscription
    /// </summary>
    public int Idinscrit { get; set; }

    /// <summary>
    /// Poste_id
    /// </summary>
    public int PosteId { get; set; }

    /// <summary>
    /// Bureau_id
    /// </summary>
    public int BureauId { get; set; }

    public virtual MeetBureau Bureau { get; set; } = null!;

    public virtual MeetInscription IdinscritNavigation { get; set; } = null!;

    public virtual MeetPoste Poste { get; set; } = null!;
}
