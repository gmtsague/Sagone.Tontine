using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MeetingEntities.Models;

/// <summary>
/// core_country
/// </summary>
[Table("core_country", Schema = "tontine_v14")]
[Index("CountryId", Name = "core_country_pk", IsUnique = true)]
public partial class CoreCountry
{
    /// <summary>
    /// Identifiant du pays
    /// </summary>
    [Key]
    [Column("country_id")]
    public long CountryId { get; set; }

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
    /// Nom du pays
    /// </summary>
    [Column("libelle", TypeName = "jsonb")]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Code (2 caracteres) ISO du pays
    /// </summary>
    [Column("code_iso2")]
    [StringLength(8)]
    public string CodeIso2 { get; set; } = null!;

    /// <summary>
    /// Code (3 caracteres) ISO du pays
    /// </summary>
    [Column("code_iso3")]
    [StringLength(8)]
    public string CodeIso3 { get; set; } = null!;

    /// <summary>
    /// Code telephonique du pays
    /// </summary>
    [Column("phone_code")]
    [StringLength(8)]
    public string PhoneCode { get; set; } = null!;

    /// <summary>
    /// Devise du pays
    /// </summary>
    [Column("devise")]
    [StringLength(128)]
    public string? Devise { get; set; }

    [InverseProperty("Country")]
    public virtual ICollection<CoreBank> CoreBanks { get; set; } = new List<CoreBank>();

    [InverseProperty("Country")]
    public virtual ICollection<CoreEtablissement> CoreEtablissements { get; set; } = new List<CoreEtablissement>();

    [InverseProperty("Country")]
    public virtual ICollection<CorePerson> CorePeople { get; set; } = new List<CorePerson>();

    [InverseProperty("Country")]
    public virtual ICollection<CorePhonenumber> CorePhonenumbers { get; set; } = new List<CorePhonenumber>();
}
