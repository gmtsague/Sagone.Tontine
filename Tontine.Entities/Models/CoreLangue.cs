using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// core_Langue
/// </summary>
[Table("core_langue", Schema = "tontine")]
[Index("LangueId", Name = "core_langue_pk", IsUnique = true)]
public partial class CoreLangue
{
    /// <summary>
    /// Identifiant de la langue
    /// </summary>
    [Key]
    [Column("langue_id")]
    public int LangueId { get; set; }

    /// <summary>
    /// Libelle de la langue
    /// </summary>
    [Column("libelle")]
    [StringLength(254)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Code ISO de la langue
    /// </summary>
    [Column("isocode")]
    [StringLength(254)]
    public string Isocode { get; set; } = null!;

    /// <summary>
    /// Indique la langue par defaut
    /// </summary>
    [Column("isdefault")]
    public bool Isdefault { get; set; }

    /// <summary>
    /// isactive
    /// </summary>
    [Column("isactive")]
    public bool Isactive { get; set; }

    [InverseProperty("Langue")]
    public virtual ICollection<CoreUser> CoreUsers { get; set; } = new List<CoreUser>();
}
