using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MeetingEntities.Models;

/// <summary>
/// core_Langue
/// </summary>
[Table("core_langue", Schema = "tontine_v14")]
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
    [Column("libelle", TypeName = "jsonb")]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Code ISO de la langue
    /// </summary>
    [Column("isocode")]
    [StringLength(8)]
    public string Isocode { get; set; } = null!;

    /// <summary>
    /// Indique la langue par defaut
    /// </summary>
    [Column("is_default")]
    public bool IsDefault { get; set; }

    /// <summary>
    /// Isactive
    /// </summary>
    [Column("is_active")]
    public bool IsActive { get; set; }

    [InverseProperty("Langue")]
    public virtual ICollection<CoreUser> CoreUsers { get; set; } = new List<CoreUser>();
}
