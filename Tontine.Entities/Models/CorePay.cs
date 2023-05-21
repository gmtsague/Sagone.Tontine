using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// core_Pays
/// </summary>
[Table("core_pays", Schema = "tontine")]
[Index("PaysId", Name = "core_pays_pk", IsUnique = true)]
public partial class CorePay
{
    /// <summary>
    /// Identifiant du pays
    /// </summary>
    [Key]
    [Column("pays_id")]
    public long PaysId { get; set; }

    /// <summary>
    /// Nom du pays
    /// </summary>
    [Column("libelle")]
    [StringLength(254)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Code (2 caracteres) ISO du pays
    /// </summary>
    [Column("code")]
    [StringLength(254)]
    public string Code { get; set; } = null!;

    /// <summary>
    /// Code telephoniquedu pays
    /// </summary>
    [Column("phonecode")]
    [StringLength(254)]
    public string Phonecode { get; set; } = null!;

    /// <summary>
    /// Devise du pays
    /// </summary>
    [Column("devisepays")]
    [StringLength(254)]
    public string? Devisepays { get; set; }

    [InverseProperty("Pays")]
    public virtual ICollection<CoreBank> CoreBanks { get; set; } = new List<CoreBank>();

    [InverseProperty("Pays")]
    public virtual ICollection<CoreEtablissement> CoreEtablissements { get; set; } = new List<CoreEtablissement>();

    [InverseProperty("Pays")]
    public virtual ICollection<CorePerson> CorePeople { get; set; } = new List<CorePerson>();

    [InverseProperty("Pays")]
    public virtual ICollection<CorePhonenumber> CorePhonenumbers { get; set; } = new List<CorePhonenumber>();
}
