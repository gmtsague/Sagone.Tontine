using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MeetingEntities.Models;

/// <summary>
/// Represente l&apos;etat des presences des membres a une seance de reunion et l&apos;ensemble des signatures apposees par les membres (beneficiaire et bureau) de l&apos;association sur un document
/// </summary>
[Table("meet_presence", Schema = "tontine_v14")]
[Index("Idinscrit", Name = "association_13_fk")]
[Index("SeanceId", Name = "association_14_fk")]
[Index("PresenceId", Name = "meet_presence_pk", IsUnique = true)]
[Index("NumBordero", Name = "uniq_no_bordero", IsUnique = true)]
[Index("SeanceId", "Idinscrit", Name = "uniq_presence", IsUnique = true)]
public partial class MeetPresence
{
    /// <summary>
    /// Identiifant de la signature
    /// </summary>
    [Key]
    [Column("presence_id")]
    public int PresenceId { get; set; }

    /// <summary>
    /// create_uid
    /// </summary>
    [Column("create_uid")]
    public long? CreateUid { get; set; }

    /// <summary>
    /// update_uid
    /// </summary>
    [Column("update_uid")]
    public long? UpdateUid { get; set; }

    /// <summary>
    /// Create_at
    /// </summary>
    [Column("create_at", TypeName = "timestamp without time zone")]
    public DateTime CreateAt { get; set; }

    /// <summary>
    /// Update_at
    /// </summary>
    [Column("update_at", TypeName = "timestamp without time zone")]
    public DateTime UpdateAt { get; set; }

    /// <summary>
    /// Seance_id
    /// </summary>
    [Column("seance_id")]
    public int SeanceId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    [Column("idinscrit")]
    public int Idinscrit { get; set; }

    /// <summary>
    /// Dateop
    /// </summary>
    [Column("dateop")]
    public DateOnly Dateop { get; set; }

    /// <summary>
    /// Is_absent
    /// </summary>
    [Column("is_absent")]
    public bool IsAbsent { get; set; }

    /// <summary>
    /// globalverse
    /// </summary>
    [Column("globalverse")]
    public decimal Globalverse { get; set; }

    /// <summary>
    /// VerseCash
    /// </summary>
    [Column("verse_cash")]
    public decimal VerseCash { get; set; }

    /// <summary>
    /// VerseTransfert
    /// </summary>
    [Column("verse_transfert")]
    public decimal VerseTransfert { get; set; }    
    
    /// <summary>
    /// Num_bordero
    /// </summary>
    [Column("num_bordero")]
    [StringLength(128)]
    public string? NumBordero { get; set; }

    [ForeignKey("Idinscrit")]
    [InverseProperty("MeetPresences")]
    public virtual MeetInscription IdinscritNavigation { get; set; } = null!;

    [InverseProperty("Presence")]
    public virtual ICollection<MeetEntreeCaisse> MeetEntreeCaisses { get; set; } = new List<MeetEntreeCaisse>();

    [ForeignKey("SeanceId")]
    [InverseProperty("MeetPresences")]
    public virtual MeetSeance Seance { get; set; } = null!;
}
