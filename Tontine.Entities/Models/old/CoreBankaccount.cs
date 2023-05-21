using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models;

/// <summary>
/// core_Bankaccount
/// </summary>
public partial class CoreBankaccount
{
    /// <summary>
    /// Idcompte
    /// </summary>
    public int Idcompte { get; set; }

    /// <summary>
    /// Idetab
    /// </summary>
    public int? Idetab { get; set; }

    /// <summary>
    /// Idperson
    /// </summary>
    public int? Idperson { get; set; }

    /// <summary>
    /// Identifiant de la banque
    /// </summary>
    public int Idbank { get; set; }

    /// <summary>
    /// Numcompte
    /// </summary>
    public string Numcompte { get; set; } = null!;

    /// <summary>
    /// Isactive
    /// </summary>
    public bool Isactive { get; set; }

    /// <summary>
    /// solde
    /// </summary>
    public decimal Solde { get; set; }

    public virtual CoreBank IdbankNavigation { get; set; } = null!;

    public virtual CoreEtablissement? IdetabNavigation { get; set; }

    public virtual CorePerson? IdpersonNavigation { get; set; }

    public virtual ICollection<Presence> Presences { get; set; } = new List<Presence>();
}
