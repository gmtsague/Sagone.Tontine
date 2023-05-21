using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4;

/// <summary>
/// Meet_seance
/// </summary>
[Table("meet_seance", Schema = "tontine_v14")]
[Index("AnneeId", "DivisionId", Name = "association_54_fk")]
[Index("EtabId", "AntenneId", Name = "association_55_fk")]
[Index("SeanceId", Name = "meet_seance_pk", IsUnique = true)]
[Index("AnneeId", "DivisionId", "EtabId", "AntenneId", Name = "uniq_meeting_seance", IsUnique = true)]
public partial class MeetSeance
{
    /// <summary>
    /// Seance_id
    /// </summary>
    [Key]
    [Column("seance_id")]
    public int SeanceId { get; set; }

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
    /// Identifiant de l&apos;annee
    /// </summary>
    [Column("annee_id")]
    public int AnneeId { get; set; }

    /// <summary>
    /// Identifiant de la division
    /// </summary>
    [Column("division_id")]
    public int DivisionId { get; set; }

    /// <summary>
    /// Etab_id
    /// </summary>
    [Column("etab_id")]
    public int? EtabId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;antenne
    /// </summary>
    [Column("antenne_id")]
    public int? AntenneId { get; set; }

    /// <summary>
    /// Date et heure d&apos;ouverture de la reunion
    /// </summary>
    [Column("opendate", TypeName = "timestamp without time zone")]
    public DateTime? Opendate { get; set; }

    /// <summary>
    /// Date et heure de fermeture de la reunion
    /// </summary>
    [Column("closedate", TypeName = "timestamp without time zone")]
    public DateTime? Closedate { get; set; }

    /// <summary>
    /// Total_entrees
    /// </summary>
    [Column("total_entrees")]
    public decimal TotalEntrees { get; set; }

    /// <summary>
    /// Total_Sorties
    /// </summary>
    [Column("total_sorties")]
    public decimal TotalSorties { get; set; }

    /// <summary>
    /// DepenseCollation
    /// </summary>
    [Column("depensecollation")]
    public decimal Depensecollation { get; set; }

    /// <summary>
    /// Compte rendu de la seance de reunion
    /// </summary>
    [Column("compterendu")]
    public string? Compterendu { get; set; }

    /// <summary>
    /// Le statut {CLOSED} indique que la reunion est cloturee et ses donnees ne sont plus modifiables
    /// </summary>
    [Column("status")]
    public int? Status { get; set; }

    [ForeignKey("AnneeId, DivisionId")]
    [InverseProperty("MeetSeances")]
    public virtual CoreSubdivision CoreSubdivision { get; set; } = null!;

    [ForeignKey("EtabId, AntenneId")]
    [InverseProperty("MeetSeances")]
    public virtual MeetAntenne? MeetAntenne { get; set; }

    [InverseProperty("Seance")]
    public virtual ICollection<MeetPresence> MeetPresences { get; set; } = new List<MeetPresence>();

    [InverseProperty("Seance")]
    public virtual ICollection<MeetPret> MeetPrets { get; set; } = new List<MeetPret>();

    [InverseProperty("Seance")]
    public virtual ICollection<MeetSortieCaisse> MeetSortieCaisses { get; set; } = new List<MeetSortieCaisse>();
}
