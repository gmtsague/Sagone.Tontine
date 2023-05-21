using MeetingEntities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// Represente la personnalisation de certaines valeurs appliquees aux types d&apos;eveneents au cours d&apos;une annee
/// </summary>

public partial class RubriqueDto : BaseDto<RubriqueDto, MeetRubrique>
{
    /// <summary>
    /// Identifiant d&apos;une configuration
    /// </summary>
    [Key]
    [Display(Name = "ID Rubrique")]
    public int RubriqueId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Display(Name = "Année")]
    public int AnneeId { get; set; }

    /// <summary>
    /// Identifiant du type d&apos;evenement
    /// </summary>
    [Display(Name = "Type rubrique")]
    public int TyperubId { get; set; }

    /// <summary>
    /// Description de la rubrique (evenement)
    /// </summary>
    [Display(Name = "Nom")]
    [StringLength(128)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Nombre de membres representant l&apos;asociation a l&apos;evenement
    /// </summary>
    [Display(Name = "Nb mandataires")]
    public int Nbmandataire { get; set; }

    /// <summary>
    /// Montant du deplacement d&apos;un membre mandate par l&apos;association
    /// </summary>
    [Display(Name = "Montant Route")]
    public decimal Montantroute { get; set; }

    /// <summary>
    /// Montant total associe a l&apos;evenement
    /// </summary>
    [Display(Name = "Montant/membre")]
    public decimal MontantPerson { get; set; }

    /// <summary>
    /// Indique si le type represente une sortie de caisse
    /// </summary>
    [Display(Name = "Est une dépense?")]
    public bool IsOutcome { get; set; }

    /// <summary>
    /// Commentaire
    /// </summary>
    [Display(Name = "Observations")]
    public string? Commentaire { get; set; }

    /// <summary>
    /// Defini l&apos;ordre dans lequel les rubriques de ce type peuevnt beneficier d&apos;une repartition automatique du montant verse par un membre d&apos;une reunion
    /// </summary>
    [Display(Name = "N# Ordre", Description = "Numéro affecté aux rubriques de ce type. Cette valeur est utile lors de la répartition automatique des finances d'un membre.")]
    public int Numordre { get; set; }

    /// <summary>
    /// Une rubrique de cette categorie doit faire l'objet d''un versement du montant total defini a chaque periode (mois, semaine, etc) d'un exercice.
    /// </summary>
    [Display(Name = "topay_each_periode")]
    public bool TopayEachPeriode { get; set; }

    /// <summary>
    /// Autoriser un membre a definir un montant a cotiser different de celui defini par defaut
    /// </summary>
    [Display(Name = "allow_custom_amount")]
    public bool AllowCustomAmount { get; set; }

    [Display(Name = "Année")]
    public virtual AnneeDto? Annee { get; set; } = null!;

    //[Display(Name = "Liste Rubriques")]
    //public virtual ICollection<EngagementDto> Engagements { get; set; } = new List<EngagementDto>();

    [Display(Name = "Catégorie")]
    public virtual TypeRubriqueDto? Typerub { get; set; } = null!;
}
