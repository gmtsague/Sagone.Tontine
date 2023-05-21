using Mapster;
using MeetingEntities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting.Web.Dto;


/// <summary>
/// Represente l&apos;etat des presences des membres a une seance de reunion et l&apos;ensemble des signatures apposees par les membres (beneficiaire et bureau) de l&apos;association sur un document
/// </summary>

public partial class PresenceDto : BaseDto<PresenceDto, MeetPresence>
{
    /// <summary>
    /// Identiifant de la signature
    /// </summary>
    [Key]
    [Display(Name="presence_id")]
    public int PresenceId { get; set; }

    /// <summary>
    /// Seance_id
    /// </summary>
    [Display(Name="seance_id")]
    public int SeanceId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    [Display(Name="idinscrit")]
    public int Idinscrit { get; set; }

    /// <summary>
    /// Dateop
    /// </summary>
    [Display(Name="Date Op.")]
    public DateOnly Dateop { get; set; }

    /// <summary>
    /// Is_absent
    /// </summary>
    [Display(Name="Absent ?")]
    public bool IsAbsent { get; set; }

    /// <summary>
    /// globalverse
    /// </summary>
    [Display(Name="Global Verse")]
    public decimal Globalverse { get { return (VerseCash + VerseTransfert); }  }

    /// <summary>
    /// VerseCash
    /// </summary>
    [Display(Name = "Montant à payer")]
    public decimal PayableAmount { get; set; }

    /// <summary>
    /// VerseCash
    /// </summary>
    [Display(Name= "Cash versé")]
    public decimal VerseCash { get; set; }

    /// <summary>
    /// VerseTransfert
    /// </summary>
    [Display(Name= "Transfert versé")]
    public decimal VerseTransfert { get; set; }

    /// <summary>
    /// Num_bordero
    /// </summary>
    [Display(Name="N# bordereau")]
    [StringLength(128)]
    public string? NumBordero { get; set; }

    [Display(Name = "Memnbre ID")]
    public virtual InscriptionDto? Inscription { get; set; } = null!;

    [Display(Name = "Entrées caisse")]
    public virtual List<EntreeCaisseDto>? EntreeCaisses { get; set; } 
    //public virtual List<EntreeCaisseDto> EntreeCaisses { get; set; } = new List<EntreeCaisseDto>();

    [Display(Name = "Séance")]
    public virtual SeanceDto? Seance { get; set; } = null!;
    
    public override void AddCustomMappings()
    {
        SetCustomMappings()
            .Map(dest => dest.MeetEntreeCaisses, src => src.EntreeCaisses.Adapt<IEnumerable<MeetEntreeCaisse>>());
        //    .Map(dest => dest.Userid, src => src.UserId);

        SetCustomMappingsInverse()
            .Map(dest => dest.Inscription, src => src.IdinscritNavigation.Adapt<InscriptionDto>())
            .Map(dest => dest.Seance, src => src.Seance.Adapt<SeanceDto>());
            //.Map(dest => dest.EntreeCaisses, src => src.MeetEntreeCaisses.Adapt<IEnumerable<EntreeCaisseDto>>());            
    }
}
