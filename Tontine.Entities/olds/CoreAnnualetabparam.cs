using System;
using System.Collections.Generic;

namespace Tontine.Entities.olds;

/// <summary>
/// core_AnnualEtabParams
/// </summary>
public partial class CoreAnnualetabparam
{
    /// <summary>
    /// Identifiant de l&apos;entite
    /// </summary>
    public long SchoolparamsId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int Idannee { get; set; }

    /// <summary>
    /// Idetab
    /// </summary>
    public int Idetab { get; set; }

    /// <summary>
    /// Nombre max de liens autorises pour la photo d&apos;une personne
    /// </summary>
    public int MaxphotoallowLiens { get; set; }

    public virtual CoreAnnee IdanneeNavigation { get; set; } = null!;

    public virtual CoreEtablissement IdetabNavigation { get; set; } = null!;
}
