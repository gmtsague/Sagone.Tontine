using System;
using System.Collections.Generic;

namespace Tontine.Entities.olds;

/// <summary>
/// Bureau
/// </summary>
public partial class Bureau
{
    /// <summary>
    /// Idbureau
    /// </summary>
    public int Idbureau { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Debut
    /// </summary>
    public DateOnly Debut { get; set; }

    /// <summary>
    /// Fin
    /// </summary>
    public DateOnly Fin { get; set; }

    /// <summary>
    /// Nbperson
    /// </summary>
    public int? Nbperson { get; set; }

    /// <summary>
    /// Nbvotes
    /// </summary>
    public int? Nbvotes { get; set; }

    /// <summary>
    /// NbAbstention
    /// </summary>
    public int? Nbabstention { get; set; }

    public virtual ICollection<CoreAnnee> CoreAnnees { get; set; } = new List<CoreAnnee>();
}
