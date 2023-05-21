using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// core_Bankaccount
/// </summary>
public partial class CoreBankaccount
{
    /// <summary>
    /// Account_id
    /// </summary>
    public int AccountId { get; set; }

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
    /// Etab_id
    /// </summary>
    public int? EtabId { get; set; }

    /// <summary>
    /// Person_id
    /// </summary>
    public int? PersonId { get; set; }

    /// <summary>
    /// Identifiant de la banque
    /// </summary>
    public int BankId { get; set; }

    /// <summary>
    /// Compte_no
    /// </summary>
    public string CompteNo { get; set; } = null!;

    /// <summary>
    /// Is_active
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Solde
    /// </summary>
    public decimal Solde { get; set; }

    public virtual CoreBank Bank { get; set; } = null!;

    public virtual CoreEtablissement? Etab { get; set; }

    public virtual CorePerson? Person { get; set; }
}
