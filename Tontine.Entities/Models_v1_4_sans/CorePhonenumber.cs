using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans;

/// <summary>
/// core_Phonenumber
/// </summary>
public partial class CorePhonenumber
{
    /// <summary>
    /// Identifiant du numero de telephone
    /// </summary>
    public long PhoneId { get; set; }

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
    /// Identifiant du pays
    /// </summary>
    public long CountryId { get; set; }

    /// <summary>
    /// Identifiant de la banque
    /// </summary>
    public int? BankId { get; set; }

    /// <summary>
    /// Person_id
    /// </summary>
    public int? PersonId { get; set; }

    /// <summary>
    /// Numero telephone
    /// </summary>
    public string PhoneNo { get; set; } = null!;

    /// <summary>
    /// Represente le numero par defaut
    /// </summary>
    public bool IsDefaut { get; set; }

    public virtual CoreBank? Bank { get; set; }

    public virtual CoreCountry Country { get; set; } = null!;

    public virtual CorePerson? Person { get; set; }
}
