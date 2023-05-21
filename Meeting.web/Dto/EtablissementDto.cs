using MeetingEntities.Models;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// core_Etablissement
/// </summary>
public partial class EtablissementDto : BaseDto<EtablissementDto, CoreEtablissement>
{
    /// <summary>
    /// Etab_id
    /// </summary>
    [Key]
    [Display( Name="ID")]
    public int EtabId { get; set; }

    /// <summary>
    /// Identifiant du pays
    /// </summary>
    [Display( Name="ID Pays")]
    public long? CountryId { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    [Display( Name="Libelle")]
    [StringLength(256)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Adresse
    /// </summary>
    [Display( Name="Adresse")]
    [StringLength(1024)]
    public string? Adresse { get; set; }

    /// <summary>
    /// Creationdate
    /// </summary>
    [Display( Name="Creation Date")]
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    [DataType(DataType.Date)]
    public DateOnly? Creationdate { get; set; }

    /// <summary>
    /// Deployed_Url
    /// </summary>
    [Display( Name="Deployed URL")]
    [StringLength(1024)]
    public string DeployedUrl { get; set; } = null!;

    /// <summary>
    /// Database_name
    /// </summary>
    [Display( Name="Database Name")]
    [StringLength(1024)]
    public string? DatabaseName { get; set; }

    /// <summary>
    /// Conn_string
    /// </summary>
    [Display( Name="Conn.String")]
    [StringLength(1024)]
    public string? ConnString { get; set; }

    /// <summary>
    /// Enable_multi_antenne
    /// </summary>
    [Display( Name="Enable Multi Antenne")]
    public bool EnableMultiAntenne { get; set; }

    /*[InverseProperty("Etab")]
    public virtual ICollection<CoreAnnualSetting> CoreAnnualSettings { get; set; } = new List<CoreAnnualSetting>();

    [InverseProperty("Etab")]
    public virtual ICollection<CoreBankaccount> Bankaccounts { get; set; } = new List<Bankaccount>();

    [InverseProperty("Etab")]
    public virtual ICollection<CorePerson> People { get; set; } = new List<Person>();

    [InverseProperty("Etab")]
    public virtual ICollection<CorePhoto> CorePhotos { get; set; } = new List<CorePhoto>();
    */
    [Display(Name = "Pays")]
    public virtual CountryDto? Country { get; set; }

    public virtual ICollection<AntenneDto> Antennes { get; set; } = new List<AntenneDto>();

    public virtual ICollection<BureauDto> Bureaus { get; set; } = new List<BureauDto>();
}
