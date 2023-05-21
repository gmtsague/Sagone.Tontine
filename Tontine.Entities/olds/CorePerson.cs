using System;
using System.Collections.Generic;

namespace Tontine.Entities.olds;

/// <summary>
/// Represente un membre de la reunion
/// </summary>
public partial class CorePerson
{
    /// <summary>
    /// Idperson
    /// </summary>
    public int Idperson { get; set; }

    /// <summary>
    /// Identifiant du pays
    /// </summary>
    public long? PaysId { get; set; }

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
    /// Dateadhesion
    /// </summary>
    public DateOnly Dateadhesion { get; set; }

    /// <summary>
    /// Anneepromo
    /// </summary>
    public string? Anneepromo { get; set; }

    /// <summary>
    /// Nocni
    /// </summary>
    public string Nocni { get; set; } = null!;

    /// <summary>
    /// Cette personne represente un utilisateur systeme
    /// </summary>
    public bool Isvisible { get; set; }

    public virtual ICollection<CoreBankaccount> CoreBankaccounts { get; set; } = new List<CoreBankaccount>();

    public virtual ICollection<CorePhonenumber> CorePhonenumbers { get; set; } = new List<CorePhonenumber>();

    public virtual ICollection<CorePhoto> CorePhotos { get; set; } = new List<CorePhoto>();

    public virtual ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();

    public virtual CorePay? Pays { get; set; }
}
