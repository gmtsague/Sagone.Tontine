using System;
using System.Collections.Generic;

namespace Tontine.Entities.olds;

/// <summary>
/// core_Pays
/// </summary>
public partial class CorePay
{
    /// <summary>
    /// Identifiant du pays
    /// </summary>
    public long PaysId { get; set; }

    /// <summary>
    /// Nom du pays
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Code (2 caracteres) ISO du pays
    /// </summary>
    public string Code { get; set; } = null!;

    /// <summary>
    /// Code telephoniquedu pays
    /// </summary>
    public string Phonecode { get; set; } = null!;

    /// <summary>
    /// Devise du pays
    /// </summary>
    public string? Devisepays { get; set; }

    public virtual ICollection<CoreBank> CoreBanks { get; set; } = new List<CoreBank>();

    public virtual ICollection<CoreEtablissement> CoreEtablissements { get; set; } = new List<CoreEtablissement>();

    public virtual ICollection<CorePerson> CorePeople { get; set; } = new List<CorePerson>();

    public virtual ICollection<CorePhonenumber> CorePhonenumbers { get; set; } = new List<CorePhonenumber>();
}
