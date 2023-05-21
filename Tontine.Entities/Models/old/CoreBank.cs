using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models;

/// <summary>
/// Etablissement financier
/// </summary>
public partial class CoreBank
{
    /// <summary>
    /// Identifiant de la banque
    /// </summary>
    public int Idbank { get; set; }

    /// <summary>
    /// Identifiant du pays
    /// </summary>
    public long? PaysId { get; set; }

    /// <summary>
    /// Libelle de la banque
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Adresse postale de la banque
    /// </summary>
    public string? Adresse { get; set; }

    /// <summary>
    /// Contact telephonique de la banque No2
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Numero de compte de l&apos;association chez la baqnue
    /// </summary>
    public string Coderib { get; set; } = null!;

    public virtual ICollection<CoreBankaccount> CoreBankaccounts { get; set; } = new List<CoreBankaccount>();

    public virtual ICollection<CorePhonenumber> CorePhonenumbers { get; set; } = new List<CorePhonenumber>();

    public virtual CorePay? Pays { get; set; }
}
