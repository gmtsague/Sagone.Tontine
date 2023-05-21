using MeetingEntities.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// Represente ue antenne de l&apos;association
/// </summary>
[PrimaryKey("EtabId", "AntenneId")]
public partial class AntenneDto : BaseDto<AntenneDto, MeetAntenne>
{
    /// <summary>
    /// Etab_id
    /// </summary>
    //[Display(Name = "Association ID")]
    public int EtabId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;antenne
    /// </summary>
    [Key]
    //[Display(Name = "Antenne ID")]
    public int AntenneId { get; set; }

    /// <summary>
    /// Libelle de l&apos;antenne
    /// </summary>
    [Display(Name = "Nom")]
    [StringLength(128)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Date de creation de l&apos;antenne
    /// </summary>
    [Display(Name = "Creation date")]
    public DateOnly? Creationdate { get; set; }

    [Display(Name = "EtabId")]
    public virtual EtablissementDto? Etab { get; set; } = null!;

    [Display(Name = "Membres inscrits")]
    public virtual ICollection<InscriptionDto> Inscriptions { get; set; } = new List<InscriptionDto>();

    //[Display(Name = "Liste séances")]
    //public virtual ICollection<SeanceDto> Seances { get; set; } = new List<SeanceDto>();
}
