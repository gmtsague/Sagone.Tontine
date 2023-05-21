using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MeetingEntities.Models;

/// <summary>
/// core_Bankaccount
/// </summary>
[Table("core_bankaccount", Schema = "tontine_v14")]
[Index("BankId", Name = "association_17_fk")]
[Index("PersonId", Name = "association_27_fk")]
[Index("EtabId", Name = "association_28_fk")]
[Index("AccountId", Name = "core_bankaccount_pk", IsUnique = true)]
[Index("BankId", "CompteNo", Name = "uniq_bank_account", IsUnique = true)]
public partial class CoreBankaccount
{
    /// <summary>
    /// Account_id
    /// </summary>
    [Key]
    [Column("account_id")]
    public int AccountId { get; set; }

    /// <summary>
    /// create_uid
    /// </summary>
    [Column("create_uid")]
    public long? CreateUid { get; set; }

    /// <summary>
    /// update_uid
    /// </summary>
    [Column("update_uid")]
    public long? UpdateUid { get; set; }

    /// <summary>
    /// Create_at
    /// </summary>
    [Column("create_at", TypeName = "timestamp without time zone")]
    public DateTime CreateAt { get; set; }

    /// <summary>
    /// Update_at
    /// </summary>
    [Column("update_at", TypeName = "timestamp without time zone")]
    public DateTime UpdateAt { get; set; }

    /// <summary>
    /// Etab_id
    /// </summary>
    [Column("etab_id")]
    public int? EtabId { get; set; }

    /// <summary>
    /// Person_id
    /// </summary>
    [Column("person_id")]
    public int? PersonId { get; set; }

    /// <summary>
    /// Identifiant de la banque
    /// </summary>
    [Column("bank_id")]
    public int BankId { get; set; }

    /// <summary>
    /// Compte_no
    /// </summary>
    [Column("compte_no")]
    [StringLength(64)]
    public string CompteNo { get; set; } = null!;

    /// <summary>
    /// Is_active
    /// </summary>
    [Column("is_active")]
    public bool IsActive { get; set; }

    /// <summary>
    /// Solde
    /// </summary>
    [Column("solde")]
    public decimal Solde { get; set; }

    /// <summary>
    /// IsDefault
    /// </summary>
    [Column("is_default")]
    public bool IsDefault { get; set; }

    [ForeignKey("BankId")]
    [InverseProperty("CoreBankaccounts")]
    public virtual CoreBank Bank { get; set; } = null!;

    [ForeignKey("EtabId")]
    [InverseProperty("CoreBankaccounts")]
    public virtual CoreEtablissement? Etab { get; set; }

    [ForeignKey("PersonId")]
    [InverseProperty("CoreBankaccounts")]
    public virtual CorePerson? Person { get; set; }
}
