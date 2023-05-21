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
[Index("country_id", Name = "association_43_fk")]
[Index("bank_id", Name = "core_bank_pk", IsUnique = true)]
public partial class core_bank
{
    /// <summary>
    /// Identifiant de la banque
    /// </summary>
    [Key]
    public int bank_id { get; set; }

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
    /// Identifiant du pays
    /// </summary>
    public long? country_id { get; set; }

    /// <summary>
    /// Libelle de la banque
    /// </summary>
    [StringLength(1024)]
    public string libelle { get; set; } = null!;

    /// <summary>
    /// Adresse postale de la banque
    /// </summary>
    [StringLength(1024)]
    public string? adresse { get; set; }

    /// <summary>
    /// Contact telephonique de la banque No2
    /// </summary>
    [StringLength(64)]
    public string? email { get; set; }

    /// <summary>
    /// Numero de compte de l&apos;association chez la baqnue
    /// </summary>
    [StringLength(64)]
    public string coderib { get; set; } = null!;

    [InverseProperty("bank")]
    public virtual ICollection<core_bankaccount> core_bankaccounts { get; set; } = new List<core_bankaccount>();

    [InverseProperty("bank")]
    public virtual ICollection<core_phonenumber> core_phonenumbers { get; set; } = new List<core_phonenumber>();

    [ForeignKey("country_id")]
    [InverseProperty("core_banks")]
    public virtual core_country? country { get; set; }
}
