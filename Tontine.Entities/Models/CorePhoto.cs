using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// core_Photos
/// </summary>
[Table("core_photos", Schema = "tontine")]
[Index("Idperson", Name = "association_11_fk2")]
[Index("Idetab", Name = "association_39_fk")]
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
    /// Idetab
    /// </summary>
    [Column("idetab")]
    public int? Idetab { get; set; }

    /// <summary>
    /// Idperson
    /// </summary>
    [Column("idperson")]
    public int? Idperson { get; set; }

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
    [StringLength(254)]
    public string? Filename { get; set; }

    /// <summary>
    /// Extension du fichier
    /// </summary>
    [Column("fileext")]
    [StringLength(254)]
    public string Fileext { get; set; } = null!;

    /// <summary>
    /// Represente une signature
    /// </summary>
    [Column("issignature")]
    public bool Issignature { get; set; }

    /// <summary>
    /// Chemin d&apos;acces au fichier
    /// </summary>
    [Column("filepath")]
    [StringLength(254)]
    public string? Filepath { get; set; }

    /// <summary>
    /// Nombre max de liens autorises
    /// </summary>
    [Column("maxallow_liens")]
    public int MaxallowLiens { get; set; }

    /// <summary>
    /// Nombre de liens actuels
    /// </summary>
    [Column("nbactual_liens")]
    public int NbactualLiens { get; set; }

    [ForeignKey("Idetab")]
    [InverseProperty("CorePhotos")]
    public virtual CoreEtablissement? IdetabNavigation { get; set; }

    [ForeignKey("Idperson")]
    [InverseProperty("CorePhotos")]
    public virtual CorePerson? IdpersonNavigation { get; set; }
}
