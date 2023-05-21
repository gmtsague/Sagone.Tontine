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
[Index("PersonId", Name = "association_11_fk2")]
[Index("EtabId", Name = "association_39_fk")]
[Index("PhotoId", Name = "core_photos_pk", IsUnique = true)]
public partial class CorePhoto
{
    /// <summary>
    /// Identifiant d&apos;une photo
    /// </summary>
    [Key]
    [Column("photo_id")]
    public long PhotoId { get; set; }

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
    /// Etab_id
    /// </summary>
    [Column("etab_id")]
    public int? EtabId { get; set; }

    /// <summary>
    /// Person_id
    /// </summary>
    [Column("person_id")]
    public int? PersonId { get; set; }

    /// <summary>
    /// Image
    /// </summary>
    [Column("image")]
    [StringLength(254)]
    public string Image { get; set; } = null!;

    /// <summary>
    /// Filename
    /// </summary>
    [Column("filename")]
    [StringLength(1024)]
    public string? Filename { get; set; }

    /// <summary>
    /// Extension du fichier
    /// </summary>
    [Column("fileext")]
    [StringLength(32)]
    public string Fileext { get; set; } = null!;

    /// <summary>
    /// Represente une signature
    /// </summary>
    [Column("is_signature")]
    public bool IsSignature { get; set; }

    /// <summary>
    /// Chemin d&apos;acces au fichier
    /// </summary>
    [Column("filepath")]
    [StringLength(1024)]
    public string? Filepath { get; set; }

    /// <summary>
    /// Nombre max de liens autorises
    /// </summary>
    [Column("max_allow_liens")]
    public int MaxAllowLiens { get; set; }

    /// <summary>
    /// Nombre de liens actuels
    /// </summary>
    [Column("nb_actual_liens")]
    public int NbActualLiens { get; set; }

    [ForeignKey("EtabId")]
    [InverseProperty("CorePhotos")]
    public virtual CoreEtablissement? Etab { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("CorePhotos")]
    public virtual CorePerson? Person { get; set; }
}
