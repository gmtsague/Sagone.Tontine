using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models;

/// <summary>
/// Visas
/// </summary>
public partial class Visa
{
    /// <summary>
    /// Identiifant de la signature
    /// </summary>
    public int Idvisa { get; set; }

    /// <summary>
    /// Idevts
    /// </summary>
    public int? Idevts { get; set; }

    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    public int Idinscrit { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int? Idannee { get; set; }

    /// <summary>
    /// Identifiant de la division
    /// </summary>
    public int? Iddivision { get; set; }

    /// <summary>
    /// Identifiant de la configuration de signature
    /// </summary>
    public int Idconfigvisa { get; set; }

    /// <summary>
    /// Date de signature
    /// </summary>
    public DateOnly Datesign { get; set; }

    /// <summary>
    /// Indique si le document est signe par ordre
    /// </summary>
    public bool Parordre { get; set; }

    /// <summary>
    /// Indique si le signataire est le beneficiare
    /// </summary>
    public bool Receiver { get; set; }

    public virtual Monthlyseance? Id { get; set; }

    public virtual Configvisa IdconfigvisaNavigation { get; set; } = null!;

    public virtual Sortiecaisse? IdevtsNavigation { get; set; }

    public virtual Inscription IdinscritNavigation { get; set; } = null!;
}
