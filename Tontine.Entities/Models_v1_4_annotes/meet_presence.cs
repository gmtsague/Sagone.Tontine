using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Represente l&apos;etat des presences des membres a une seance de reunion et l&apos;ensemble des signatures apposees par les membres (beneficiaire et bureau) de l&apos;association sur un document
/// </summary>
[Table("meet_presence", Schema = "tontine_v14")]
[Index("idinscrit", Name = "association_13_fk")]
[Index("seance_id", Name = "association_14_fk")]
[Index("presence_id", Name = "meet_presence_pk", IsUnique = true)]
[Index("num_bordero", Name = "uniq_no_bordero", IsUnique = true)]
[Index("seance_id", "idinscrit", Name = "uniq_presence", IsUnique = true)]
public partial class meet_presence
{
    /// <summary>
    /// Identiifant de la signature
    /// </summary>
    [Key]
    public int presence_id { get; set; }

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
    /// Seance_id
    /// </summary>
    public int seance_id { get; set; }

    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    public int idinscrit { get; set; }

    /// <summary>
    /// Dateop
    /// </summary>
    public DateOnly dateop { get; set; }

    /// <summary>
    /// Is_absent
    /// </summary>
    public bool is_absent { get; set; }

    /// <summary>
    /// globalverse
    /// </summary>
    public decimal globalverse { get; set; }

    /// <summary>
    /// Num_bordero
    /// </summary>
    [StringLength(128)]
    public string? num_bordero { get; set; }

    [ForeignKey("idinscrit")]
    [InverseProperty("meet_presences")]
    public virtual meet_inscription idinscritNavigation { get; set; } = null!;

    [InverseProperty("presence")]
    public virtual ICollection<meet_entree_caisse> meet_entree_caisses { get; set; } = new List<meet_entree_caisse>();

    [ForeignKey("seance_id")]
    [InverseProperty("meet_presences")]
    public virtual meet_seance seance { get; set; } = null!;
}
