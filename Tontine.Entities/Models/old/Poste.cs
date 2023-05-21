using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models;

/// <summary>
/// Poste occupe par un membre de l&apos;association
/// </summary>
public partial class Poste
{
    /// <summary>
    /// Idposte
    /// </summary>
    public int Idposte { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Ispresident
    /// </summary>
    public bool Ispresident { get; set; }

    /// <summary>
    /// Istresorier
    /// </summary>
    public bool Istresorier { get; set; }

    /// <summary>
    /// Issg
    /// </summary>
    public bool Issg { get; set; }

    /// <summary>
    /// Issga
    /// </summary>
    public bool Issga { get; set; }

    /// <summary>
    /// Iscc
    /// </summary>
    public bool Iscc { get; set; }

    /// <summary>
    /// Ismembre
    /// </summary>
    public bool Ismembre { get; set; }

    public virtual ICollection<Configvisa> Configvisas { get; set; } = new List<Configvisa>();

    public virtual ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
}
