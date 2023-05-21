using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// core_Bankaccount
/// </summary>
[Table("core_bankaccount", Schema = "tontine")]
[Index("Idbank", Name = "association_17_fk")]
[Index("Idperson", Name = "association_27_fk")]
[Index("Idetab", Name = "association_28_fk")]
[Index("Idcompte", Name = "core_bankaccount_pk", IsUnique = true)]
public partial class CoreBankaccount
{
    /// <summary>
    /// Idcompte
    /// </summary>
    [Key]
    [Column("idcompte")]
    public int Idcompte { get; set; }

    /// <summary>
    /// Idetab
    /// </summary>
    [Column("idetab")]
    public int? Idetab { get; set; }

    /// <summary>
    /// Idperson
    /// </summary>
    [Column("idperson")]
    public int? Idperson { get; set; }

    /// <summary>
    /// Identifiant de la banque
    /// </summary>
    [Column("idbank")]
    public int Idbank { get; set; }

    /// <summary>
    /// Numcompte
    /// </summary>
    [Column("numcompte")]
    [StringLength(254)]
    public string Numcompte { get; set; } = null!;

    /// <summary>
    /// Isactive
    /// </summary>
    [Column("isactive")]
    public bool Isactive { get; set; }

    /// <summary>
    /// solde
    /// </summary>
    [Column("solde")]
    public decimal Solde { get; set; }

    [ForeignKey("Idbank")]
    [InverseProperty("CoreBankaccounts")]
    public virtual CoreBank IdbankNavigation { get; set; } = null!;

    [ForeignKey("Idetab")]
    [InverseProperty("CoreBankaccounts")]
    public virtual CoreEtablissement? IdetabNavigation { get; set; }

    [ForeignKey("Idperson")]
    [InverseProperty("CoreBankaccounts")]
    public virtual CorePerson? IdpersonNavigation { get; set; }

    [InverseProperty("IdcompteNavigation")]
    public virtual ICollection<Presence> Presences { get; set; } = new List<Presence>();
}
