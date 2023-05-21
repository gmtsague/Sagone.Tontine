using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// core_User
/// </summary>
[Table("core_user", Schema = "tontine_v14")]
[Index("profil_id", Name = "association_32_fk")]
[Index("langue_id", Name = "association_38_fk")]
[Index("user_id", Name = "core_user_pk", IsUnique = true)]
public partial class core_user
{
    /// <summary>
    /// User_Id
    /// </summary>
    [Key]
    public int user_id { get; set; }

    /// <summary>
    /// Profil_id
    /// </summary>
    public int profil_id { get; set; }

    /// <summary>
    /// Identifiant de la langue
    /// </summary>
    public int langue_id { get; set; }

    /// <summary>
    /// Nom d&apos;utilisateur
    /// </summary>
    [StringLength(128)]
    public string username { get; set; } = null!;

    /// <summary>
    /// Mot de passe
    /// </summary>
    [StringLength(254)]
    public string passwd { get; set; } = null!;

    /// <summary>
    /// Compte actif
    /// </summary>
    public bool is_actif { get; set; }

    /// <summary>
    /// Date d&apos;expiration
    /// </summary>
    public DateOnly? expiration_date { get; set; }

    /// <summary>
    /// Last_connexion
    /// </summary>
    public DateOnly? last_connexion { get; set; }

    [ForeignKey("langue_id")]
    [InverseProperty("core_users")]
    public virtual core_langue langue { get; set; } = null!;

    [ForeignKey("profil_id")]
    [InverseProperty("core_users")]
    public virtual core_profil profil { get; set; } = null!;
}
