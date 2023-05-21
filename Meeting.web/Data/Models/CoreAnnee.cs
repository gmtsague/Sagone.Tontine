using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MeetingEntities.Models;

/// <summary>
/// Represente une annee 
/// </summary>
[Table("core_annee", Schema = "tontine_v14")]
[Index("Datedebut", "Datefin", Name = "ak_uniq_annee_core_ann", IsUnique = true)]
[Index("BureauId", Name = "association_24_fk")]
[Index("PreviousYearId", Name = "association_50_fk")]
[Index("FrequenceId", Name = "association_53_fk")]
[Index("AnneeId", Name = "core_annee_pk", IsUnique = true)]
public partial class CoreAnnee
{
    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Key]
    [Column("annee_id")]
    public int AnneeId { get; set; }

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
    /// Frequence_id
    /// </summary>
    [Column("frequence_id")]
    public int FrequenceId { get; set; }

    /// <summary>
    /// Bureau_id
    /// </summary>
    [Column("bureau_id")]
    public int? BureauId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Column("previous_year_id")]
    public int? PreviousYearId { get; set; }

    /// <summary>
    /// Libelle de l&apos;annee
    /// </summary>
    [Column("libelle")]
    [StringLength(128)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Date de debut de l&apos;annee
    /// </summary>
    [Column("datedebut")]
    public DateOnly Datedebut { get; set; }

    /// <summary>
    /// Date de fin de l&apos;annee
    /// </summary>
    [Column("datefin")]
    public DateOnly Datefin { get; set; }

    /// <summary>
    /// Indique l&apos;annee de travail
    /// </summary>
    [Column("is_current")]
    public bool IsCurrent { get; set; }

    /// <summary>
    /// Indique que l&apos;annee et cloturee et ses donnees ne sont plus modifiables
    /// </summary>
    [Column("is_closed")]
    public bool IsClosed { get; set; }

    /// <summary>
    /// Nombre de divisions de l&apos;annee
    /// </summary>
    [Column("nbdivision")]
    public int Nbdivision { get; set; }

    /// <summary>
    /// Copy_data_from_previous
    /// </summary>
    [Column("copy_data_from_previous")]
    public bool CopyDataFromPrevious { get; set; }

    [ForeignKey("BureauId")]
    [InverseProperty("CoreAnnees")]
    public virtual MeetBureau? Bureau { get; set; }

    [InverseProperty("Annee")]
    public virtual ICollection<CoreAnnualSetting> CoreAnnualSettings { get; set; } = new List<CoreAnnualSetting>();

    [InverseProperty("Annee")]
    public virtual ICollection<CoreSubdivision> CoreSubdivisions { get; set; } = new List<CoreSubdivision>();

    [ForeignKey("FrequenceId")]
    [InverseProperty("CoreAnnees")]
    public virtual CoreFrequenceDivision Frequence { get; set; } = null!;

    [InverseProperty("PreviousYear")]
    public virtual ICollection<CoreAnnee> InversePreviousYear { get; set; } = new List<CoreAnnee>();

    [InverseProperty("Annee")]
    public virtual ICollection<MeetConfigVisa> MeetConfigVisas { get; set; } = new List<MeetConfigVisa>();

    [InverseProperty("Annee")]
    public virtual ICollection<MeetInscription> MeetInscriptions { get; set; } = new List<MeetInscription>();

    [InverseProperty("Annee")]
    public virtual ICollection<MeetMaxAllowSignature> MeetMaxAllowSignatures { get; set; } = new List<MeetMaxAllowSignature>();

    [InverseProperty("Annee")]
    public virtual ICollection<MeetRubrique> MeetRubriques { get; set; } = new List<MeetRubrique>();

    [ForeignKey("PreviousYearId")]
    [InverseProperty("InversePreviousYear")]
    public virtual CoreAnnee? PreviousYear { get; set; }
}
