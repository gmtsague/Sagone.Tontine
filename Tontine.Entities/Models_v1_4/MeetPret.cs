using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4;

/// <summary>
/// Meet_Pret
/// </summary>
[Table("meet_pret", Schema = "tontine_v14")]
[Index("RefNo", Name = "ak_alt_key_ref_number_meet_pre", IsUnique = true)]
[Index("SeanceId", Name = "association_11_fk")]
[Index("Idinscrit", Name = "association_19_fk")]
[Index("SortiecaisseId", Name = "meet_pret_pk", IsUnique = true)]
public partial class MeetPret
{
    /// <summary>
    /// Sortiecaisse_id
    /// </summary>
    [Key]
    [Column("sortiecaisse_id")]
    public int SortiecaisseId { get; set; }

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
    /// Identifiant de l&apos;inscription
    /// </summary>
    [Column("idinscrit")]
    public int? Idinscrit { get; set; }

    /// <summary>
    /// Seance_id
    /// </summary>
    [Column("seance_id")]
    public int SeanceId { get; set; }

    /// <summary>
    /// No de Reference permettant d&apos;identifier le pret
    /// </summary>
    [Column("ref_no")]
    [StringLength(254)]
    public string RefNo { get; set; } = null!;

    /// <summary>
    /// Duree du pret en nombre de mois
    /// </summary>
    [Column("duree_initiale")]
    public int DureeInitiale { get; set; }

    /// <summary>
    /// Montant de l&apos;interet
    /// </summary>
    [Column("montant_interet")]
    public decimal MontantInteret { get; set; }

    /// <summary>
    /// Montant applicable en cas de penalite sur les interets ou en cas d&apos;absence de cotisation
    /// </summary>
    [Column("montant_penalite")]
    public decimal MontantPenalite { get; set; }

    /// <summary>
    /// Duree_finale
    /// </summary>
    [Column("duree_finale")]
    public int DureeFinale { get; set; }

    /// <summary>
    /// Date effective a laquelle a lieu l&apos;evenement
    /// </summary>
    [Column("dateevts")]
    public DateOnly Dateevts { get; set; }

    /// <summary>
    /// Montant percu par le beneficiaire de l&apos;evenement
    /// </summary>
    [Column("montantpercu")]
    public decimal Montantpercu { get; set; }

    /// <summary>
    /// Observation generale concernant le deroulement de l&apos;evenement
    /// </summary>
    [Column("note")]
    [StringLength(1024)]
    public string? Note { get; set; }

    /// <summary>
    /// Indique que l&apos;evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)
    /// </summary>
    [Column("is_closed")]
    public bool IsClosed { get; set; }

    /// <summary>
    /// Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.
    /// </summary>
    [Column("visarestants")]
    public int Visarestants { get; set; }

    [ForeignKey("Idinscrit")]
    [InverseProperty("MeetPrets")]
    public virtual MeetInscription? IdinscritNavigation { get; set; }

    [InverseProperty("MeetOperationNavigation")]
    public virtual ICollection<MeetVisa> MeetVisas { get; set; } = new List<MeetVisa>();

    [ForeignKey("SeanceId")]
    [InverseProperty("MeetPrets")]
    public virtual MeetSeance Seance { get; set; } = null!;
}
