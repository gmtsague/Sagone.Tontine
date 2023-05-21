using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Poste occupe par un membre de l&apos;association
/// </summary>
[Table("meet_poste", Schema = "tontine_v14")]
[Index("code", Name = "ak_alt_key_poste_meet_pos", IsUnique = true)]
[Index("poste_id", Name = "meet_poste_pk", IsUnique = true)]
public partial class meet_poste
{
    /// <summary>
    /// Poste_id
    /// </summary>
    [Key]
    public int poste_id { get; set; }

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
    /// Libelle
    /// </summary>
    [Column(TypeName = "jsonb")]
    public string libelle { get; set; } = null!;

    /// <summary>
    /// Les valeurs autorisees sont: {PRESIDENT, TRESORIER, SG, SGA, CC, CENSOR, MEMBER}
    /// </summary>
    [StringLength(64)]
    public string code { get; set; } = null!;

    [InverseProperty("poste")]
    public virtual ICollection<meet_config_visa> meet_config_visas { get; set; } = new List<meet_config_visa>();

    [InverseProperty("poste")]
    public virtual ICollection<meet_membre_bureau> meet_membre_bureaus { get; set; } = new List<meet_membre_bureau>();
}
