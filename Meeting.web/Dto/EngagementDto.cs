using MeetingEntities.Models;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// Mode de paiement utilise par un membre
/// </summary>

public partial class EngagementDto : BaseDto<EngagementDto, MeetEngagement>
{
    /// <summary>
    /// Engagement_id
    /// </summary>
    [Key]
    [Display( Name="engagement_id")]
    public int EngagementId { get; set; }

    /// <summary>
    /// Identifiant d&apos;une configuration
    /// </summary>
    [Display( Name="rubrique_id")]
    public int RubriqueId { get; set; }

    /// <summary>
    /// Person_id
    /// </summary>
    [Display( Name="person_id")]
    public int PersonId { get; set; }

    /// <summary>
    /// Indique si le type represente une sortie de caisse
    /// </summary>
    [Display( Name="is_outcome")]
    public bool IsOutcome { get; set; }

    /// <summary>
    /// Indique que l&apos;evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)
    /// </summary>
    [Display( Name="is_closed")]
    public bool IsClosed { get; set; }

    /// <summary>
    /// Engagement_Date
    /// </summary>
    [Display( Name="engagement_date")]
    public DateOnly? EngagementDate { get; set; }

    /// <summary>
    /// Cumul des versements sur une rubrique
    /// </summary>
    [Display(Name = "cumulverse")]
    public decimal Cumulverse { get; set; }

    /// <summary>
    /// Solde
    /// </summary>
    [Display(Name = "solde")]
    public decimal Solde { get { return (Cumulverse - ToPay); } }

    /// <summary>
    /// Montant total a payer au cours d'un exercice
    /// </summary>
    [Display(Name = "to_pay")]
    public decimal ToPay { get; set; }

    /// <summary>
    /// Montant personnalise a cotiser a chaque periode
    /// </summary>
    [Display(Name = "custom_amount")]
    public decimal CustomAmount { get; set; }

    /// <summary>
    /// Nombre de seances/versements requis pour solder l'engagement.
    /// </summary>
    [Display(Name = "nb_req_seances")]
    public int NbReqSeances { get; set; }

    /// <summary>
    /// Indique que l&apos;evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)
    /// </summary>
    [Display(Name = "IsDeduction")]
    public bool IsDeduction { get; set; }

    /// <summary>
    /// Indique que l&apos;evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)
    /// </summary>
    [Display(Name = "IsExempt")]
    public bool IsExempt { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>    
    [Display(Name = "Libelle")]
    public string? Libelle { get { return $"{Rubrique?.Libelle}-({Person?.FullName})"; } }

    public virtual ICollection<EntreeCaisseDto> EntreeCaisses { get; set; } = new List<EntreeCaisseDto>();

    public virtual ICollection<SortieCaisseDto> SortieCaisses { get; set; } = new List<SortieCaisseDto>();

    public virtual PersonDto Person { get; set; } = null!;

    public virtual RubriqueDto Rubrique { get; set; } = null!;
}
