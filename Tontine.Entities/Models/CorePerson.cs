using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Represente un membre de la reunion
/// </summary>
[Table("core_person", Schema = "tontine")]
[Index("PaysId", Name = "association_8_fk")]
[Index("Idperson", Name = "core_person_pk", IsUnique = true)]
public partial class CorePerson
{
    /// <summary>
    /// Idperson
    /// </summary>
    [Key]
    [Column("idperson")]
    public int Idperson { get; set; }

    /// <summary>
    /// Identifiant du pays
    /// </summary>
    [Column("pays_id")]
    public long? PaysId { get; set; }

    /// <summary>
    /// Nom
    /// </summary>
    [Column("nom")]
    [StringLength(254)]
    public string Nom { get; set; } = null!;

    /// <summary>
    /// Prenom
    /// </summary>
    [Column("prenom")]
    [StringLength(254)]
    public string? Prenom { get; set; }

    /// <summary>
    /// Datenais
    /// </summary>
    [Column("datenais")]
    public DateOnly? Datenais { get; set; }

    /// <summary>
    /// lieunais
    /// </summary>
    [Column("lieunais")]
    [StringLength(254)]
    public string? Lieunais { get; set; }

    /// <summary>
    /// Sexe
    /// </summary>
    [Column("sexe")]
    [StringLength(254)]
    public string Sexe { get; set; } = null!;

    /// <summary>
    /// Email
    /// </summary>
    [Column("email")]
    [StringLength(254)]
    public string? Email { get; set; }

    /// <summary>
    /// Adresse
    /// </summary>
    [Column("adresse")]
    [StringLength(254)]
    public string? Adresse { get; set; }

    /// <summary>
    /// Dateadhesion
    /// </summary>
    [Column("dateadhesion")]
    public DateOnly Dateadhesion { get; set; }

    /// <summary>
    /// Anneepromo
    /// </summary>
    [Column("anneepromo")]
    [StringLength(254)]
    public string? Anneepromo { get; set; }

    /// <summary>
    /// Nocni
    /// </summary>
    [Column("nocni")]
    [StringLength(254)]
    public string Nocni { get; set; } = null!;

    /// <summary>
    /// Cette personne represente un utilisateur systeme
    /// </summary>
    [Column("isvisible")]
    public bool Isvisible { get; set; }

    [InverseProperty("IdpersonNavigation")]
    public virtual ICollection<CoreBankaccount> CoreBankaccounts { get; set; } = new List<CoreBankaccount>();

    [InverseProperty("IdpersonNavigation")]
    public virtual ICollection<CorePhonenumber> CorePhonenumbers { get; set; } = new List<CorePhonenumber>();

    [InverseProperty("IdpersonNavigation")]
    public virtual ICollection<CorePhoto> CorePhotos { get; set; } = new List<CorePhoto>();

    [InverseProperty("IdpersonNavigation")]
    public virtual ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();

    [ForeignKey("PaysId")]
    [InverseProperty("CorePeople")]
    public virtual CorePay? Pays { get; set; }
}
