using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Meet_Engagement
/// </summary>
[Table("meet_engagement", Schema = "tontine_v14")]
[Index("rubrique_id", Name = "association_2_fk")]
[Index("person_id", Name = "association_59_fk")]
[Index("engagement_id", Name = "meet_engagement_pk", IsUnique = true)]
public partial class meet_engagement
{
    /// <summary>
    /// Engagement_id
    /// </summary>
    [Key]
    public int engagement_id { get; set; }

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
    /// Identifiant d&apos;une configuration
    /// </summary>
    public int rubrique_id { get; set; }

    /// <summary>
    /// Person_id
    /// </summary>
    public int person_id { get; set; }

    /// <summary>
    /// Cumul des versements sur une rubrique
    /// </summary>
    public decimal cumulverse { get; set; }

    /// <summary>
    /// Solde
    /// </summary>
    public decimal solde { get; set; }

    /// <summary>
    /// Indique si le type represente une sortie de caisse
    /// </summary>
    public bool is_outcome { get; set; }

    /// <summary>
    /// Indique que l&apos;evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)
    /// </summary>
    public bool is_closed { get; set; }

    /// <summary>
    /// Engagement_Date
    /// </summary>
    public DateOnly? engagement_date { get; set; }

    [InverseProperty("engagement")]
    public virtual ICollection<meet_entree_caisse> meet_entree_caisses { get; set; } = new List<meet_entree_caisse>();

    [InverseProperty("engagement")]
    public virtual ICollection<meet_sortie_caisse> meet_sortie_caisses { get; set; } = new List<meet_sortie_caisse>();

    [ForeignKey("person_id")]
    [InverseProperty("meet_engagements")]
    public virtual core_person person { get; set; } = null!;

    [ForeignKey("rubrique_id")]
    [InverseProperty("meet_engagements")]
    public virtual meet_rubrique rubrique { get; set; } = null!;
}
