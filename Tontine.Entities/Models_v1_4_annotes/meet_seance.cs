using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Meet_seance
/// </summary>
[Table("meet_seance", Schema = "tontine_v14")]
[Index("annee_id", "division_id", Name = "association_54_fk")]
[Index("etab_id", "antenne_id", Name = "association_55_fk")]
[Index("seance_id", Name = "meet_seance_pk", IsUnique = true)]
[Index("annee_id", "division_id", "etab_id", "antenne_id", Name = "uniq_meeting_seance", IsUnique = true)]
public partial class meet_seance
{
    /// <summary>
    /// Seance_id
    /// </summary>
    [Key]
    public int seance_id { get; set; }

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
    /// Identifiant de l&apos;annee
    /// </summary>
    public int annee_id { get; set; }

    /// <summary>
    /// Identifiant de la division
    /// </summary>
    public int division_id { get; set; }

    /// <summary>
    /// Etab_id
    /// </summary>
    public int? etab_id { get; set; }

    /// <summary>
    /// Identifiant de l&apos;antenne
    /// </summary>
    public int? antenne_id { get; set; }

    /// <summary>
    /// Date et heure d&apos;ouverture de la reunion
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime? opendate { get; set; }

    /// <summary>
    /// Date et heure de fermeture de la reunion
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime? closedate { get; set; }

    /// <summary>
    /// Total_entrees
    /// </summary>
    public decimal total_entrees { get; set; }

    /// <summary>
    /// Total_Sorties
    /// </summary>
    public decimal total_sorties { get; set; }

    /// <summary>
    /// DepenseCollation
    /// </summary>
    public decimal depensecollation { get; set; }

    /// <summary>
    /// Compte rendu de la seance de reunion
    /// </summary>
    public string? compterendu { get; set; }

    /// <summary>
    /// Le statut {CLOSED} indique que la reunion est cloturee et ses donnees ne sont plus modifiables
    /// </summary>
    public int? status { get; set; }

    [ForeignKey("annee_id, division_id")]
    [InverseProperty("meet_seances")]
    public virtual core_subdivision core_subdivision { get; set; } = null!;

    [ForeignKey("etab_id, antenne_id")]
    [InverseProperty("meet_seances")]
    public virtual meet_antenne? meet_antenne { get; set; }

    [InverseProperty("seance")]
    public virtual ICollection<meet_presence> meet_presences { get; set; } = new List<meet_presence>();

    [InverseProperty("seance")]
    public virtual ICollection<meet_pret> meet_prets { get; set; } = new List<meet_pret>();

    [InverseProperty("seance")]
    public virtual ICollection<meet_sortie_caisse> meet_sortie_caisses { get; set; } = new List<meet_sortie_caisse>();
}
