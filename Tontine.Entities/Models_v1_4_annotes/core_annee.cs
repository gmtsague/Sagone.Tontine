using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Represente une annee 
/// </summary>
[Table("core_annee", Schema = "tontine_v14")]
[Index("datedebut", "datefin", Name = "ak_uniq_annee_core_ann", IsUnique = true)]
[Index("bureau_id", Name = "association_24_fk")]
[Index("previous_year_id", Name = "association_50_fk")]
[Index("frequence_id", Name = "association_53_fk")]
[Index("annee_id", Name = "core_annee_pk", IsUnique = true)]
public partial class core_annee
{
    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Key]
    public int annee_id { get; set; }

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
    /// Frequence_id
    /// </summary>
    public int frequence_id { get; set; }

    /// <summary>
    /// Bureau_id
    /// </summary>
    public int? bureau_id { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int? previous_year_id { get; set; }

    /// <summary>
    /// Libelle de l&apos;annee
    /// </summary>
    [StringLength(128)]
    public string libelle { get; set; } = null!;

    /// <summary>
    /// Date de debut de l&apos;annee
    /// </summary>
    public DateOnly datedebut { get; set; }

    /// <summary>
    /// Date de fin de l&apos;annee
    /// </summary>
    public DateOnly datefin { get; set; }

    /// <summary>
    /// Indique l&apos;annee de travail
    /// </summary>
    public bool is_current { get; set; }

    /// <summary>
    /// Indique que l&apos;annee et cloturee et ses donnees ne sont plus modifiables
    /// </summary>
    public bool is_closed { get; set; }

    /// <summary>
    /// Nombre de divisions de l&apos;annee
    /// </summary>
    public int nbdivision { get; set; }

    /// <summary>
    /// Copy_data_from_previous
    /// </summary>
    public bool copy_data_from_previous { get; set; }

    [InverseProperty("previous_year")]
    public virtual ICollection<core_annee> Inverseprevious_year { get; set; } = new List<core_annee>();

    [ForeignKey("bureau_id")]
    [InverseProperty("core_annees")]
    public virtual meet_bureau? bureau { get; set; }

    [InverseProperty("annee")]
    public virtual ICollection<core_annual_setting> core_annual_settings { get; set; } = new List<core_annual_setting>();

    [InverseProperty("annee")]
    public virtual ICollection<core_subdivision> core_subdivisions { get; set; } = new List<core_subdivision>();

    [ForeignKey("frequence_id")]
    [InverseProperty("core_annees")]
    public virtual core_frequence_division frequence { get; set; } = null!;

    [InverseProperty("annee")]
    public virtual ICollection<meet_config_visa> meet_config_visas { get; set; } = new List<meet_config_visa>();

    [InverseProperty("annee")]
    public virtual ICollection<meet_inscription> meet_inscriptions { get; set; } = new List<meet_inscription>();

    [InverseProperty("annee")]
    public virtual ICollection<meet_max_allow_signature> meet_max_allow_signatures { get; set; } = new List<meet_max_allow_signature>();

    [InverseProperty("annee")]
    public virtual ICollection<meet_rubrique> meet_rubriques { get; set; } = new List<meet_rubrique>();

    [ForeignKey("previous_year_id")]
    [InverseProperty("Inverseprevious_year")]
    public virtual core_annee? previous_year { get; set; }
}
