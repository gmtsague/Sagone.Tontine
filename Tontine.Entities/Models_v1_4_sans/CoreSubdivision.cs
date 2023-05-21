using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans;

/// <summary>
/// Represente le decoupage mensuel de l&apos;annee
/// </summary>
public partial class CoreSubdivision
{
    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int AnneeId { get; set; }

    /// <summary>
    /// Identifiant de la division
    /// </summary>
    public int DivisionId { get; set; }

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
    /// Libelle de la division
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Date de debut de la division
    /// </summary>
    public DateOnly MonthDate { get; set; }

    /// <summary>
    /// Jour du mois ou aura lieu la reunion
    /// </summary>
    public int? MonthDay { get; set; }

    /// <summary>
    /// Numero d&apos;ordre de la division
    /// </summary>
    public int Numordre { get; set; }

    public virtual CoreAnnee Annee { get; set; } = null!;

    public virtual ICollection<MeetOrdrePassage> MeetOrdrePassages { get; set; } = new List<MeetOrdrePassage>();

    public virtual ICollection<MeetSeance> MeetSeances { get; set; } = new List<MeetSeance>();
}
