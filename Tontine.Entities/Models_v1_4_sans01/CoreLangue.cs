using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// core_Langue
/// </summary>
public partial class CoreLangue
{
    /// <summary>
    /// Identifiant de la langue
    /// </summary>
    public int LangueId { get; set; }

    /// <summary>
    /// Libelle de la langue
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Code ISO de la langue
    /// </summary>
    public string Isocode { get; set; } = null!;

    /// <summary>
    /// Indique la langue par defaut
    /// </summary>
    public bool IsDefault { get; set; }

    /// <summary>
    /// Isactive
    /// </summary>
    public bool IsActive { get; set; }

    public virtual ICollection<CoreUser> CoreUsers { get; set; } = new List<CoreUser>();
}
