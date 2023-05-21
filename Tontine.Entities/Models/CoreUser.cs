using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// core_User
/// </summary>
[Table("core_user", Schema = "tontine")]
[Index("Idprofil", Name = "association_32_fk")]
[Index("LangueId", Name = "association_38_fk")]
[Index("Userid", Name = "core_user_pk", IsUnique = true)]
public partial class CoreUser
{
    /// <summary>
    /// UserId
    /// </summary>
    [Key]
    [Column("userid")]
    public int Userid { get; set; }

    /// <summary>
    /// Idprofil
    /// </summary>
    [Column("idprofil")]
    public int Idprofil { get; set; }

    /// <summary>
    /// Identifiant de la langue
    /// </summary>
    [Column("langue_id")]
    public int LangueId { get; set; }

    /// <summary>
    /// Nom d&apos;utilisateur
    /// </summary>
    [Column("username")]
    [StringLength(254)]
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
    [Column("isactif")]
    public bool Isactif { get; set; }

    /// <summary>
    /// Date d&apos;expiration
    /// </summary>
    [Column("expirationdate")]
    public DateOnly? Expirationdate { get; set; }

    /// <summary>
    /// Lastconnexion
    /// </summary>
    [Column("lastconnexion")]
    public DateOnly? Lastconnexion { get; set; }

    [ForeignKey("Idprofil")]
    [InverseProperty("CoreUsers")]
    public virtual CoreProfil IdprofilNavigation { get; set; } = null!;

    [ForeignKey("LangueId")]
    [InverseProperty("CoreUsers")]
    public virtual CoreLangue Langue { get; set; } = null!;
}
