using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans;

/// <summary>
/// Meet_Ordre_Passage
/// </summary>
public partial class MeetOrdrePassage
{
    /// <summary>
    /// passage_id
    /// </summary>
    public int PassageId { get; set; }

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
    /// Identifiant de la division
    /// </summary>
    public int DivisionId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    public int Idinscrit { get; set; }

    /// <summary>
    /// MontantPercu
    /// </summary>
    public decimal Montantpercu { get; set; }

    /// <summary>
    /// HeureDebut
    /// </summary>
    public DateOnly? Heuredebut { get; set; }

    /// <summary>
    /// Commentaire
    /// </summary>
    public string? Commentaire { get; set; }

    public virtual CoreSubdivision CoreSubdivision { get; set; } = null!;

    public virtual MeetInscription IdinscritNavigation { get; set; } = null!;
}
