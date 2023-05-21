using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans;

/// <summary>
/// Represente l&apos;etat des presences des membres a une seance de reunion et l&apos;ensemble des signatures apposees par les membres (beneficiaire et bureau) de l&apos;association sur un document
/// </summary>
public partial class MeetPresence
{
    /// <summary>
    /// Identiifant de la signature
    /// </summary>
    public int PresenceId { get; set; }

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
    /// Seance_id
    /// </summary>
    public int SeanceId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    public int Idinscrit { get; set; }

    /// <summary>
    /// Dateop
    /// </summary>
    public DateOnly Dateop { get; set; }

    /// <summary>
    /// Is_absent
    /// </summary>
    public bool IsAbsent { get; set; }

    /// <summary>
    /// globalverse
    /// </summary>
    public decimal Globalverse { get; set; }

    /// <summary>
    /// Num_bordero
    /// </summary>
    public string? NumBordero { get; set; }

    public virtual MeetInscription IdinscritNavigation { get; set; } = null!;

    public virtual ICollection<MeetEntreeCaisse> MeetEntreeCaisses { get; set; } = new List<MeetEntreeCaisse>();

    public virtual MeetSeance Seance { get; set; } = null!;
}
