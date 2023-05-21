using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// core_Commandes
/// </summary>
[Table("core_commandes", Schema = "tontine_v14")]
[Index("idcmde", Name = "core_commandes_pk", IsUnique = true)]
public partial class core_commande
{
    /// <summary>
    /// Idcmde
    /// </summary>
    [Key]
    public int idcmde { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    [Column(TypeName = "jsonb")]
    public string libelle { get; set; } = null!;

    [InverseProperty("idcmdeNavigation")]
    public virtual ICollection<core_autorisation> core_autorisations { get; set; } = new List<core_autorisation>();
}
