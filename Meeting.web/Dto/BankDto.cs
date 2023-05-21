using MeetingEntities.Models;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto;

/// <summary>
/// Etablissement financier
/// </summary>

public partial class BankDto : BaseDto<BankDto, CoreBank>
{
    /// <summary>
    /// Identifiant de la banque
    /// </summary>
    [Key]
    [Display(Name = "Bank ID")]
    public int BankId { get; set; }

    /// <summary>
    /// Identifiant du pays
    /// </summary>
    [Display(Name = "Pays")]
    public long? CountryId { get; set; }

    /// <summary>
    /// Libelle de la banque
    /// </summary>
    [Display(Name = "Nom de la banque")]
    [StringLength(1024)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Adresse postale de la banque
    /// </summary>
    [Display(Name = "Adresse")]
    [StringLength(1024)]
    public string? Adresse { get; set; }

    /// <summary>
    /// Contact telephonique de la banque No2
    /// </summary>
    [Display(Name = "Email")]
    [StringLength(64)]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }

    /// <summary>
    /// Numero de compte de l&apos;association chez la baqnue
    /// </summary>
    [Display(Name = "Code RIB")]
    [StringLength(64)]
    public string Coderib { get; set; } = null!;

    //[Display(Name = "Comptes bancaires")]
    //public virtual ICollection<BankaccountDto> CoreBankaccounts { get; set; } = new List<BankaccountDto>();

    //[Display(Name = "N# téléphone")]
    //public virtual ICollection<PhonenumberDto> CorePhonenumbers { get; set; } = new List<PhonenumberDto>();

    [Display(Name = "Pays")]
    public virtual CountryDto? Country { get; set; }
}
