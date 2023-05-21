using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Meet_Preference
/// </summary>
[Table("meet_preference", Schema = "tontine_v14")]
[Index("SettingId", Name = "meet_preference_pk", IsUnique = true)]
public partial class MeetPreference
{
    /// <summary>
    /// Identifiant de l&apos;entite
    /// </summary>
    [Key]
    [Column("setting_id")]
    public int SettingId { get; set; }

    /// <summary>
    /// Taux d&apos;interet mensuel pour un pret
    /// </summary>
    [Column("taux_interet_mensuel")]
    public decimal TauxInteretMensuel { get; set; }

    /// <summary>
    /// Taux d&apos;interet applicable en cas de non respect de l&apos;echeance d&apos;un pret
    /// </summary>
    [Column("taux_interet_penalite")]
    public decimal TauxInteretPenalite { get; set; }

    /// <summary>
    /// Taux d&apos;interet applicable en cas de penalite pour echec a une cotiisation
    /// </summary>
    [Column("taux_penalite_cotisation")]
    public decimal TauxPenaliteCotisation { get; set; }

    /// <summary>
    /// Enable_auto_gen_presence
    /// </summary>
    [Required]
    [Column("enable_auto_gen_presence")]
    public bool? EnableAutoGenPresence { get; set; }

    /// <summary>
    /// Enable_signing_outcome
    /// </summary>
    [Column("enable_signing_outcome")]
    public bool EnableSigningOutcome { get; set; }

    /// <summary>
    /// Enable_max_delay_penalites
    /// </summary>
    [Required]
    [Column("enable_max_delay_penalites")]
    public bool? EnableMaxDelayPenalites { get; set; }

    /// <summary>
    /// Enable_auto_dispatch_income
    /// </summary>
    [Required]
    [Column("enable_auto_dispatch_income")]
    public bool? EnableAutoDispatchIncome { get; set; }

    /// <summary>
    /// Enable_fixed_amount_fees
    /// </summary>
    [Column("enable_fixed_amount_fees")]
    public bool EnableFixedAmountFees { get; set; }

    /// <summary>
    /// Enable_Secours_insurance
    /// </summary>
    [Column("enable_secours_insurance")]
    public bool EnableSecoursInsurance { get; set; }

    /// <summary>
    /// Enable_fixed_fees_by_anten
    /// </summary>
    [Column("enable_fixed_fees_by_anten")]
    public bool EnableFixedFeesByAnten { get; set; }

    [ForeignKey("SettingId")]
    [InverseProperty("MeetPreference")]
    public virtual CoreAnnualSetting Setting { get; set; } = null!;
}
