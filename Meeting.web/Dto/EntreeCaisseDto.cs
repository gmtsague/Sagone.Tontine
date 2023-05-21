using MeetingEntities.Models;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;
/// <summary>
/// Meet_Entree_caisse
/// </summary>

public partial class EntreeCaisseDto : BaseDto<EntreeCaisseDto, MeetEntreeCaisse>
{
    /// <summary>
    /// Operation_id
    /// </summary>
    [Key]
    [Display(Name="operation_id")]
    public int OperationId { get; set; }

    /// <summary>
    /// Identiifant de la signature
    /// </summary>
    [Display(Name="presence_id")]
    public int PresenceId { get; set; }

    /// <summary>
    /// Engagement_id
    /// </summary>
    [Display(Name="engagement_id")]
    public int? EngagementId { get; set; }

    /// <summary>
    /// Identifiant du mode de paiement
    /// </summary>
    [Display(Name="modepaie_id")]
    public int? ModepaieId { get; set; }

    /// <summary>
    /// MontantVerse
    /// </summary>
    [Display(Name="montantverse")]
    public decimal Montantverse { get; set; }

    /// <summary>
    /// Indique si le type represente une sortie de caisse
    /// </summary>
    [Display(Name="is_outcome")]
    public bool IsOutcome { get; set; }

    [Display(Name = "Engagement")]
    public virtual EngagementDto? Engagement { get; set; }

    //[Display(Name = "Mode paie")]
    //public virtual ModepaieDto? Modepaie { get; set; } 

    [Display(Name = "Presence")]

    public virtual PresenceDto? Presence { get; set; } 
}
