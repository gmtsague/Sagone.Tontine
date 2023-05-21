using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans;

/// <summary>
/// Meet_Sortie_Caisse
/// </summary>
public partial class MeetSortieCaisse
{
    /// <summary>
    /// Sortiecaisse_id
    /// </summary>
    public int SortiecaisseId { get; set; }

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
    public int? Idinscrit { get; set; }

    /// <summary>
    /// Seance_id
    /// </summary>
    public int SeanceId { get; set; }

    /// <summary>
    /// Engagement_id
    /// </summary>
    public int EngagementId { get; set; }

    /// <summary>
    /// Montant dedie au deplacement des membres
    /// </summary>
    public decimal MontantRoute { get; set; }

    /// <summary>
    /// Liste des membres designes pour le deplacement
    /// </summary>
    public string? ListeMandataires { get; set; }

    /// <summary>
    /// Date effective a laquelle a lieu l&apos;evenement
    /// </summary>
    public DateOnly Dateevts { get; set; }

    /// <summary>
    /// Montant percu par le beneficiaire de l&apos;evenement
    /// </summary>
    public decimal Montantpercu { get; set; }

    /// <summary>
    /// Observation generale concernant le deroulement de l&apos;evenement
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Indique que l&apos;evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)
    /// </summary>
    public bool IsClosed { get; set; }

    /// <summary>
    /// Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.
    /// </summary>
    public int Visarestants { get; set; }

    public virtual MeetEngagement Engagement { get; set; } = null!;

    public virtual MeetInscription? IdinscritNavigation { get; set; }

    public virtual ICollection<MeetVisa> MeetVisas { get; set; } = new List<MeetVisa>();

    public virtual MeetSeance Seance { get; set; } = null!;
}
