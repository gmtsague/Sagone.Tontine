using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// core_User
/// </summary>
public partial class CoreUser
{
    /// <summary>
    /// User_Id
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Profil_id
    /// </summary>
    public int ProfilId { get; set; }

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
    public bool IsActif { get; set; }

    /// <summary>
    /// Date d&apos;expiration
    /// </summary>
    public DateOnly? ExpirationDate { get; set; }

    /// <summary>
    /// Last_connexion
    /// </summary>
    public DateOnly? LastConnexion { get; set; }

    public virtual CoreLangue Langue { get; set; } = null!;

    public virtual CoreProfil Profil { get; set; } = null!;
}
