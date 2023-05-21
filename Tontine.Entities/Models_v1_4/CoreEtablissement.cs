using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4;

/// <summary>
/// core_Etablissement
/// </summary>
[Table("core_etablissement", Schema = "tontine_v14")]
[Index("CountryId", Name = "association_42_fk")]
[Index("EtabId", Name = "core_etablissement_pk", IsUnique = true)]
[Index("DeployedUrl", Name = "uniq_deployed_url", IsUnique = true)]
public partial class CoreEtablissement
{
    /// <summary>
    /// Etab_id
    /// </summary>
    [Key]
    [Column("etab_id")]
    public int EtabId { get; set; }

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
    public long? CountryId { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    [Column("libelle")]
    [StringLength(256)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Adresse
    /// </summary>
    [Column("adresse")]
    [StringLength(1024)]
    public string? Adresse { get; set; }

    /// <summary>
    /// Creationdate
    /// </summary>
    [Column("creationdate")]
    public DateOnly? Creationdate { get; set; }

    /// <summary>
    /// Deployed_Url
    /// </summary>
    [Column("deployed_url")]
    [StringLength(1024)]
    public string DeployedUrl { get; set; } = null!;

    /// <summary>
    /// Database_name
    /// </summary>
    [Column("database_name")]
    [StringLength(1024)]
    public string? DatabaseName { get; set; }

    /// <summary>
    /// Conn_string
    /// </summary>
    [Column("conn_string")]
    [StringLength(1024)]
    public string? ConnString { get; set; }

    /// <summary>
    /// Enable_multi_antenne
    /// </summary>
    [Column("enable_multi_antenne")]
    public bool EnableMultiAntenne { get; set; }

    [InverseProperty("Etab")]
    public virtual ICollection<CoreAnnualSetting> CoreAnnualSettings { get; set; } = new List<CoreAnnualSetting>();

    [InverseProperty("Etab")]
    public virtual ICollection<CoreBankaccount> CoreBankaccounts { get; set; } = new List<CoreBankaccount>();

    [InverseProperty("Etab")]
    public virtual ICollection<CorePerson> CorePeople { get; set; } = new List<CorePerson>();

    [InverseProperty("Etab")]
    public virtual ICollection<CorePhoto> CorePhotos { get; set; } = new List<CorePhoto>();

    [ForeignKey("CountryId")]
    [InverseProperty("CoreEtablissements")]
    public virtual CoreCountry? Country { get; set; }

    [InverseProperty("Etab")]
    public virtual ICollection<MeetAntenne> MeetAntennes { get; set; } = new List<MeetAntenne>();

    [InverseProperty("Etab")]
    public virtual ICollection<MeetBureau> MeetBureaus { get; set; } = new List<MeetBureau>();
}
