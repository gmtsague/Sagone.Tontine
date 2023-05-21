using MeetingEntities.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// MembreBureauDto
/// </summary>
public partial class MembreBureauDto : BaseDto<MembreBureauDto, MeetMembreBureau>
{
    /// <summary>
    /// bureaudetails_id
    /// </summary>
    [Key]
    public int BureaudetailsId { get; set; }

     /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    [Display(Name ="Membre")]
    public int Idinscrit { get; set; }

    /// <summary>
    /// Poste_id
    /// </summary>
    [Display(Name ="Poste")]
    public int PosteId { get; set; }

    /// <summary>
    /// Bureau_id
    /// </summary>
    [Display(Name ="Bureau")]
    public int BureauId { get; set; }

    public virtual BureauDto Bureau { get; set; } = null!;
    
    public virtual PosteDto Poste { get; set; } = null!;

    public virtual InscriptionDto Membre { get; set; } = null!;

}
