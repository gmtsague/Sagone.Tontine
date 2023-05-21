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
[Index("modepaie_id", Name = "core_modepaie_pk", IsUnique = true)]
public partial class core_modepaie
{
    /// <summary>
    /// Identifiant du mode de paiement
    /// </summary>
    [Key]
    public int modepaie_id { get; set; }

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
    /// Libelle du mode de paiement
    /// </summary>
    [StringLength(128)]
    public string libelle { get; set; } = null!;

    /// <summary>
    /// Indique si le mode represnte le CASH
    /// </summary>
    public bool is_cash { get; set; }

    [InverseProperty("modepaie")]
    public virtual ICollection<meet_entree_caisse> meet_entree_caisses { get; set; } = new List<meet_entree_caisse>();
}
