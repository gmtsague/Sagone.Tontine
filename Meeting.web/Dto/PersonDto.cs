using MeetingEntities.Models;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// Mode de paiement utilise par un membre
/// </summary>

public partial class PersonDto : BaseDto<PersonDto, CorePerson>
{
    /// <summary>
    /// Person_id
    /// </summary>
    [Key]
    [Display( Name="person_id")]
    public int PersonId { get; set; }

    /// <summary>
    /// Identifiant du pays
    /// </summary>
    [Display( Name="country_id")]
    public long? CountryId { get; set; }

    /// <summary>
    /// Etab_id
    /// </summary>
    [Display( Name="etab_id")]
    public int? EtabId { get; set; }

    /// <summary>
    /// Nom
    /// </summary>
    [Display( Name="Nom")]
    [StringLength(128)]
    public string Nom { get; set; } = null!;

    /// <summary>
    /// Prenom
    /// </summary>
    [Display( Name="Prenom")]
    [StringLength(128)]
    public string? Prenom { get; set; }

    [Display(Name = "Full Name")]
    [StringLength(128)]
    public string? FullName { get; set; }

    /// <summary>
    /// Datenais
    /// </summary>
    [Display( Name="Date Nais.")]
    public DateOnly? Datenais { get; set; }

    /// <summary>
    /// lieunais
    /// </summary>
    [Display( Name="Lieu Nais.")]
    [StringLength(128)]
    public string? Lieunais { get; set; }

    /// <summary>
    /// Sexe
    /// </summary>
    [Display( Name="Sexe")]
    [StringLength(16)]
    public string Sexe { get; set; } = null!;

    /// <summary>
    /// Email
    /// </summary>
    [Display( Name="Email")]
    [DataType(DataType.EmailAddress)]
    [StringLength(64)]
    public string? Email { get; set; }

    /// <summary>
    /// Adresse
    /// </summary>
    [Display( Name="Adresse")]
    [StringLength(1024)]
    public string? Adresse { get; set; }

    /// <summary>
    /// Adhesion_date
    /// </summary>
    [Display( Name="Date Adhesion")]
    public DateOnly AdhesionDate { get; set; }

    /// <summary>
    /// Nocni
    /// </summary>
    [Display( Name="No CNI")]
    [StringLength(32)]
    public string Nocni { get; set; } = null!;

    /// <summary>
    /// CNI_Expire_date
    /// </summary>
    [Display( Name="CNI Expire date")]
    public DateOnly CniExpireDate { get; set; }

    /// <summary>
    /// Indique si le membre est suspendu ou pas
    /// </summary>
    [Display( Name="Actif ?")]
    public bool IsActive { get; set; }

    /// <summary>
    /// Cette personne represente un utilisateur systeme
    /// </summary>
    [Required]
    [Display( Name="Visible ?")]
    public bool IsVisible { get; set; }

    /// <summary>
    /// Annee_promo
    /// </summary>
    [Display( Name="Année Promo.")]
    [StringLength(32)]
    public string? AnneePromo { get; set; }


    //public virtual ICollection<CoreBankaccount> CoreBankaccounts { get; set; } = new List<CoreBankaccount>();


    //public virtual ICollection<CorePhonenumber> CorePhonenumbers { get; set; } = new List<CorePhonenumber>();


    //public virtual ICollection<CorePhoto> CorePhotos { get; set; } = new List<CorePhoto>();

    public virtual CountryDto? Country { get; set; }

    public virtual EtablissementDto? Etab { get; set; }

    public virtual ICollection<EngagementDto> Engagements { get; set; } = new List<EngagementDto>();

    public virtual ICollection<InscriptionDto> Inscriptions { get; set; } = new List<InscriptionDto>();

    //[InverseProperty("Person")]
    //public virtual ICollection<SuspensionMembreDto> SuspensionMembres { get; set; } = new List<SuspensionMembreDto>();
    public override void AddCustomMappings()
    {
        //SetCustomMappings()
        //    .Map(dest => dest.full, src => src.Dateop)
        //    .Map(dest => dest.Userid, src => src.UserId);

        SetCustomMappingsInverse()
            .Map(dest => dest.FullName, src => $"{src.Nom} {src.Prenom}");
    }
}
