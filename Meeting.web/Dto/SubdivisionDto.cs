using MeetingEntities.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// Represente le decoupage mensuel de l&apos;annee
/// </summary>

[PrimaryKey("AnneeId", "DivisionId")]
public partial class SubdivisionDto : BaseDto<SubdivisionDto, CoreSubdivision>
{
    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Display(Name ="Année ID")]
    public int AnneeId { get; set; }

    /// <summary>
    /// Identifiant de la division
    /// </summary>
    [Display(Name = "Division ID")]
    public int DivisionId { get; set; }
    
    /// <summary>
    /// Libelle de la division
    /// </summary>
    [Display(Name = "Libelle")]
    [StringLength(128)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Date de debut de la division
    /// </summary>
    [Display(Name = "Month Date")]
    [DataType(DataType.Date)]
    public DateOnly MonthDate { get; set; }

    /// <summary>
    /// Jour du mois ou aura lieu la reunion
    /// </summary>
    [Display(Name = "Month's day")]
    public int? MonthDay { get; set; }

    /// <summary>
    /// Numero d&apos;ordre de la division
    /// </summary>
    [Display(Name = "N# Ordre")]
    public int Numordre { get; set; }

    public virtual AnneeDto Annee { get; set; } = null!;

   // public virtual ICollection<OrdrePassageDto> MeetOrdrePassages { get; set; } = new List<OrdrePassageDto>();

   // public virtual ICollection<SeanceDto> MeetSeances { get; set; } = new List<SeanceDto>();
}
