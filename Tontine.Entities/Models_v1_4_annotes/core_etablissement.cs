using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// core_Etablissement
/// </summary>
[Table("core_etablissement", Schema = "tontine_v14")]
[Index("country_id", Name = "association_42_fk")]
[Index("etab_id", Name = "core_etablissement_pk", IsUnique = true)]
[Index("deployed_url", Name = "uniq_deployed_url", IsUnique = true)]
public partial class core_etablissement
{
    /// <summary>
    /// Etab_id
    /// </summary>
    [Key]
    public int etab_id { get; set; }

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
    /// Libelle
    /// </summary>
    [StringLength(256)]
    public string libelle { get; set; } = null!;

    /// <summary>
    /// Adresse
    /// </summary>
    [StringLength(1024)]
    public string? adresse { get; set; }

    /// <summary>
    /// Creationdate
    /// </summary>
    public DateOnly? creationdate { get; set; }

    /// <summary>
    /// Deployed_Url
    /// </summary>
    [StringLength(1024)]
    public string deployed_url { get; set; } = null!;

    /// <summary>
    /// Database_name
    /// </summary>
    [StringLength(1024)]
    public string? database_name { get; set; }

    /// <summary>
    /// Conn_string
    /// </summary>
    [StringLength(1024)]
    public string? conn_string { get; set; }

    /// <summary>
    /// Enable_multi_antenne
    /// </summary>
    public bool enable_multi_antenne { get; set; }

    [InverseProperty("etab")]
    public virtual ICollection<core_annual_setting> core_annual_settings { get; set; } = new List<core_annual_setting>();

    [InverseProperty("etab")]
    public virtual ICollection<core_bankaccount> core_bankaccounts { get; set; } = new List<core_bankaccount>();

    [InverseProperty("etab")]
    public virtual ICollection<core_person> core_people { get; set; } = new List<core_person>();

    [InverseProperty("etab")]
    public virtual ICollection<core_photo> core_photos { get; set; } = new List<core_photo>();

    [ForeignKey("country_id")]
    [InverseProperty("core_etablissements")]
    public virtual core_country? country { get; set; }

    [InverseProperty("etab")]
    public virtual ICollection<meet_antenne> meet_antennes { get; set; } = new List<meet_antenne>();

    [InverseProperty("etab")]
    public virtual ICollection<meet_bureau> meet_bureaus { get; set; } = new List<meet_bureau>();
}
