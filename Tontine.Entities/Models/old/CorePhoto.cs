using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models;

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
    /// Idetab
    /// </summary>
    public int? Idetab { get; set; }

    /// <summary>
    /// Idperson
    /// </summary>
    public int? Idperson { get; set; }

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
    public bool Issignature { get; set; }

    /// <summary>
    /// Chemin d&apos;acces au fichier
    /// </summary>
    public string? Filepath { get; set; }

    /// <summary>
    /// Nombre max de liens autorises
    /// </summary>
    public int MaxallowLiens { get; set; }

    /// <summary>
    /// Nombre de liens actuels
    /// </summary>
    public int NbactualLiens { get; set; }

    public virtual CoreEtablissement? IdetabNavigation { get; set; }

    public virtual CorePerson? IdpersonNavigation { get; set; }
}
