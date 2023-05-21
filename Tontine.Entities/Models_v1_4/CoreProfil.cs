using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4;

/// <summary>
/// core_Profil
/// </summary>
[Table("core_profil", Schema = "tontine_v14")]
[Index("ProfilId", Name = "core_profil_pk", IsUnique = true)]
public partial class CoreProfil
{
    /// <summary>
    /// Profil_id
    /// </summary>
    [Key]
    [Column("profil_id")]
    public int ProfilId { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    [Column("libelle", TypeName = "jsonb")]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Candelete
    /// </summary>
    [Column("candelete")]
    public bool Candelete { get; set; }

    [InverseProperty("Profil")]
    public virtual ICollection<CoreAutorisation> CoreAutorisations { get; set; } = new List<CoreAutorisation>();

    [InverseProperty("Profil")]
    public virtual ICollection<CoreUser> CoreUsers { get; set; } = new List<CoreUser>();
}
