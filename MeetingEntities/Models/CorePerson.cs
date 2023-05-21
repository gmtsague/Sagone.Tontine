using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MeetingEntities.Models;

/// <summary>
/// Represente un membre de la reunion
/// </summary>
[Table("core_person", Schema = "tontine_v14")]
[Index("EtabId", Name = "association_48_fk")]
[Index("CountryId", Name = "association_8_fk")]
[Index("PersonId", Name = "core_person_pk", IsUnique = true)]
[Index("Nocni", Name = "uniq_cni_person", IsUnique = true)]
[Index("Nom", "Prenom", "Datenais", "Lieunais", "Sexe", Name = "uniq_person", IsUnique = true)]
[Index("Email", Name = "unique_email_person", IsUnique = true)]
public partial class CorePerson
{
    /// <summary>
    /// Person_id
    /// </summary>
    [Key]
    [Column("person_id")]
    public int PersonId { get; set; }

    /// <summary>
    /// create_uid
    /// </summary>
    [Column("create_uid")]
    public long? CreateUid { get; set; }

    /// <summary>
    /// update_uid
    /// </summary>
    [Column("update_uid")]
    public long? UpdateUid { get; set; }

    /// <summary>
    /// Create_at
    /// </summary>
    [Column("create_at", TypeName = "timestamp without time zone")]
    public DateTime CreateAt { get; set; }

    /// <summary>
    /// Update_at
    /// </summary>
    [Column("update_at", TypeName = "timestamp without time zone")]
    public DateTime UpdateAt { get; set; }

    /// <summary>
    /// Identifiant du pays
    /// </summary>
    [Column("country_id")]
    public long? CountryId { get; set; }

    /// <summary>
    /// Etab_id
    /// </summary>
    [Column("etab_id")]
    public int? EtabId { get; set; }

    /// <summary>
    /// Nom
    /// </summary>
    [Column("nom")]
    [StringLength(128)]
    public string Nom { get; set; } = null!;

    /// <summary>
    /// Prenom
    /// </summary>
    [Column("prenom")]
    [StringLength(128)]
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
    [StringLength(128)]
    public string? Lieunais { get; set; }

    /// <summary>
    /// Sexe
    /// </summary>
    [Column("sexe")]
    [StringLength(16)]
    public string Sexe { get; set; } = null!;

    /// <summary>
    /// Email
    /// </summary>
    [Column("email")]
    [StringLength(64)]
    public string? Email { get; set; }

    /// <summary>
    /// Adresse
    /// </summary>
    [Column("adresse")]
    [StringLength(1024)]
    public string? Adresse { get; set; }

    /// <summary>
    /// Adhesion_date
    /// </summary>
    [Column("adhesion_date")]
    public DateOnly AdhesionDate { get; set; }

    /// <summary>
    /// Nocni
    /// </summary>
    [Column("nocni")]
    [StringLength(32)]
    public string Nocni { get; set; } = null!;

    /// <summary>
    /// CNI_Expire_date
    /// </summary>
    [Column("cni_expire_date")]
    public DateOnly CniExpireDate { get; set; }

    /// <summary>
    /// Indique si le membre est suspendu ou pas
    /// </summary>
    [Column("is_active")]
    public bool? IsActive { get; set; }

    /// <summary>
    /// Cette personne represente un utilisateur systeme
    /// </summary>
    [Required]
    [Column("is_visible")]
    public bool? IsVisible { get; set; }

    /// <summary>
    /// Annee_promo
    /// </summary>
    [Column("annee_promo")]
    [StringLength(32)]
    public string? AnneePromo { get; set; }

    [InverseProperty("Person")]
    public virtual ICollection<CoreBankaccount> CoreBankaccounts { get; set; } = new List<CoreBankaccount>();

    [InverseProperty("Person")]
    public virtual ICollection<CorePhonenumber> CorePhonenumbers { get; set; } = new List<CorePhonenumber>();

    [InverseProperty("Person")]
    public virtual ICollection<CorePhoto> CorePhotos { get; set; } = new List<CorePhoto>();

    [ForeignKey("CountryId")]
    [InverseProperty("CorePeople")]
    public virtual CoreCountry? Country { get; set; }

    [ForeignKey("EtabId")]
    [InverseProperty("CorePeople")]
    public virtual CoreEtablissement? Etab { get; set; }

    [InverseProperty("Person")]
    public virtual ICollection<MeetEngagement> MeetEngagements { get; set; } = new List<MeetEngagement>();

    [InverseProperty("Person")]
    public virtual ICollection<MeetInscription> MeetInscriptions { get; set; } = new List<MeetInscription>();

    [InverseProperty("Person")]
    public virtual ICollection<MeetSuspensionMembre> MeetSuspensionMembres { get; set; } = new List<MeetSuspensionMembre>();
}
