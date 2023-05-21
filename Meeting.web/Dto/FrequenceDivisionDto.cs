using MeetingEntities.Models;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// FrequenceDivisionDto
/// </summary>

public partial class FrequenceDivisionDto : BaseDto<FrequenceDivisionDto, CoreFrequenceDivision>
{
    /// <summary>
    /// Frequence_id
    /// </summary>
    [Key]
    [Display(Name ="Frequence ID")]
    public int FrequenceId { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    [Display(Name ="Libelle")]
    [StringLength(128)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Nb_Days
    /// </summary>
    [Display(Name ="Nb.jours")]
    public int NbDays { get; set; }

    //[InverseProperty("Frequence")]
    //public virtual ICollection<CoreAnnee> CoreAnnees { get; set; } = new List<CoreAnnee>();
}
