using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// core_country
/// </summary>
[Table("core_country", Schema = "tontine_v14")]
[Index("country_id", Name = "core_country_pk", IsUnique = true)]
public partial class core_country
{
    /// <summary>
    /// Identifiant du pays
    /// </summary>
    [Key]
    public long country_id { get; set; }

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
    /// Nom du pays
    /// </summary>
    [Column(TypeName = "jsonb")]
    public string libelle { get; set; } = null!;

    /// <summary>
    /// Code (2 caracteres) ISO du pays
    /// </summary>
    [StringLength(8)]
    public string code_iso2 { get; set; } = null!;

    /// <summary>
    /// Code (3 caracteres) ISO du pays
    /// </summary>
    [StringLength(8)]
    public string code_iso3 { get; set; } = null!;

    /// <summary>
    /// Code telephonique du pays
    /// </summary>
    [StringLength(8)]
    public string phone_code { get; set; } = null!;

    /// <summary>
    /// Devise du pays
    /// </summary>
    [StringLength(128)]
    public string? devise { get; set; }

    [InverseProperty("country")]
    public virtual ICollection<core_bank> core_banks { get; set; } = new List<core_bank>();

    [InverseProperty("country")]
    public virtual ICollection<core_etablissement> core_etablissements { get; set; } = new List<core_etablissement>();

    [InverseProperty("country")]
    public virtual ICollection<core_person> core_people { get; set; } = new List<core_person>();

    [InverseProperty("country")]
    public virtual ICollection<core_phonenumber> core_phonenumbers { get; set; } = new List<core_phonenumber>();
}
