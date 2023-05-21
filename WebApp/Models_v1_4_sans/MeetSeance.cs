using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans;

/// <summary>
/// Meet_seance
/// </summary>
public partial class MeetSeance
{
    /// <summary>
    /// Seance_id
    /// </summary>
    public int SeanceId { get; set; }

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
    /// Etab_id
    /// </summary>
    public int? EtabId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;antenne
    /// </summary>
    public int? AntenneId { get; set; }

    /// <summary>
    /// Date et heure d&apos;ouverture de la reunion
    /// </summary>
    public DateTime? Opendate { get; set; }

    /// <summary>
    /// Date et heure de fermeture de la reunion
    /// </summary>
    public DateTime? Closedate { get; set; }

    /// <summary>
    /// Total_entrees
    /// </summary>
    public decimal TotalEntrees { get; set; }

    /// <summary>
    /// Total_Sorties
    /// </summary>
    public decimal TotalSorties { get; set; }

    /// <summary>
    /// DepenseCollation
    /// </summary>
    public decimal Depensecollation { get; set; }

    /// <summary>
    /// Compte rendu de la seance de reunion
    /// </summary>
    public string? Compterendu { get; set; }

    /// <summary>
    /// Le statut {CLOSED} indique que la reunion est cloturee et ses donnees ne sont plus modifiables
    /// </summary>
    public int? Status { get; set; }

    public virtual CoreSubdivision CoreSubdivision { get; set; } = null!;

    public virtual MeetAntenne? MeetAntenne { get; set; }

    public virtual ICollection<MeetPresence> MeetPresences { get; set; } = new List<MeetPresence>();

    public virtual ICollection<MeetPret> MeetPrets { get; set; } = new List<MeetPret>();

    public virtual ICollection<MeetSortieCaisse> MeetSortieCaisses { get; set; } = new List<MeetSortieCaisse>();
}
