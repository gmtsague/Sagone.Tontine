using MeetingEntities.Models;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// BureauDto
/// </summary>
public partial class BureauDto : BaseDto<BureauDto, MeetBureau>
{
    /// <summary>
    /// Bureau_id
    /// </summary>
    [Key]
    [Display(Name = "Bureau ID")]
    public int BureauId { get; set; }

    /// <summary>
    /// Etab_id
    /// </summary>
    [Display(Name ="Association")]
    public int? EtabId { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    [Display(Name ="Nom du bureau")]
    [StringLength(128)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Debut
    /// </summary>
    [Display(Name ="Début mandat")]
    public DateOnly Debut { get; set; }

    /// <summary>
    /// Fin
    /// </summary>
    [Display(Name ="Fin du mandat")]
    public DateOnly Fin { get; set; }

    /// <summary>
    /// Nbperson
    /// </summary>
    [Display(Name ="Nb. membres")]
    public int Nbperson { get; set; }

    /// <summary>
    /// Nbvotes
    /// </summary>
    [Display(Name ="Nb. votants")]
    public int Nbvotes { get; set; }

    /// <summary>
    /// NbAbstention
    /// </summary>
    [Display(Name = "Nb.Abstentions")]
    public int Nbabstention { get; set; }

    /// <summary>
    /// Resumevote
    /// </summary>
    [Display(Name ="Résumés des votes")]
    public string? Resumevote { get; set; }

    [Display(Name ="Années du Bureau")]
    public virtual ICollection<AnneeDto> Annees { get; set; } = new List<AnneeDto>();

    [Display(Name ="Association")]
    public virtual EtablissementDto? Etab { get; set; }

    [Display(Name ="Membres du Bureau")]
    public virtual ICollection<MembreBureauDto> MembresBureau { get; set; } = new List<MembreBureauDto>();
}
