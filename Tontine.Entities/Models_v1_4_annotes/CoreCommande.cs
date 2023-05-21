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
[Index("Idcmde", Name = "core_commandes_pk", IsUnique = true)]
public partial class CoreCommande
{
    /// <summary>
    /// Idcmde
    /// </summary>
    [Key]
    [Column("idcmde")]
    public int Idcmde { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    [Column("libelle", TypeName = "jsonb")]
    public string Libelle { get; set; } = null!;

    [InverseProperty("IdcmdeNavigation")]
    public virtual ICollection<CoreAutorisation> CoreAutorisations { get; set; } = new List<CoreAutorisation>();
}
