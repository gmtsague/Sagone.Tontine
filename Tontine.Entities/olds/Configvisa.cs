using System;
using System.Collections.Generic;

namespace Tontine.Entities.olds;

/// <summary>
/// Represente l&apos;ensemble des autorisatios de signature de documents au sein de l&apos;association
/// </summary>
public partial class Configvisa
{
    /// <summary>
    /// Identifiant de la configuration de signature
    /// </summary>
    public int Idconfigvisa { get; set; }

    /// <summary>
    /// Idposte
    /// </summary>
    public int Idposte { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int Idannee { get; set; }

    /// <summary>
    /// Identifiant du type d&apos;evenement
    /// </summary>
    public int Idtype { get; set; }

    /// <summary>
    /// Numero d&apos;ordre de la signature pour un type de document
    /// </summary>
    public int Numordre { get; set; }

    public virtual CoreAnnee IdanneeNavigation { get; set; } = null!;

    public virtual Poste IdposteNavigation { get; set; } = null!;

    public virtual Rubrique IdtypeNavigation { get; set; } = null!;

    public virtual ICollection<Visa> Visas { get; set; } = new List<Visa>();
}
