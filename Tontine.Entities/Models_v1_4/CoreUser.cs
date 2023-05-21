using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4;

/// <summary>
/// core_User
/// </summary>
[Table("core_user", Schema = "tontine_v14")]
[Index("ProfilId", Name = "association_32_fk")]
[Index("LangueId", Name = "association_38_fk")]
[Index("UserId", Name = "core_user_pk", IsUnique = true)]
public partial class CoreUser
{
    /// <summary>
    /// User_Id
    /// </summary>
    [Key]
    [Column("user_id")]
    public int UserId { get; set; }

    /// <summary>
    /// Profil_id
    /// </summary>
    [Column("profil_id")]
    public int ProfilId { get; set; }

    /// <summary>
    /// Identifiant de la langue
    /// </summary>
    [Column("langue_id")]
    public int LangueId { get; set; }

    /// <summary>
    /// Nom d&apos;utilisateur
    /// </summary>
    [Column("username")]
    [StringLength(128)]
    public string Username { get; set; } = null!;

    /// <summary>
    /// Mot de passe
    /// </summary>
    [Column("passwd")]
    [StringLength(254)]
    public string Passwd { get; set; } = null!;

    /// <summary>
    /// Compte actif
    /// </summary>
    [Column("is_actif")]
    public bool IsActif { get; set; }

    /// <summary>
    /// Date d&apos;expiration
    /// </summary>
    [Column("expiration_date")]
    public DateOnly? ExpirationDate { get; set; }

    /// <summary>
    /// Last_connexion
    /// </summary>
    [Column("last_connexion")]
    public DateOnly? LastConnexion { get; set; }

    [ForeignKey("LangueId")]
    [InverseProperty("CoreUsers")]
    public virtual CoreLangue Langue { get; set; } = null!;

    [ForeignKey("ProfilId")]
    [InverseProperty("CoreUsers")]
    public virtual CoreProfil Profil { get; set; } = null!;
}
