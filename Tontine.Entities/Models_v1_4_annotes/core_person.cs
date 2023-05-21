using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Represente un membre de la reunion
/// </summary>
[Table("core_person", Schema = "tontine_v14")]
[Index("etab_id", Name = "association_48_fk")]
[Index("country_id", Name = "association_8_fk")]
[Index("person_id", Name = "core_person_pk", IsUnique = true)]
[Index("nocni", Name = "uniq_cni_person", IsUnique = true)]
[Index("nom", "prenom", "datenais", "lieunais", "sexe", Name = "uniq_person", IsUnique = true)]
[Index("email", Name = "unique_email_person", IsUnique = true)]
public partial class core_person
{
    /// <summary>
    /// Person_id
    /// </summary>
    [Key]
    public int person_id { get; set; }

    /// <summary>
    /// create_uid
    /// </summary>
    public long? create_uid { get; set; }

    /// <summary>
    /// update_uid
    /// </summary>
    public long? update_uid { get; set; }

    /// <summary>
    /// Create_at
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime create_at { get; set; }

    /// <summary>
    /// Update_at
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime update_at { get; set; }

    /// <summary>
    /// Identifiant du pays
    /// </summary>
    public long? country_id { get; set; }

    /// <summary>
    /// Etab_id
    /// </summary>
    public int? etab_id { get; set; }

    /// <summary>
    /// Nom
    /// </summary>
    [StringLength(128)]
    public string nom { get; set; } = null!;

    /// <summary>
    /// Prenom
    /// </summary>
    [StringLength(128)]
    public string? prenom { get; set; }

    /// <summary>
    /// Datenais
    /// </summary>
    public DateOnly? datenais { get; set; }

    /// <summary>
    /// lieunais
    /// </summary>
    [StringLength(128)]
    public string? lieunais { get; set; }

    /// <summary>
    /// Sexe
    /// </summary>
    [StringLength(16)]
    public string sexe { get; set; } = null!;

    /// <summary>
    /// Email
    /// </summary>
    [StringLength(64)]
    public string? email { get; set; }

    /// <summary>
    /// Adresse
    /// </summary>
    [StringLength(1024)]
    public string? adresse { get; set; }

    /// <summary>
    /// Adhesion_date
    /// </summary>
    public DateOnly adhesion_date { get; set; }

    /// <summary>
    /// Nocni
    /// </summary>
    [StringLength(32)]
    public string nocni { get; set; } = null!;

    /// <summary>
    /// CNI_Expire_date
    /// </summary>
    public DateOnly cni_expire_date { get; set; }

    /// <summary>
    /// Indique si le membre est suspendu ou pas
    /// </summary>
    public bool? is_active { get; set; }

    /// <summary>
    /// Cette personne represente un utilisateur systeme
    /// </summary>
    [Required]
    public bool? is_visible { get; set; }

    /// <summary>
    /// Annee_promo
    /// </summary>
    [StringLength(32)]
    public string? annee_promo { get; set; }

    [InverseProperty("person")]
    public virtual ICollection<core_bankaccount> core_bankaccounts { get; set; } = new List<core_bankaccount>();

    [InverseProperty("person")]
    public virtual ICollection<core_phonenumber> core_phonenumbers { get; set; } = new List<core_phonenumber>();

    [InverseProperty("person")]
    public virtual ICollection<core_photo> core_photos { get; set; } = new List<core_photo>();

    [ForeignKey("country_id")]
    [InverseProperty("core_people")]
    public virtual core_country? country { get; set; }

    [ForeignKey("etab_id")]
    [InverseProperty("core_people")]
    public virtual core_etablissement? etab { get; set; }

    [InverseProperty("person")]
    public virtual ICollection<meet_engagement> meet_engagements { get; set; } = new List<meet_engagement>();

    [InverseProperty("person")]
    public virtual ICollection<meet_inscription> meet_inscriptions { get; set; } = new List<meet_inscription>();

    [InverseProperty("person")]
    public virtual ICollection<meet_suspension_membre> meet_suspension_membres { get; set; } = new List<meet_suspension_membre>();
}
