using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// core_Profil
/// </summary>
[Table("core_profil", Schema = "tontine_v14")]
[Index("profil_id", Name = "core_profil_pk", IsUnique = true)]
public partial class core_profil
{
    /// <summary>
    /// Profil_id
    /// </summary>
    [Key]
    public int profil_id { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    [Column(TypeName = "jsonb")]
    public string libelle { get; set; } = null!;

    /// <summary>
    /// Candelete
    /// </summary>
    public bool candelete { get; set; }

    [InverseProperty("profil")]
    public virtual ICollection<core_autorisation> core_autorisations { get; set; } = new List<core_autorisation>();

    [InverseProperty("profil")]
    public virtual ICollection<core_user> core_users { get; set; } = new List<core_user>();
}
