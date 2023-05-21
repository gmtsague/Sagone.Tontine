using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans;

/// <summary>
/// core_Annual_setting
/// </summary>
public partial class CoreAnnualSetting
{
    /// <summary>
    /// Identifiant de l&apos;entite
    /// </summary>
    public int SettingId { get; set; }

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
    /// Identifiant de l&apos;annee
    /// </summary>
    public int AnneeId { get; set; }

    /// <summary>
    /// Etab_id
    /// </summary>
    public int EtabId { get; set; }

    /// <summary>
    /// Nombre max de liens autorises pour la photo d&apos;une personne
    /// </summary>
    public int MaxAllowPhotoLiens { get; set; }

    /// <summary>
    /// CopyEngagements
    /// </summary>
    public bool Copyengagements { get; set; }

    /// <summary>
    /// CopyMembers
    /// </summary>
    public bool Copymembers { get; set; }

    public virtual CoreAnnee Annee { get; set; } = null!;

    public virtual CoreEtablissement Etab { get; set; } = null!;

    public virtual MeetPreference? MeetPreference { get; set; }
}
