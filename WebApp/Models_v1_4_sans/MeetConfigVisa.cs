using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans;

/// <summary>
/// Represente l&apos;ensemble des autorisatios de signature de documents au sein de l&apos;association
/// </summary>
public partial class MeetConfigVisa
{
    /// <summary>
    /// Identifiant de la configuration de signature
    /// </summary>
    public int ConfigvisaId { get; set; }

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
    /// Poste_id
    /// </summary>
    public int PosteId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int AnneeId { get; set; }

    /// <summary>
    /// Identifiant du type d&apos;evenement
    /// </summary>
    public int TyperubId { get; set; }

    /// <summary>
    /// Numero d&apos;ordre de la signature pour un type de document
    /// </summary>
    public int Numordre { get; set; }

    /// <summary>
    /// Sign_by_ordre
    /// </summary>
    public bool SignByOrdre { get; set; }

    public virtual CoreAnnee Annee { get; set; } = null!;

    public virtual ICollection<MeetVisa> MeetVisas { get; set; } = new List<MeetVisa>();

    public virtual MeetPoste Poste { get; set; } = null!;

    public virtual MeetTypeRubrique Typerub { get; set; } = null!;
}
