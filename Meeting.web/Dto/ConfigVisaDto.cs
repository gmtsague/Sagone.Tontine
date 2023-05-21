using MeetingEntities.Models;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// Represente l&apos;ensemble des autorisatios de signature de documents au sein de l&apos;association
/// </summary>

public partial class ConfigvisaDto : BaseDto<ConfigvisaDto, MeetConfigVisa>
{
    /// <summary>
    /// Identifiant de la configuration de signature
    /// </summary>
    [Key]
    [Display(Name = "ID")]
    public int ConfigvisaId { get; set; }

    /// <summary>
    /// Poste_id
    /// </summary>
    [Display(Name = "Poste")]
    public int PosteId { get; set; }

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
    /// Numero d&apos;ordre de la signature pour un type de document
    /// </summary>
    [Display(Name = "N# Ordre", Description = " Numéro d'ordre de la signature du détenteur d'un poste donné pour un type de document")]
    public int Numordre { get; set; }

    /// <summary>
    /// Sign_by_ordre
    /// </summary>
    [Display(Name = "Signer par ordre")]
    public bool SignByOrdre { get; set; }

    [Display(Name = "AnneeId")]
    public virtual AnneeDto? Annee { get; set; } = null!;

   // [Display(Name = "Configvisa")]
   // public virtual ICollection<MeetVisa> MeetVisas { get; set; } = new List<MeetVisa>();

    [Display(Name = "PosteId")]
    public virtual PosteDto? Poste { get; set; } = null!;

    [Display(Name = "TyperubId")]
    public virtual TypeRubriqueDto? Typerub { get; set; } = null!;
}
