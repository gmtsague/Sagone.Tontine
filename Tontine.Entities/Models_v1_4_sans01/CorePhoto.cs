using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// core_Photos
/// </summary>
public partial class CorePhoto
{
    /// <summary>
    /// Identifiant d&apos;une photo
    /// </summary>
    public long PhotoId { get; set; }

    /// <summary>
    /// create_uid
    /// </summary>
    public long? CreateUid { get; set; }

    /// <summary>
    /// update_uid
    /// </summary>
    public long? UpdateUid { get; set; }

    /// <summary>
    /// Create_at
    /// </summary>
    public DateTime CreateAt { get; set; }

    /// <summary>
    /// Update_at
    /// </summary>
    public DateTime UpdateAt { get; set; }

    /// <summary>
    /// Etab_id
    /// </summary>
    public int? EtabId { get; set; }

    /// <summary>
    /// Person_id
    /// </summary>
    public int? PersonId { get; set; }

    /// <summary>
    /// Image
    /// </summary>
    public string Image { get; set; } = null!;

    /// <summary>
    /// Filename
    /// </summary>
    public string? Filename { get; set; }

    /// <summary>
    /// Extension du fichier
    /// </summary>
    public string Fileext { get; set; } = null!;

    /// <summary>
    /// Represente une signature
    /// </summary>
    public bool IsSignature { get; set; }

    /// <summary>
    /// Chemin d&apos;acces au fichier
    /// </summary>
    public string? Filepath { get; set; }

    /// <summary>
    /// Nombre max de liens autorises
    /// </summary>
    public int MaxAllowLiens { get; set; }

    /// <summary>
    /// Nombre de liens actuels
    /// </summary>
    public int NbActualLiens { get; set; }

    public virtual CoreEtablissement? Etab { get; set; }

    public virtual CorePerson? Person { get; set; }
}
