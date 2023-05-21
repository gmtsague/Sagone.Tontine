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
[Index("setting_id", Name = "meet_preference_pk", IsUnique = true)]
public partial class meet_preference
{
    /// <summary>
    /// Identifiant de l&apos;entite
    /// </summary>
    [Key]
    public int setting_id { get; set; }

    /// <summary>
    /// Taux d&apos;interet mensuel pour un pret
    /// </summary>
    public decimal taux_interet_mensuel { get; set; }

    /// <summary>
    /// Taux d&apos;interet applicable en cas de non respect de l&apos;echeance d&apos;un pret
    /// </summary>
    public decimal taux_interet_penalite { get; set; }

    /// <summary>
    /// Taux d&apos;interet applicable en cas de penalite pour echec a une cotiisation
    /// </summary>
    public decimal taux_penalite_cotisation { get; set; }

    /// <summary>
    /// Enable_auto_gen_presence
    /// </summary>
    [Required]
    public bool? enable_auto_gen_presence { get; set; }

    /// <summary>
    /// Enable_signing_outcome
    /// </summary>
    public bool enable_signing_outcome { get; set; }

    /// <summary>
    /// Enable_max_delay_penalites
    /// </summary>
    [Required]
    public bool? enable_max_delay_penalites { get; set; }

    /// <summary>
    /// Enable_auto_dispatch_income
    /// </summary>
    [Required]
    public bool? enable_auto_dispatch_income { get; set; }

    /// <summary>
    /// Enable_fixed_amount_fees
    /// </summary>
    public bool enable_fixed_amount_fees { get; set; }

    /// <summary>
    /// Enable_Secours_insurance
    /// </summary>
    public bool enable_secours_insurance { get; set; }

    /// <summary>
    /// Enable_fixed_fees_by_anten
    /// </summary>
    public bool enable_fixed_fees_by_anten { get; set; }

    [ForeignKey("setting_id")]
    [InverseProperty("meet_preference")]
    public virtual core_annual_setting setting { get; set; } = null!;
}
