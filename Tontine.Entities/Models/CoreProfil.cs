using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// core_Profil
/// </summary>
[Table("core_profil", Schema = "tontine")]
[Index("Idprofil", Name = "core_profil_pk", IsUnique = true)]
public partial class CoreProfil
{
    /// <summary>
    /// Idprofil
    /// </summary>
    [Key]
    [Column("idprofil")]
    public int Idprofil { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    [Column("libelle")]
    [StringLength(254)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Candelete
    /// </summary>
    [Column("candelete")]
    public bool Candelete { get; set; }

    [InverseProperty("IdprofilNavigation")]
    public virtual ICollection<CoreAutorisation> CoreAutorisations { get; set; } = new List<CoreAutorisation>();

    [InverseProperty("IdprofilNavigation")]
    public virtual ICollection<CoreUser> CoreUsers { get; set; } = new List<CoreUser>();
}
