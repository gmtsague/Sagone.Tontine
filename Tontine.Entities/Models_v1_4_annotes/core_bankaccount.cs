using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// core_Bankaccount
/// </summary>
[Table("core_bankaccount", Schema = "tontine_v14")]
[Index("bank_id", Name = "association_17_fk")]
[Index("person_id", Name = "association_27_fk")]
[Index("etab_id", Name = "association_28_fk")]
[Index("account_id", Name = "core_bankaccount_pk", IsUnique = true)]
[Index("bank_id", "compte_no", Name = "uniq_bank_account", IsUnique = true)]
public partial class core_bankaccount
{
    /// <summary>
    /// Account_id
    /// </summary>
    [Key]
    public int account_id { get; set; }

    /// <summary>
    /// create_uid
    /// </summary>
    public long? create_uid { get; set; }

    /// <summary>
    /// update_uid
    /// </summary>
    public long? update_uid { get; set; }

    /// <summary>
    /// Create_at
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime create_at { get; set; }

    /// <summary>
    /// Update_at
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime update_at { get; set; }

    /// <summary>
    /// Etab_id
    /// </summary>
    public int? etab_id { get; set; }

    /// <summary>
    /// Person_id
    /// </summary>
    public int? person_id { get; set; }

    /// <summary>
    /// Identifiant de la banque
    /// </summary>
    public int bank_id { get; set; }

    /// <summary>
    /// Compte_no
    /// </summary>
    [StringLength(64)]
    public string compte_no { get; set; } = null!;

    /// <summary>
    /// Is_active
    /// </summary>
    public bool is_active { get; set; }

    /// <summary>
    /// Solde
    /// </summary>
    public decimal solde { get; set; }

    [ForeignKey("bank_id")]
    [InverseProperty("core_bankaccounts")]
    public virtual core_bank bank { get; set; } = null!;

    [ForeignKey("etab_id")]
    [InverseProperty("core_bankaccounts")]
    public virtual core_etablissement? etab { get; set; }

    [ForeignKey("person_id")]
    [InverseProperty("core_bankaccounts")]
    public virtual core_person? person { get; set; }
}
