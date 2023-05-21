using System;
using System.Collections.Generic;

namespace Tontine.Entities.olds;

/// <summary>
/// core_User
/// </summary>
public partial class CoreUser
{
    /// <summary>
    /// UserId
    /// </summary>
    public int Userid { get; set; }

    /// <summary>
    /// Idprofil
    /// </summary>
    public int Idprofil { get; set; }

    /// <summary>
    /// Identifiant de la langue
    /// </summary>
    public int LangueId { get; set; }

    /// <summary>
    /// Nom d&apos;utilisateur
    /// </summary>
    public string Username { get; set; } = null!;

    /// <summary>
    /// Mot de passe
    /// </summary>
    public string Passwd { get; set; } = null!;

    /// <summary>
    /// Compte actif
    /// </summary>
    public bool Isactif { get; set; }

    /// <summary>
    /// Date d&apos;expiration
    /// </summary>
    public DateOnly? Expirationdate { get; set; }

    /// <summary>
    /// Lastconnexion
    /// </summary>
    public DateOnly? Lastconnexion { get; set; }

    public virtual CoreProfil IdprofilNavigation { get; set; } = null!;

    public virtual CoreLangue Langue { get; set; } = null!;
}
