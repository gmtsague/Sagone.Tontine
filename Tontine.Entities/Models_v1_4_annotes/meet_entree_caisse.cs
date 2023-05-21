using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Meet_Entree_caisse
/// </summary>
[Table("meet_entree_caisse", Schema = "tontine_v14")]
[Index("modepaie_id", Name = "association_18_fk")]
[Index("presence_id", Name = "association_20_fk")]
[Index("engagement_id", Name = "association_52_fk")]
[Index("operation_id", Name = "meet_entree_caisse_pk", IsUnique = true)]
[Index("presence_id", "engagement_id", Name = "uniq_versement", IsUnique = true)]
public partial class meet_entree_caisse
{
    /// <summary>
    /// Operation_id
    /// </summary>
    [Key]
    public int operation_id { get; set; }

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
    /// Identiifant de la signature
    /// </summary>
    public int presence_id { get; set; }

    /// <summary>
    /// Engagement_id
    /// </summary>
    public int? engagement_id { get; set; }

    /// <summary>
    /// Identifiant du mode de paiement
    /// </summary>
    public int modepaie_id { get; set; }

    /// <summary>
    /// MontantVerse
    /// </summary>
    public decimal montantverse { get; set; }

    /// <summary>
    /// Indique si le type represente une sortie de caisse
    /// </summary>
    public bool is_outcome { get; set; }

    [ForeignKey("engagement_id")]
    [InverseProperty("meet_entree_caisses")]
    public virtual meet_engagement? engagement { get; set; }

    [ForeignKey("modepaie_id")]
    [InverseProperty("meet_entree_caisses")]
    public virtual core_modepaie modepaie { get; set; } = null!;

    [ForeignKey("presence_id")]
    [InverseProperty("meet_entree_caisses")]
    public virtual meet_presence presence { get; set; } = null!;
}
