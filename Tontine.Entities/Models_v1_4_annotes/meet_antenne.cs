using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Represente ue antenne de l&apos;association
/// </summary>
[PrimaryKey("etab_id", "antenne_id")]
[Table("meet_antenne", Schema = "tontine_v14")]
[Index("etab_id", Name = "association_49_fk")]
[Index("etab_id", "antenne_id", Name = "meet_antenne_pk", IsUnique = true)]
public partial class meet_antenne
{
    /// <summary>
    /// Etab_id
    /// </summary>
    [Key]
    public int etab_id { get; set; }

    /// <summary>
    /// Identifiant de l&apos;antenne
    /// </summary>
    [Key]
    public int antenne_id { get; set; }

    /// <summary>
    /// create_uid
    /// </summary>
    public long? create_uid { get; set; }

    /// <summary>
    /// update_uid
    /// </summary>
    public long? update_uid { get; set; }

    /// <summary>
    /// Create_at
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime create_at { get; set; }

    /// <summary>
    /// Update_at
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime update_at { get; set; }

    /// <summary>
    /// Libelle de l&apos;antenne
    /// </summary>
    [StringLength(128)]
    public string libelle { get; set; } = null!;

    /// <summary>
    /// Date de creation de l&apos;antenne
    /// </summary>
    public DateOnly? creationdate { get; set; }

    [ForeignKey("etab_id")]
    [InverseProperty("meet_antennes")]
    public virtual core_etablissement etab { get; set; } = null!;

    [InverseProperty("meet_antenne")]
    public virtual ICollection<meet_inscription> meet_inscriptions { get; set; } = new List<meet_inscription>();

    [InverseProperty("meet_antenne")]
    public virtual ICollection<meet_seance> meet_seances { get; set; } = new List<meet_seance>();
}
