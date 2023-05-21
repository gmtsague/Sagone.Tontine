using MeetingEntities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// Poste occupe par un membre de l&apos;association
/// </summary>

public partial class PosteDto : BaseDto<PosteDto, MeetPoste>
{
    /// <summary>
    /// Poste_id
    /// </summary>
    [Key]
    [Display(Name ="ID Poste")]
    public int PosteId { get; set; }
        
    /// <summary>
    /// Libelle
    /// </summary>
    [Display(Name ="libelle"/*, TypeName = "jsonb"*/)]
    [Required]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Les valeurs autorisees sont: {PRESIDENT, TRESORIER, SG, SGA, CC, CENSOR, MEMBER}
    /// </summary>
    [Display(Name ="Code")]
    [StringLength(64)]
    [Required]
    public string Code { get; set; } = null!;

    [Display(Name ="Liste config. visas")]
    public virtual ICollection<ConfigvisaDto> ConfigVisas { get; set; } = new List<ConfigvisaDto>();

    //[Display("Poste")]
    //public virtual ICollection<MembreBureauDto> MeetMembreBureaus { get; set; } = new List<MembreBureauDto>();
}
