using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MeetingEntities.Models;

/// <summary>
/// Meet_Sortie_Caisse
/// </summary>
[Table("meet_sortie_caisse", Schema = "tontine_v14")]
[Index("SeanceId", Name = "association_11_fk3")]
//[Index("EngagementId", Name = "association_12_fk")]
[Index("RubriqueId", Name = "association_12_fk")]
[Index("Idinscrit", Name = "association_19_fk2")]
[Index("SortiecaisseId", Name = "meet_sortie_caisse_pk", IsUnique = true)]
[Index("Idinscrit", "SeanceId", "RubriqueId", Name = "uniq_sortie_caisse", IsUnique = true)]
public partial class MeetSortieCaisse
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

    ///// <summary>
    ///// Engagement_id
    ///// </summary>
    //[Column("engagement_id")]
    //public int EngagementId { get; set; }

    /// <summary>
    /// Rubrique_id
    /// </summary>
    [Column("rubrique_id")]
    public int RubriqueId { get; set; }

    /// <summary>
    /// No de Reference permettant d''identifier le document
    /// </summary>
    [Column("ref_no")]
    [StringLength(128)]
    public string? RefNo { get; set; }

    /// <summary>
    /// Benef_principal
    /// </summary>
    [Column("benef_principal")]
    public bool BenefPrincipal { get; set; }

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

    [ForeignKey("RubriqueId")]
    [InverseProperty("MeetSortieCaisses")]
    public virtual MeetRubrique Rubrique { get; set; } = null!;

    //[ForeignKey("EngagementId")]
    //[InverseProperty("MeetSortieCaisses")]
    //public virtual MeetEngagement Engagement { get; set; } = null!;

    [ForeignKey("Idinscrit")]
    [InverseProperty("MeetSortieCaisses")]
    public virtual MeetInscription? IdinscritNavigation { get; set; }

    [InverseProperty("Sortiecaisse")]
    public virtual ICollection<MeetVisa> MeetVisas { get; set; } = new List<MeetVisa>();

    [ForeignKey("SeanceId")]
    [InverseProperty("MeetSortieCaisses")]
    public virtual MeetSeance Seance { get; set; } = null!;
}
