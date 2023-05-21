using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Etablissement financier
/// </summary>
[Table("core_bank", Schema = "tontine_v14")]
[Index("CountryId", Name = "association_43_fk")]
[Index("BankId", Name = "core_bank_pk", IsUnique = true)]
public partial class CoreBank
{
    /// <summary>
    /// Identifiant de la banque
    /// </summary>
    [Key]
    [Column("bank_id")]
    public int BankId { get; set; }

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
    /// Identifiant du pays
    /// </summary>
    [Column("country_id")]
    public long? CountryId { get; set; }

    /// <summary>
    /// Libelle de la banque
    /// </summary>
    [Column("libelle")]
    [StringLength(1024)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Adresse postale de la banque
    /// </summary>
    [Column("adresse")]
    [StringLength(1024)]
    public string? Adresse { get; set; }

    /// <summary>
    /// Contact telephonique de la banque No2
    /// </summary>
    [Column("email")]
    [StringLength(64)]
    public string? Email { get; set; }

    /// <summary>
    /// Numero de compte de l&apos;association chez la baqnue
    /// </summary>
    [Column("coderib")]
    [StringLength(64)]
    public string Coderib { get; set; } = null!;

    [InverseProperty("Bank")]
    public virtual ICollection<CoreBankaccount> CoreBankaccounts { get; set; } = new List<CoreBankaccount>();

    [InverseProperty("Bank")]
    public virtual ICollection<CorePhonenumber> CorePhonenumbers { get; set; } = new List<CorePhonenumber>();

    [ForeignKey("CountryId")]
    [InverseProperty("CoreBanks")]
    public virtual CoreCountry? Country { get; set; }
}
