using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans;

/// <summary>
/// core_country
/// </summary>
public partial class CoreCountry
{
    /// <summary>
    /// Identifiant du pays
    /// </summary>
    public long CountryId { get; set; }

    /// <summary>
    /// create_uid
    /// </summary>
    public long? CreateUid { get; set; }

    /// <summary>
    /// update_uid
    /// </summary>
    public long? UpdateUid { get; set; }

    /// <summary>
    /// Create_at
    /// </summary>
    public DateTime CreateAt { get; set; }

    /// <summary>
    /// Update_at
    /// </summary>
    public DateTime UpdateAt { get; set; }

    /// <summary>
    /// Nom du pays
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Code (2 caracteres) ISO du pays
    /// </summary>
    public string CodeIso2 { get; set; } = null!;

    /// <summary>
    /// Code (3 caracteres) ISO du pays
    /// </summary>
    public string CodeIso3 { get; set; } = null!;

    /// <summary>
    /// Code telephonique du pays
    /// </summary>
    public string PhoneCode { get; set; } = null!;

    /// <summary>
    /// Devise du pays
    /// </summary>
    public string? Devise { get; set; }

    public virtual ICollection<CoreBank> CoreBanks { get; set; } = new List<CoreBank>();

    public virtual ICollection<CoreEtablissement> CoreEtablissements { get; set; } = new List<CoreEtablissement>();

    public virtual ICollection<CorePerson> CorePeople { get; set; } = new List<CorePerson>();

    public virtual ICollection<CorePhonenumber> CorePhonenumbers { get; set; } = new List<CorePhonenumber>();
}
