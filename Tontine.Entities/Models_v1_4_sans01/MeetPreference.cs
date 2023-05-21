using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// Meet_Preference
/// </summary>
public partial class MeetPreference
{
    /// <summary>
    /// Identifiant de l&apos;entite
    /// </summary>
    public int SettingId { get; set; }

    /// <summary>
    /// Taux d&apos;interet mensuel pour un pret
    /// </summary>
    public decimal TauxInteretMensuel { get; set; }

    /// <summary>
    /// Taux d&apos;interet applicable en cas de non respect de l&apos;echeance d&apos;un pret
    /// </summary>
    public decimal TauxInteretPenalite { get; set; }

    /// <summary>
    /// Taux d&apos;interet applicable en cas de penalite pour echec a une cotiisation
    /// </summary>
    public decimal TauxPenaliteCotisation { get; set; }

    /// <summary>
    /// Enable_auto_gen_presence
    /// </summary>
    public bool? EnableAutoGenPresence { get; set; }

    /// <summary>
    /// Enable_signing_outcome
    /// </summary>
    public bool EnableSigningOutcome { get; set; }

    /// <summary>
    /// Enable_max_delay_penalites
    /// </summary>
    public bool? EnableMaxDelayPenalites { get; set; }

    /// <summary>
    /// Enable_auto_dispatch_income
    /// </summary>
    public bool? EnableAutoDispatchIncome { get; set; }

    /// <summary>
    /// Enable_fixed_amount_fees
    /// </summary>
    public bool EnableFixedAmountFees { get; set; }

    /// <summary>
    /// Enable_Secours_insurance
    /// </summary>
    public bool EnableSecoursInsurance { get; set; }

    /// <summary>
    /// Enable_fixed_fees_by_anten
    /// </summary>
    public bool EnableFixedFeesByAnten { get; set; }

    public virtual CoreAnnualSetting Setting { get; set; } = null!;
}
