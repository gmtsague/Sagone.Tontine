using MeetingEntities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// PreferenceDto
/// </summary>
public partial class PreferenceDto: BaseDto<PreferenceDto, MeetPreference>
{
    /// <summary>
    /// Identifiant de l&apos;entite
    /// </summary>
    [Key]
    public int SettingId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Display(Name ="Année")]
    public int AnneeId { get; set; }
    public virtual AnneeDto Annee { get; set; } = null!;

    /// <summary>
    /// Etab_id
    /// </summary>
    [Display(Name ="Association")]
    public int EtabId { get; set; }
    //public virtual EtablissementDto Etab { get; set; } = null!;

    /// <summary>
    /// Nombre max de liens autorises pour la photo d&apos;une personne
    /// </summary>
    [Display(Name = "Nombre maximale de références autorisées pour une image (photo)")]
    public int MaxAllowPhotoLiens { get; set; }

     /// <summary>
    /// Taux d&apos;interet mensuel pour un pret
    /// </summary>
    [Display(ShortName = "% intérêt (prêt)", Name ="Taux d'interet (prêt)", Description = "Taux d'intérêt mensuel pour un prêt")]
    public decimal TauxInteretMensuel { get; set; }

    /// <summary>
    /// Taux d&apos;interet applicable en cas de non respect de l&apos;echeance d&apos;un pret
    /// </summary>
    [Display(ShortName = "% intérêt (penalité)", Name ="Taux d'interet (penalite)", Description ="Taux d'intérêt mensuel appliqué comme pénalité en cas de non respect du délai de remboursement d'un prêt")]
    public decimal TauxInteretPenalite { get; set; }

    /// <summary>
    /// Taux d&apos;interet applicable en cas de penalite pour echec a une cotiisation
    /// </summary>
    [Display(ShortName = "% pénalité (cotisation)", Name ="Taux pénalite (cotisation)", Description = "Taux de pénalité pour un échec de cotisation")]
    public decimal TauxPenaliteCotisation { get; set; }

    /// <summary>
    /// Enable_auto_gen_presence
    /// </summary>
    [Required]
    [Display(Name ="Activer la génération automatique des présences mensuelles")]
    public bool? EnableAutoGenPresence { get; set; }

    /// <summary>
    /// Enable_signing_outcome
    /// </summary>
    [Required]
    [Display(Name ="Activer la signature obligatoire pour chaque opération de sortie de caisse")]
    public bool EnableSigningOutcome { get; set; }

    /// <summary>
    /// Enable_max_delay_penalites
    /// </summary>
    [Required]
    [Display(Name = "Utiliser un taux fixe sur une période de 03 mois en cas d'échec de remboursement d'un prêt")]
    public bool? EnableMaxDelayPenalites { get; set; }

    /// <summary>
    /// Enable_auto_dispatch_income
    /// </summary>
    [Required]
    [Display(Name = "Activer la répartition automatique d'une entrée de caisse sur les rubriques en créance")]
    public bool? EnableAutoDispatchIncome { get; set; }

    /// <summary>
    /// Enable_fixed_amount_fees
    /// </summary>
    [Display(Name = "Activer un taux de cotisation unique pour tous les membres")]
    public bool EnableFixedAmountFees { get; set; }

    /// <summary>
    /// Enable_Secours_insurance
    /// </summary>
    [Display(Name ="Activer la prise en charge du secours")]
    public bool EnableSecoursInsurance { get; set; }

    /// <summary>
    /// Enable_fixed_fees_by_anten
    /// </summary>
    [Display(Name = "Activer un taux de cotisation unique pour toutes les antenes")]
    public bool EnableFixedFeesByAnten { get; set; }

}
