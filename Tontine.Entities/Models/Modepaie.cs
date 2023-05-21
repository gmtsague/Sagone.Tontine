using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Mode de paiement utilise par un membre
/// </summary>
[Table("modepaie", Schema = "tontine")]
[Index("Idmode", Name = "modepaie_pk", IsUnique = true)]
public partial class Modepaie
{
    /// <summary>
    /// Identifiant du mode de paiement
    /// </summary>
    [Key]
    [Column("idmode")]
    public int Idmode { get; set; }

    /// <summary>
    /// Libelle du mode de paiement
    /// </summary>
    [Column("libelle")]
    [StringLength(254)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Indique si le mode represnte le CASH
    /// </summary>
    [Column("iscash")]
    public bool Iscash { get; set; }

    [InverseProperty("IdmodeNavigation")]
    public virtual ICollection<Presence> Presences { get; set; } = new List<Presence>();
}
