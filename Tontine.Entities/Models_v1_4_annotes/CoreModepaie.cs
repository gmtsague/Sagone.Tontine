using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Mode de paiement utilise par un membre
/// </summary>
[Table("core_modepaie", Schema = "tontine_v14")]
[Index("ModepaieId", Name = "core_modepaie_pk", IsUnique = true)]
public partial class CoreModepaie
{
    /// <summary>
    /// Identifiant du mode de paiement
    /// </summary>
    [Key]
    [Column("modepaie_id")]
    public int ModepaieId { get; set; }

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
    /// Libelle du mode de paiement
    /// </summary>
    [Column("libelle")]
    [StringLength(128)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Indique si le mode represnte le CASH
    /// </summary>
    [Column("is_cash")]
    public bool IsCash { get; set; }

    [InverseProperty("Modepaie")]
    public virtual ICollection<MeetEntreeCaisse> MeetEntreeCaisses { get; set; } = new List<MeetEntreeCaisse>();
}
