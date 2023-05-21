using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4;

/// <summary>
/// core_Phonenumber
/// </summary>
[Table("core_phonenumber", Schema = "tontine_v14")]
[Index("PersonId", Name = "association_10_fk2")]
[Index("BankId", Name = "association_44_fk")]
[Index("CountryId", Name = "association_5_fk2")]
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
    public long CountryId { get; set; }

    /// <summary>
    /// Identifiant de la banque
    /// </summary>
    [Column("bank_id")]
    public int? BankId { get; set; }

    /// <summary>
    /// Person_id
    /// </summary>
    [Column("person_id")]
    public int? PersonId { get; set; }

    /// <summary>
    /// Numero telephone
    /// </summary>
    [Column("phone_no")]
    [StringLength(32)]
    public string PhoneNo { get; set; } = null!;

    /// <summary>
    /// Represente le numero par defaut
    /// </summary>
    [Column("is_defaut")]
    public bool IsDefaut { get; set; }

    [ForeignKey("BankId")]
    [InverseProperty("CorePhonenumbers")]
    public virtual CoreBank? Bank { get; set; }

    [ForeignKey("CountryId")]
    [InverseProperty("CorePhonenumbers")]
    public virtual CoreCountry Country { get; set; } = null!;

    [ForeignKey("PersonId")]
    [InverseProperty("CorePhonenumbers")]
    public virtual CorePerson? Person { get; set; }
}
