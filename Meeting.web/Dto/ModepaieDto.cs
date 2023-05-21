using MeetingEntities.Models;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// Mode de paiement utilise par un membre
/// </summary>

public partial class ModepaieDto : BaseDto<ModepaieDto, CoreModepaie>
{
    /// <summary>
    /// Identifiant du mode de paiement
    /// </summary>
    [Key]
    [Display(Name = "ID")]
    public int ModepaieId { get; set; }

    /// <summary>
    /// Libelle du mode de paiement
    /// </summary>
    [Display(Name = "libelle")]
    [StringLength(128)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Indique si le mode represnte le CASH
    /// </summary>
    [Display(Name = "Is cash?")]
    public bool IsCash { get; set; }

    //[Display(Name = "Liste opérations")]
    //public virtual ICollection<EntreeCaisseDto> EntreeCaisses { get; set; } = new List<EntreeCaisseDto>();
}
