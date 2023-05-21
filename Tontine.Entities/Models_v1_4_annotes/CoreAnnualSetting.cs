using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// core_Annual_setting
/// </summary>
[Table("core_annual_setting", Schema = "tontine_v14")]
[Index("EtabId", Name = "association_40_fk")]
[Index("AnneeId", Name = "association_41_fk")]
[Index("SettingId", Name = "core_annual_setting_pk", IsUnique = true)]
public partial class CoreAnnualSetting
{
    /// <summary>
    /// Identifiant de l&apos;entite
    /// </summary>
    [Key]
    [Column("setting_id")]
    public int SettingId { get; set; }

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
    /// Identifiant de l&apos;annee
    /// </summary>
    [Column("annee_id")]
    public int AnneeId { get; set; }

    /// <summary>
    /// Etab_id
    /// </summary>
    [Column("etab_id")]
    public int EtabId { get; set; }

    /// <summary>
    /// Nombre max de liens autorises pour la photo d&apos;une personne
    /// </summary>
    [Column("max_allow_photo_liens")]
    public int MaxAllowPhotoLiens { get; set; }

    /// <summary>
    /// CopyEngagements
    /// </summary>
    [Column("copyengagements")]
    public bool Copyengagements { get; set; }

    /// <summary>
    /// CopyMembers
    /// </summary>
    [Column("copymembers")]
    public bool Copymembers { get; set; }

    [ForeignKey("AnneeId")]
    [InverseProperty("CoreAnnualSettings")]
    public virtual CoreAnnee Annee { get; set; } = null!;

    [ForeignKey("EtabId")]
    [InverseProperty("CoreAnnualSettings")]
    public virtual CoreEtablissement Etab { get; set; } = null!;

    [InverseProperty("Setting")]
    public virtual MeetPreference? MeetPreference { get; set; }
}
