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
[Index("profil_id", Name = "association_30_fk")]
[Index("idcmde", Name = "association_31_fk")]
[Index("choix_id", Name = "core_autorisations_pk", IsUnique = true)]
public partial class core_autorisation
{
    /// <summary>
    /// Choix_id
    /// </summary>
    [Key]
    public int choix_id { get; set; }

    /// <summary>
    /// Profil_id
    /// </summary>
    public int profil_id { get; set; }

    /// <summary>
    /// Idcmde
    /// </summary>
    public int idcmde { get; set; }

    /// <summary>
    /// Is_active
    /// </summary>
    public bool is_active { get; set; }

    [ForeignKey("idcmde")]
    [InverseProperty("core_autorisations")]
    public virtual core_commande idcmdeNavigation { get; set; } = null!;

    [ForeignKey("profil_id")]
    [InverseProperty("core_autorisations")]
    public virtual core_profil profil { get; set; } = null!;
}
