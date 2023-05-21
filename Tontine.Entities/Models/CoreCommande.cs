using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// core_Commandes
/// </summary>
[Table("core_commandes", Schema = "tontine")]
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
    [Column("libelle")]
    [StringLength(254)]
    public string Libelle { get; set; } = null!;

    [InverseProperty("IdcmdeNavigation")]
    public virtual ICollection<CoreAutorisation> CoreAutorisations { get; set; } = new List<CoreAutorisation>();
}
