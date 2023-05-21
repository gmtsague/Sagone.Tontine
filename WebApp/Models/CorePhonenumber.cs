using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models;

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
    /// Identifiant du pays
    /// </summary>
    public long PaysId { get; set; }

    /// <summary>
    /// Identifiant de la banque
    /// </summary>
    public int? Idbank { get; set; }

    /// <summary>
    /// Idperson
    /// </summary>
    public int? Idperson { get; set; }

    /// <summary>
    /// Numero telephone
    /// </summary>
    public string Numphone { get; set; } = null!;

    /// <summary>
    /// Represente le numero par defaut
    /// </summary>
    public bool Isdefaut { get; set; }

    public virtual CoreBank? IdbankNavigation { get; set; }

    public virtual CorePerson? IdpersonNavigation { get; set; }

    public virtual CorePay Pays { get; set; } = null!;
}
