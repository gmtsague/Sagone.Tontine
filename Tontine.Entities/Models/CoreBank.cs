using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Etablissement financier
/// </summary>
[Table("core_bank", Schema = "tontine")]
[Index("PaysId", Name = "association_43_fk")]
[Index("Idbank", Name = "core_bank_pk", IsUnique = true)]
public partial class CoreBank
{
    /// <summary>
    /// Identifiant de la banque
    /// </summary>
    [Key]
    [Column("idbank")]
    public int Idbank { get; set; }

    /// <summary>
    /// Identifiant du pays
    /// </summary>
    [Column("pays_id")]
    public long? PaysId { get; set; }

    /// <summary>
    /// Libelle de la banque
    /// </summary>
    [Column("libelle")]
    [StringLength(254)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Adresse postale de la banque
    /// </summary>
    [Column("adresse")]
    [StringLength(254)]
    public string? Adresse { get; set; }

    /// <summary>
    /// Contact telephonique de la banque No2
    /// </summary>
    [Column("email")]
    [StringLength(254)]
    public string? Email { get; set; }

    /// <summary>
    /// Numero de compte de l&apos;association chez la baqnue
    /// </summary>
    [Column("coderib")]
    [StringLength(254)]
    public string Coderib { get; set; } = null!;

    [InverseProperty("IdbankNavigation")]
    public virtual ICollection<CoreBankaccount> CoreBankaccounts { get; set; } = new List<CoreBankaccount>();

    [InverseProperty("IdbankNavigation")]
    public virtual ICollection<CorePhonenumber> CorePhonenumbers { get; set; } = new List<CorePhonenumber>();

    [ForeignKey("PaysId")]
    [InverseProperty("CoreBanks")]
    public virtual CorePay? Pays { get; set; }
}
