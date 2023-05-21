using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models;

/// <summary>
/// Represente ue antenne de l&apos;association
/// </summary>
public partial class Antenne
{
    /// <summary>
    /// Identifiant de l&apos;antenne
    /// </summary>
    public int Idantenne { get; set; }

    /// <summary>
    /// Libelle de l&apos;antenne
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Date de creation de l&apos;antenne
    /// </summary>
    public DateOnly? Creationdate { get; set; }

    public virtual ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
}
