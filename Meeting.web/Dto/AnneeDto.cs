using MeetingEntities.Models;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// Represente une annee 
/// </summary>
public partial class AnneeDto : BaseDto<AnneeDto, CoreAnnee>
{
    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Key]
    [Display(Name = "Année ID")]
    public int AnneeId { get; set; }

    /// <summary>
    /// Frequence_id
    /// </summary>
    [Display(Name = "Frequence ID")]
    public int FrequenceId { get; set; }

    /// <summary>
    /// Bureau_id
    /// </summary>
    [Display(Name = "Bureau ID")]
    public int? BureauId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Display(Name = "Année référence")]
    public int? PreviousYearId { get; set; }

    /// <summary>
    /// Libelle de l&apos;annee
    /// </summary>
    [Display(Name = "Libelle")]
    [StringLength(128)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Date de debut de l&apos;annee
    /// </summary>
    [Display(Name = "Date début", ShortName ="Début")]
    [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode =true)]
    [DataType(DataType.Date)]
    public DateOnly Datedebut { get; set; }

    /// <summary>
    /// Date de fin de l&apos;annee
    /// </summary>
    [Display(Name = "Date fin", ShortName ="Fin")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateOnly Datefin { get; set; }

    /// <summary>
    /// Indique l&apos;annee de travail
    /// </summary>
    [Display(Name = "En cours")]
    public bool IsCurrent { get; set; }

    /// <summary>
    /// Indique que l&apos;annee et cloturee et ses donnees ne sont plus modifiables
    /// </summary>
    [Display(Name = "Est clôturé?", ShortName ="Locked ?")]
    public bool IsClosed { get; set; }

    /// <summary>
    /// Nombre de divisions de l&apos;annee
    /// </summary>
    [Display(Name = "Nb.Divisions")]    
    public int Nbdivision { get; set; }

    /// <summary>
    /// Copy_data_from_previous
    /// </summary>
    [Display(Name = "Data from previous year", ShortName ="Données répliquées")]
    public bool CopyDataFromPrevious { get; set; }

    [Display(Name = "Bureau")]
    public virtual BureauDto? Bureau { get; set; }

   // [Display(Name = "Annee")]
   //.02 public virtual ICollection<CoreAnnualSetting> CoreAnnualSettings { get; set; } = new List<CoreAnnualSetting>();

    [Display(Name = "Périodes")]
    public virtual ICollection<SubdivisionDto> Subdivisions { get; set; } = new List<SubdivisionDto>();

   // [Display(Name = "Frequence")]
   // public virtual FrequenceDivisionDto Frequence { get; set; } = null!;

    [Display(Name = "Liste Config.Visas")]
    public virtual ICollection<ConfigvisaDto> ConfigVisas { get; set; } = new List<ConfigvisaDto>();

    [Display(Name = "Liste Inscriptions")]
    public virtual ICollection<InscriptionDto> Inscriptions { get; set; } = new List<InscriptionDto>();

  //  [Display(Name = "Annee")]
  //  public virtual ICollection<MeetMaxAllowSignature> MeetMaxAllowSignatures { get; set; } = new List<MeetMaxAllowSignature>();

    [Display(Name = "Liste Rubriques")]
    public virtual ICollection<RubriqueDto> Rubriques { get; set; } = new List<RubriqueDto>();

    [Display(Name = "Previous Year")]
    public virtual AnneeDto? PreviousYear { get; set; }
}
