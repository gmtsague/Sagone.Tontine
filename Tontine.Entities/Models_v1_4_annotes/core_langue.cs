using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// core_Langue
/// </summary>
[Table("core_langue", Schema = "tontine_v14")]
[Index("langue_id", Name = "core_langue_pk", IsUnique = true)]
public partial class core_langue
{
    /// <summary>
    /// Identifiant de la langue
    /// </summary>
    [Key]
    public int langue_id { get; set; }

    /// <summary>
    /// Libelle de la langue
    /// </summary>
    [Column(TypeName = "jsonb")]
    public string libelle { get; set; } = null!;

    /// <summary>
    /// Code ISO de la langue
    /// </summary>
    [StringLength(8)]
    public string isocode { get; set; } = null!;

    /// <summary>
    /// Indique la langue par defaut
    /// </summary>
    public bool is_default { get; set; }

    /// <summary>
    /// Isactive
    /// </summary>
    public bool is_active { get; set; }

    [InverseProperty("langue")]
    public virtual ICollection<core_user> core_users { get; set; } = new List<core_user>();
}
