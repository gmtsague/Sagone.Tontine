using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// core_Autorisations
/// </summary>
[Table("core_autorisations", Schema = "tontine")]
[Index("Idprofil", Name = "association_30_fk")]
[Index("Idcmde", Name = "association_31_fk")]
[Index("Idchoix", Name = "core_autorisations_pk", IsUnique = true)]
public partial class CoreAutorisation
{
    /// <summary>
    /// Idchoix
    /// </summary>
    [Key]
    [Column("idchoix")]
    public int Idchoix { get; set; }

    /// <summary>
    /// Idprofil
    /// </summary>
    [Column("idprofil")]
    public int Idprofil { get; set; }

    /// <summary>
    /// Idcmde
    /// </summary>
    [Column("idcmde")]
    public int Idcmde { get; set; }

    /// <summary>
    /// Isactive
    /// </summary>
    [Column("isactive")]
    public bool Isactive { get; set; }

    [ForeignKey("Idcmde")]
    [InverseProperty("CoreAutorisations")]
    public virtual CoreCommande IdcmdeNavigation { get; set; } = null!;

    [ForeignKey("Idprofil")]
    [InverseProperty("CoreAutorisations")]
    public virtual CoreProfil IdprofilNavigation { get; set; } = null!;
}
