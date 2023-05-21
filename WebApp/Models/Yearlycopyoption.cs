using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models;

/// <summary>
/// yearlycopyoption
/// </summary>
public partial class Yearlycopyoption
{
    /// <summary>
    /// Idcopyoption
    /// </summary>
    public int Idcopyoption { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int Idannee { get; set; }

    /// <summary>
    /// Previousyear
    /// </summary>
    public int Previousyear { get; set; }

    /// <summary>
    /// CopyEngagements
    /// </summary>
    public bool Copyengagements { get; set; }

    /// <summary>
    /// CopyMembers
    /// </summary>
    public bool Copymembers { get; set; }

    public virtual CoreAnnee IdanneeNavigation { get; set; } = null!;
}
