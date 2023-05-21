using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// core_Photos
/// </summary>
[Table("core_photos", Schema = "tontine_v14")]
[Index("person_id", Name = "association_11_fk2")]
[Index("etab_id", Name = "association_39_fk")]
[Index("photo_id", Name = "core_photos_pk", IsUnique = true)]
public partial class core_photo
{
    /// <summary>
    /// Identifiant d&apos;une photo
    /// </summary>
    [Key]
    public long photo_id { get; set; }

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
    /// Person_id
    /// </summary>
    public int? person_id { get; set; }

    /// <summary>
    /// Image
    /// </summary>
    [StringLength(254)]
    public string image { get; set; } = null!;

    /// <summary>
    /// Filename
    /// </summary>
    [StringLength(1024)]
    public string? filename { get; set; }

    /// <summary>
    /// Extension du fichier
    /// </summary>
    [StringLength(32)]
    public string fileext { get; set; } = null!;

    /// <summary>
    /// Represente une signature
    /// </summary>
    public bool is_signature { get; set; }

    /// <summary>
    /// Chemin d&apos;acces au fichier
    /// </summary>
    [StringLength(1024)]
    public string? filepath { get; set; }

    /// <summary>
    /// Nombre max de liens autorises
    /// </summary>
    public int max_allow_liens { get; set; }

    /// <summary>
    /// Nombre de liens actuels
    /// </summary>
    public int nb_actual_liens { get; set; }

    [ForeignKey("etab_id")]
    [InverseProperty("core_photos")]
    public virtual core_etablissement? etab { get; set; }

    [ForeignKey("person_id")]
    [InverseProperty("core_photos")]
    public virtual core_person? person { get; set; }
}
