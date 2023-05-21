using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// Represente ue antenne de l&apos;association
/// </summary>
public partial class MeetAntenne
{
    /// <summary>
    /// Etab_id
    /// </summary>
    public int EtabId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;antenne
    /// </summary>
    public int AntenneId { get; set; }

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
    /// Libelle de l&apos;antenne
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Date de creation de l&apos;antenne
    /// </summary>
    public DateOnly? Creationdate { get; set; }

    public virtual CoreEtablissement Etab { get; set; } = null!;

    public virtual ICollection<MeetInscription> MeetInscriptions { get; set; } = new List<MeetInscription>();

    public virtual ICollection<MeetSeance> MeetSeances { get; set; } = new List<MeetSeance>();
}
