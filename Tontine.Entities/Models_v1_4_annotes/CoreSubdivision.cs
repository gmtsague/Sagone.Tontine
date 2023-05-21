using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Represente le decoupage mensuel de l&apos;annee
/// </summary>
[PrimaryKey("AnneeId", "DivisionId")]
[Table("core_subdivision", Schema = "tontine_v14")]
[Index("MonthDate", Name = "ak_uniq_subdivision_core_sub", IsUnique = true)]
[Index("AnneeId", Name = "association_1_fk")]
[Index("AnneeId", "DivisionId", Name = "core_subdivision_pk", IsUnique = true)]
public partial class CoreSubdivision
{
    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Key]
    [Column("annee_id")]
    public int AnneeId { get; set; }

    /// <summary>
    /// Identifiant de la division
    /// </summary>
    [Key]
    [Column("division_id")]
    public int DivisionId { get; set; }

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
    /// Libelle de la division
    /// </summary>
    [Column("libelle")]
    [StringLength(128)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Date de debut de la division
    /// </summary>
    [Column("month_date")]
    public DateOnly MonthDate { get; set; }

    /// <summary>
    /// Jour du mois ou aura lieu la reunion
    /// </summary>
    [Column("month_day")]
    public int? MonthDay { get; set; }

    /// <summary>
    /// Numero d&apos;ordre de la division
    /// </summary>
    [Column("numordre")]
    public int Numordre { get; set; }

    [ForeignKey("AnneeId")]
    [InverseProperty("CoreSubdivisions")]
    public virtual CoreAnnee Annee { get; set; } = null!;

    [InverseProperty("CoreSubdivision")]
    public virtual ICollection<MeetOrdrePassage> MeetOrdrePassages { get; set; } = new List<MeetOrdrePassage>();

    [InverseProperty("CoreSubdivision")]
    public virtual ICollection<MeetSeance> MeetSeances { get; set; } = new List<MeetSeance>();
}
