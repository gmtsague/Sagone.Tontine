using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Meet_Bureau
/// </summary>
[Table("meet_bureau", Schema = "tontine_v14")]
[Index("etab_id", Name = "association_45_fk")]
[Index("bureau_id", Name = "meet_bureau_pk", IsUnique = true)]
[Index("etab_id", "debut", "fin", Name = "uniq_bureau", IsUnique = true)]
public partial class meet_bureau
{
    /// <summary>
    /// Bureau_id
    /// </summary>
    [Key]
    public int bureau_id { get; set; }

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
    /// Etab_id
    /// </summary>
    public int? etab_id { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    [StringLength(128)]
    public string libelle { get; set; } = null!;

    /// <summary>
    /// Debut
    /// </summary>
    public DateOnly debut { get; set; }

    /// <summary>
    /// Fin
    /// </summary>
    public DateOnly fin { get; set; }

    /// <summary>
    /// Nbperson
    /// </summary>
    public int nbperson { get; set; }

    /// <summary>
    /// Nbvotes
    /// </summary>
    public int nbvotes { get; set; }

    /// <summary>
    /// NbAbstention
    /// </summary>
    public int nbabstention { get; set; }

    /// <summary>
    /// Resumevote
    /// </summary>
    public string? resumevote { get; set; }

    [InverseProperty("bureau")]
    public virtual ICollection<core_annee> core_annees { get; set; } = new List<core_annee>();

    [ForeignKey("etab_id")]
    [InverseProperty("meet_bureaus")]
    public virtual core_etablissement? etab { get; set; }

    [InverseProperty("bureau")]
    public virtual ICollection<meet_membre_bureau> meet_membre_bureaus { get; set; } = new List<meet_membre_bureau>();
}
