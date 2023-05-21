using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// core_Etablissement
/// </summary>
public partial class CoreEtablissement
{
    /// <summary>
    /// Etab_id
    /// </summary>
    public int EtabId { get; set; }

    /// <summary>
    /// create_uid
    /// </summary>
    public long? CreateUid { get; set; }

    /// <summary>
    /// update_uid
    /// </summary>
    public long? UpdateUid { get; set; }

    /// <summary>
    /// Create_at
    /// </summary>
    public DateTime CreateAt { get; set; }

    /// <summary>
    /// Update_at
    /// </summary>
    public DateTime UpdateAt { get; set; }

    /// <summary>
    /// Identifiant du pays
    /// </summary>
    public long? CountryId { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Adresse
    /// </summary>
    public string? Adresse { get; set; }

    /// <summary>
    /// Creationdate
    /// </summary>
    public DateOnly? Creationdate { get; set; }

    /// <summary>
    /// Deployed_Url
    /// </summary>
    public string DeployedUrl { get; set; } = null!;

    /// <summary>
    /// Database_name
    /// </summary>
    public string? DatabaseName { get; set; }

    /// <summary>
    /// Conn_string
    /// </summary>
    public string? ConnString { get; set; }

    /// <summary>
    /// Enable_multi_antenne
    /// </summary>
    public bool EnableMultiAntenne { get; set; }

    public virtual ICollection<CoreAnnualSetting> CoreAnnualSettings { get; set; } = new List<CoreAnnualSetting>();

    public virtual ICollection<CoreBankaccount> CoreBankaccounts { get; set; } = new List<CoreBankaccount>();

    public virtual ICollection<CorePerson> CorePeople { get; set; } = new List<CorePerson>();

    public virtual ICollection<CorePhoto> CorePhotos { get; set; } = new List<CorePhoto>();

    public virtual CoreCountry? Country { get; set; }

    public virtual ICollection<MeetAntenne> MeetAntennes { get; set; } = new List<MeetAntenne>();

    public virtual ICollection<MeetBureau> MeetBureaus { get; set; } = new List<MeetBureau>();
}
