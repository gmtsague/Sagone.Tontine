using Mapster;
using MeetingEntities.Models;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// Mode de paiement utilise par un membre
/// </summary>

public partial class OrdrePassageDto : BaseDto<OrdrePassageDto, MeetOrdrePassage>
{
    /// <summary>
    /// passage_id
    /// </summary>
    [Key]
    [Display( Name="passage_id")]
    public int PassageId { get; set; }

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
    /// Identifiant de l&apos;inscription
    /// </summary>
    [Display( Name="idinscrit")]
    public int Idinscrit { get; set; }

    /// <summary>
    /// MontantPercu
    /// </summary>
    [Display( Name="montantpercu")]
    public decimal Montantpercu { get; set; }

    /// <summary>
    /// HeureDebut
    /// </summary>
    [Display( Name="heuredebut")]
    public DateOnly? Heuredebut { get; set; }

    /// <summary>
    /// Commentaire
    /// </summary>
    [Display( Name="commentaire")]
    public string? Commentaire { get; set; }

    //[ForeignKey("AnneeId, DivisionId")]
    //[InverseProperty("MeetOrdrePassages")]
    public virtual SubdivisionDto? Subdivision { get; set; } = null!;

    //[ForeignKey("Idinscrit")]
    //[InverseProperty("MeetOrdrePassages")]
    public virtual InscriptionDto? Inscription { get; set; } = null!;

    public override void AddCustomMappings()
    {
        //SetCustomMappings()
        //    .Map(dest => dest.full, src => src.Dateop)
        //    .Map(dest => dest.Userid, src => src.UserId);

        SetCustomMappingsInverse()
            .Map(dest => dest.Inscription, src => src.IdinscritNavigation.Adapt<InscriptionDto>())
            .Map(dest => dest.Subdivision, src => src.CoreSubdivision.Adapt<SubdivisionDto>());
    }
}
