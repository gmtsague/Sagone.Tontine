using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// core_Autorisations
/// </summary>
[Table("core_autorisations", Schema = "tontine_v14")]
[Index("ProfilId", Name = "association_30_fk")]
[Index("Idcmde", Name = "association_31_fk")]
[Index("ChoixId", Name = "core_autorisations_pk", IsUnique = true)]
public partial class CoreAutorisation
{
    /// <summary>
    /// Choix_id
    /// </summary>
    [Key]
    [Column("choix_id")]
    public int ChoixId { get; set; }

    /// <summary>
    /// Profil_id
    /// </summary>
    [Column("profil_id")]
    public int ProfilId { get; set; }

    /// <summary>
    /// Idcmde
    /// </summary>
    [Column("idcmde")]
    public int Idcmde { get; set; }

    /// <summary>
    /// Is_active
    /// </summary>
    [Column("is_active")]
    public bool IsActive { get; set; }

    [ForeignKey("Idcmde")]
    [InverseProperty("CoreAutorisations")]
    public virtual CoreCommande IdcmdeNavigation { get; set; } = null!;

    [ForeignKey("ProfilId")]
    [InverseProperty("CoreAutorisations")]
    public virtual CoreProfil Profil { get; set; } = null!;
}
