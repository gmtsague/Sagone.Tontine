using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Meet_Pret
/// </summary>
[Table("meet_pret", Schema = "tontine_v14")]
[Index("ref_no", Name = "ak_alt_key_ref_number_meet_pre", IsUnique = true)]
[Index("seance_id", Name = "association_11_fk")]
[Index("idinscrit", Name = "association_19_fk")]
[Index("sortiecaisse_id", Name = "meet_pret_pk", IsUnique = true)]
public partial class meet_pret
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
    /// No de Reference permettant d&apos;identifier le pret
    /// </summary>
    [StringLength(254)]
    public string ref_no { get; set; } = null!;

    /// <summary>
    /// Duree du pret en nombre de mois
    /// </summary>
    public int duree_initiale { get; set; }

    /// <summary>
    /// Montant de l&apos;interet
    /// </summary>
    public decimal montant_interet { get; set; }

    /// <summary>
    /// Montant applicable en cas de penalite sur les interets ou en cas d&apos;absence de cotisation
    /// </summary>
    public decimal montant_penalite { get; set; }

    /// <summary>
    /// Duree_finale
    /// </summary>
    public int duree_finale { get; set; }

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

    [ForeignKey("idinscrit")]
    [InverseProperty("meet_prets")]
    public virtual meet_inscription? idinscritNavigation { get; set; }

    [InverseProperty("meet_operationNavigation")]
    public virtual ICollection<meet_visa> meet_visas { get; set; } = new List<meet_visa>();

    [ForeignKey("seance_id")]
    [InverseProperty("meet_prets")]
    public virtual meet_seance seance { get; set; } = null!;
}
