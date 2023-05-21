using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans;

/// <summary>
/// Meet_Max_allow_signature
/// </summary>
public partial class MeetMaxAllowSignature
{
    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; set; }

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
    /// Identifiant de l&apos;annee
    /// </summary>
    public int AnneeId { get; set; }

    /// <summary>
    /// Identifiant du type d&apos;evenement
    /// </summary>
    public int TyperubId { get; set; }

    /// <summary>
    /// La valeur de cet attribut a partir de la somme des lignes faisant reference a un type de rubrique pour une annee donnee
    /// </summary>
    public int MaxSignature { get; set; }

    public virtual CoreAnnee Annee { get; set; } = null!;

    public virtual MeetTypeRubrique Typerub { get; set; } = null!;
}
