using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// core_Phonenumber
/// </summary>
[Table("core_phonenumber", Schema = "tontine_v14")]
[Index("person_id", Name = "association_10_fk2")]
[Index("bank_id", Name = "association_44_fk")]
[Index("country_id", Name = "association_5_fk2")]
[Index("phone_id", Name = "core_phonenumber_pk", IsUnique = true)]
public partial class core_phonenumber
{
    /// <summary>
    /// Identifiant du numero de telephone
    /// </summary>
    [Key]
    public long phone_id { get; set; }

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
    public long country_id { get; set; }

    /// <summary>
    /// Identifiant de la banque
    /// </summary>
    public int? bank_id { get; set; }

    /// <summary>
    /// Person_id
    /// </summary>
    public int? person_id { get; set; }

    /// <summary>
    /// Numero telephone
    /// </summary>
    [StringLength(32)]
    public string phone_no { get; set; } = null!;

    /// <summary>
    /// Represente le numero par defaut
    /// </summary>
    public bool is_defaut { get; set; }

    [ForeignKey("bank_id")]
    [InverseProperty("core_phonenumbers")]
    public virtual core_bank? bank { get; set; }

    [ForeignKey("country_id")]
    [InverseProperty("core_phonenumbers")]
    public virtual core_country country { get; set; } = null!;

    [ForeignKey("person_id")]
    [InverseProperty("core_phonenumbers")]
    public virtual core_person? person { get; set; }
}
