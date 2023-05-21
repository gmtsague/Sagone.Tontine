using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// core_Phonenumber
/// </summary>
[Table("core_phonenumber", Schema = "tontine")]
[Index("Idperson", Name = "association_10_fk2")]
[Index("Idbank", Name = "association_44_fk")]
[Index("PaysId", Name = "association_5_fk2")]
[Index("PhoneId", Name = "core_phonenumber_pk", IsUnique = true)]
public partial class CorePhonenumber
{
    /// <summary>
    /// Identifiant du numero de telephone
    /// </summary>
    [Key]
    [Column("phone_id")]
    public long PhoneId { get; set; }

    /// <summary>
    /// Identifiant du pays
    /// </summary>
    [Column("pays_id")]
    public long PaysId { get; set; }

    /// <summary>
    /// Identifiant de la banque
    /// </summary>
    [Column("idbank")]
    public int? Idbank { get; set; }

    /// <summary>
    /// Idperson
    /// </summary>
    [Column("idperson")]
    public int? Idperson { get; set; }

    /// <summary>
    /// Numero telephone
    /// </summary>
    [Column("numphone")]
    [StringLength(254)]
    public string Numphone { get; set; } = null!;

    /// <summary>
    /// Represente le numero par defaut
    /// </summary>
    [Column("isdefaut")]
    public bool Isdefaut { get; set; }

    [ForeignKey("Idbank")]
    [InverseProperty("CorePhonenumbers")]
    public virtual CoreBank? IdbankNavigation { get; set; }

    [ForeignKey("Idperson")]
    [InverseProperty("CorePhonenumbers")]
    public virtual CorePerson? IdpersonNavigation { get; set; }

    [ForeignKey("PaysId")]
    [InverseProperty("CorePhonenumbers")]
    public virtual CorePay Pays { get; set; } = null!;
}
