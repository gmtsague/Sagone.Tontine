using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Meet_Sortie_Caisse
/// </summary>
[Table("meet_sortie_caisse", Schema = "tontine_v14")]
[Index("seance_id", Name = "association_11_fk3")]
[Index("engagement_id", Name = "association_12_fk")]
[Index("idinscrit", Name = "association_19_fk2")]
[Index("sortiecaisse_id", Name = "meet_sortie_caisse_pk", IsUnique = true)]
[Index("idinscrit", "seance_id", "engagement_id", Name = "uniq_sortie_caisse", IsUnique = true)]
public partial class meet_sortie_caisse
{
    /// <summary>
    /// Sortiecaisse_id
    /// </summary>
    [Key]
    public int sortiecaisse_id { get; set; }

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
    /// Identifiant de l&apos;inscription
    /// </summary>
    public int? idinscrit { get; set; }

    /// <summary>
    /// Seance_id
    /// </summary>
    public int seance_id { get; set; }

    /// <summary>
    /// Engagement_id
    /// </summary>
    public int engagement_id { get; set; }

    /// <summary>
    /// Montant dedie au deplacement des membres
    /// </summary>
    public decimal montant_route { get; set; }

    /// <summary>
    /// Liste des membres designes pour le deplacement
    /// </summary>
    [StringLength(1024)]
    public string? liste_mandataires { get; set; }

    /// <summary>
    /// Date effective a laquelle a lieu l&apos;evenement
    /// </summary>
    public DateOnly dateevts { get; set; }

    /// <summary>
    /// Montant percu par le beneficiaire de l&apos;evenement
    /// </summary>
    public decimal montantpercu { get; set; }

    /// <summary>
    /// Observation generale concernant le deroulement de l&apos;evenement
    /// </summary>
    [StringLength(1024)]
    public string? note { get; set; }

    /// <summary>
    /// Indique que l&apos;evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)
    /// </summary>
    public bool is_closed { get; set; }

    /// <summary>
    /// Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.
    /// </summary>
    public int visarestants { get; set; }

    [ForeignKey("engagement_id")]
    [InverseProperty("meet_sortie_caisses")]
    public virtual meet_engagement engagement { get; set; } = null!;

    [ForeignKey("idinscrit")]
    [InverseProperty("meet_sortie_caisses")]
    public virtual meet_inscription? idinscritNavigation { get; set; }

    [InverseProperty("sortiecaisse")]
    public virtual ICollection<meet_visa> meet_visas { get; set; } = new List<meet_visa>();

    [ForeignKey("seance_id")]
    [InverseProperty("meet_sortie_caisses")]
    public virtual meet_seance seance { get; set; } = null!;
}
