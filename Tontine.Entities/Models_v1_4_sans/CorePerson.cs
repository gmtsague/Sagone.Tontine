using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans;

/// <summary>
/// Represente un membre de la reunion
/// </summary>
public partial class CorePerson
{
    /// <summary>
    /// Person_id
    /// </summary>
    public int PersonId { get; set; }

    /// <summary>
    /// create_uid
    /// </summary>
    public long? CreateUid { get; set; }

    /// <summary>
    /// update_uid
    /// </summary>
    public long? UpdateUid { get; set; }

    /// <summary>
    /// Create_at
    /// </summary>
    public DateTime CreateAt { get; set; }

    /// <summary>
    /// Update_at
    /// </summary>
    public DateTime UpdateAt { get; set; }

    /// <summary>
    /// Identifiant du pays
    /// </summary>
    public long? CountryId { get; set; }

    /// <summary>
    /// Etab_id
    /// </summary>
    public int? EtabId { get; set; }

    /// <summary>
    /// Nom
    /// </summary>
    public string Nom { get; set; } = null!;

    /// <summary>
    /// Prenom
    /// </summary>
    public string? Prenom { get; set; }

    /// <summary>
    /// Datenais
    /// </summary>
    public DateOnly? Datenais { get; set; }

    /// <summary>
    /// lieunais
    /// </summary>
    public string? Lieunais { get; set; }

    /// <summary>
    /// Sexe
    /// </summary>
    public string Sexe { get; set; } = null!;

    /// <summary>
    /// Email
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Adresse
    /// </summary>
    public string? Adresse { get; set; }

    /// <summary>
    /// Adhesion_date
    /// </summary>
    public DateOnly AdhesionDate { get; set; }

    /// <summary>
    /// Nocni
    /// </summary>
    public string Nocni { get; set; } = null!;

    /// <summary>
    /// CNI_Expire_date
    /// </summary>
    public DateOnly CniExpireDate { get; set; }

    /// <summary>
    /// Indique si le membre est suspendu ou pas
    /// </summary>
    public bool? IsActive { get; set; }

    /// <summary>
    /// Cette personne represente un utilisateur systeme
    /// </summary>
    public bool? IsVisible { get; set; }

    /// <summary>
    /// Annee_promo
    /// </summary>
    public string? AnneePromo { get; set; }

    public virtual ICollection<CoreBankaccount> CoreBankaccounts { get; set; } = new List<CoreBankaccount>();

    public virtual ICollection<CorePhonenumber> CorePhonenumbers { get; set; } = new List<CorePhonenumber>();

    public virtual ICollection<CorePhoto> CorePhotos { get; set; } = new List<CorePhoto>();

    public virtual CoreCountry? Country { get; set; }

    public virtual CoreEtablissement? Etab { get; set; }

    public virtual ICollection<MeetEngagement> MeetEngagements { get; set; } = new List<MeetEngagement>();

    public virtual ICollection<MeetInscription> MeetInscriptions { get; set; } = new List<MeetInscription>();

    public virtual ICollection<MeetSuspensionMembre> MeetSuspensionMembres { get; set; } = new List<MeetSuspensionMembre>();
}
