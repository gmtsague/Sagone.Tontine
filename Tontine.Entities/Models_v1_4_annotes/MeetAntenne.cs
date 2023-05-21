using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Represente ue antenne de l&apos;association
/// </summary>
[PrimaryKey("EtabId", "AntenneId")]
[Table("meet_antenne", Schema = "tontine_v14")]
[Index("EtabId", Name = "association_49_fk")]
[Index("EtabId", "AntenneId", Name = "meet_antenne_pk", IsUnique = true)]
public partial class MeetAntenne
{
    /// <summary>
    /// Etab_id
    /// </summary>
    [Key]
    [Column("etab_id")]
    public int EtabId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;antenne
    /// </summary>
    [Key]
    [Column("antenne_id")]
    public int AntenneId { get; set; }

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
    /// Libelle de l&apos;antenne
    /// </summary>
    [Column("libelle")]
    [StringLength(128)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Date de creation de l&apos;antenne
    /// </summary>
    [Column("creationdate")]
    public DateOnly? Creationdate { get; set; }

    [ForeignKey("EtabId")]
    [InverseProperty("MeetAntennes")]
    public virtual CoreEtablissement Etab { get; set; } = null!;

    [InverseProperty("MeetAntenne")]
    public virtual ICollection<MeetInscription> MeetInscriptions { get; set; } = new List<MeetInscription>();

    [InverseProperty("MeetAntenne")]
    public virtual ICollection<MeetSeance> MeetSeances { get; set; } = new List<MeetSeance>();
}
