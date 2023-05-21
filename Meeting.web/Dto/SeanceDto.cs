using MeetingEntities.Models;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// Mode de paiement utilise par un membre
/// </summary>

public partial class SeanceDto : BaseDto<SeanceDto, MeetSeance>
{
    /// <summary>
    /// Seance_id
    /// </summary>
    [Key]
    [Display( Name="seance_id")]
    public int SeanceId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Display( Name="annee_id")]
    public int AnneeId { get; set; }

    /// <summary>
    /// Identifiant de la division
    /// </summary>
    [Display( Name="division_id")]
    public int DivisionId { get; set; }

    /// <summary>
    /// Etab_id
    /// </summary>
    [Display( Name="etab_id")]
    public int? EtabId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;antenne
    /// </summary>
    [Display( Name="antenne_id")]
    public int? AntenneId { get; set; }

    /// <summary>
    /// Date et heure d&apos;ouverture de la reunion
    /// </summary>
    [Display( Name="opendate")]
    public DateTime? Opendate { get; set; }

    /// <summary>
    /// Date et heure de fermeture de la reunion
    /// </summary>
    [Display( Name="closedate")]
    public DateTime? Closedate { get; set; }

    /// <summary>
    /// Total_entrees
    /// </summary>
    [Display( Name="total_entrees")]
    public decimal TotalEntrees { get; set; }

    /// <summary>
    /// Total_Sorties
    /// </summary>
    [Display( Name="total_sorties")]
    public decimal TotalSorties { get; set; }

    /// <summary>
    /// DepenseCollation
    /// </summary>
    [Display( Name="depensecollation")]
    public decimal Depensecollation { get; set; }

    /// <summary>
    /// Compte rendu de la seance de reunion
    /// </summary>
    [Display( Name="compterendu")]
    public string? Compterendu { get; set; }

    /// <summary>
    /// Le statut {CLOSED} indique que la reunion est cloturee et ses donnees ne sont plus modifiables
    /// </summary>
    [Display( Name="status")]
    public int? Status { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>    
    /// [Display(Name = "Libelle")]
    public string? Libelle { get { return $"{Subdivision?.Libelle}-({Antenne?.Libelle})"; } }

    //[ForeignKey("AnneeId, DivisionId")]
    //[InverseProperty("MeetSeances")]
    public virtual SubdivisionDto? Subdivision { get; set; } = null!;

    //[ForeignKey("EtabId, AntenneId")]
    //[InverseProperty("MeetSeances")]
    public virtual AntenneDto? Antenne { get; set; }

    //[InverseProperty("Seance")]
    public virtual ICollection<PresenceDto> Presences { get; set; } = new List<PresenceDto>();

   // [InverseProperty("Seance")]
   // public virtual ICollection<MeetPret> Prets { get; set; } = new List<MeetPret>();

    //[InverseProperty("Seance")]
    public virtual ICollection<SortieCaisseDto> SortieCaisses { get; set; } = new List<SortieCaisseDto>();

    public override void AddCustomMappings()
    {
        //SetCustomMappings()
        //    .Map(dest => dest.full, src => src.Dateop)
        //    .Map(dest => dest.Userid, src => src.UserId);

        SetCustomMappingsInverse()
            .Map(dest => dest.Subdivision, src => SubdivisionDto.FromEntity(src.CoreSubdivision))
            .Map(dest => dest.Antenne, src => AntenneDto.FromEntity(src.MeetAntenne));
    }
}
