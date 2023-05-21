using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// Represente la personnalisation de certaines valeurs appliquees aux types d&apos;eveneents au cours d&apos;une annee
/// </summary>
public partial class MeetRubrique
{
    /// <summary>
    /// Identifiant d&apos;une configuration
    /// </summary>
    public int RubriqueId { get; set; }

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
    /// Description de la rubrique (evenement)
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Nombre de membres representant l&apos;asociation a l&apos;evenement
    /// </summary>
    public int Nbmandataire { get; set; }

    /// <summary>
    /// Montant du deplacement d&apos;un membre mandate par l&apos;association
    /// </summary>
    public decimal Montantroute { get; set; }

    /// <summary>
    /// Montant total associe a l&apos;evenement
    /// </summary>
    public decimal MontantPerson { get; set; }

    /// <summary>
    /// Indique si le type represente une sortie de caisse
    /// </summary>
    public bool IsOutcome { get; set; }

    /// <summary>
    /// Commentaire
    /// </summary>
    public string? Commentaire { get; set; }

    public virtual CoreAnnee Annee { get; set; } = null!;

    public virtual ICollection<MeetEngagement> MeetEngagements { get; set; } = new List<MeetEngagement>();

    public virtual MeetTypeRubrique Typerub { get; set; } = null!;
}
