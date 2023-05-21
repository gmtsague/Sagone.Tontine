using MeetingEntities.Models;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// core_country
/// </summary>
public partial class CountryDto : BaseDto<CountryDto, CoreCountry>
{
    /// <summary>
    /// Identifiant du pays
    /// </summary>
    [Key]
    [Display( Name="ID")]
    public long CountryId { get; set; }

    /// <summary>
    /// Nom du pays
    /// </summary>
    [Display( Name="Nom du pays"/*, TypeName = "jsonb"*/)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Code (2 caracteres) ISO du pays
    /// </summary>
    [Display( Name="Code ISO2")]
    [StringLength(8)]
    public string CodeIso2 { get; set; } = null!;

    /// <summary>
    /// Code (3 caracteres) ISO du pays
    /// </summary>
    [Display( Name="Code ISO3")]
    [StringLength(8)]
    public string CodeIso3 { get; set; } = null!;

    /// <summary>
    /// Code telephonique du pays
    /// </summary>
    [Display( Name="Phone Code")]
    [StringLength(8)]
    public string PhoneCode { get; set; } = null!;

    /// <summary>
    /// Devise du pays
    /// </summary>
    [Display( Name="Devise")]
    [StringLength(128)]
    public string? Devise { get; set; }

    public virtual ICollection<BankDto> Banks { get; set; } = new List<BankDto>();

    public virtual ICollection<EtablissementDto> Etablissements { get; set; } = new List<EtablissementDto>();

    //public virtual ICollection<PersonDto> People { get; set; } = new List<PersonDto>();

    //public virtual ICollection<CorePhonenumber> CorePhonenumbers { get; set; } = new List<CorePhonenumber>();
}
