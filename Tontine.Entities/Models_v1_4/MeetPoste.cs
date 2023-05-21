using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4;

/// <summary>
/// Poste occupe par un membre de l&apos;association
/// </summary>
[Table("meet_poste", Schema = "tontine_v14")]
[Index("Code", Name = "ak_alt_key_poste_meet_pos", IsUnique = true)]
[Index("PosteId", Name = "meet_poste_pk", IsUnique = true)]
public partial class MeetPoste
{
    /// <summary>
    /// Poste_id
    /// </summary>
    [Key]
    [Column("poste_id")]
    public int PosteId { get; set; }

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
    /// Libelle
    /// </summary>
    [Column("libelle", TypeName = "jsonb")]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Les valeurs autorisees sont: {PRESIDENT, TRESORIER, SG, SGA, CC, CENSOR, MEMBER}
    /// </summary>
    [Column("code")]
    [StringLength(64)]
    public string Code { get; set; } = null!;

    [InverseProperty("Poste")]
    public virtual ICollection<MeetConfigVisa> MeetConfigVisas { get; set; } = new List<MeetConfigVisa>();

    [InverseProperty("Poste")]
    public virtual ICollection<MeetMembreBureau> MeetMembreBureaus { get; set; } = new List<MeetMembreBureau>();
}
