using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Aide
/// </summary>
[Table("aide", Schema = "tontine")]
[Index("Idevts", Name = "aide_pk", IsUnique = true)]
public partial class Aide
{
    /// <summary>
    /// Idevts
    /// </summary>
    [Key]
    [Column("idevts")]
    public int Idevts { get; set; }

    /// <summary>
    /// Libelle de l&apos;evenement
    /// </summary>
    [Column("libelle")]
    [StringLength(254)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Lieu ou se deroule l&apos;evenement
    /// </summary>
    [Column("lieu")]
    [StringLength(254)]
    public string? Lieu { get; set; }

    /// <summary>
    /// Montant statutaire prevu annuellement pourl&apos;evenement
    /// </summary>
    [Column("montanttotalevt")]
    public decimal Montanttotalevt { get; set; }

    /// <summary>
    /// Montant dedie au deplacement des membres
    /// </summary>
    [Column("montantroute")]
    public decimal Montantroute { get; set; }

    /// <summary>
    /// Liste des membres designes pour le deplacement
    /// </summary>
    [Column("listemandataires")]
    [StringLength(254)]
    public string? Listemandataires { get; set; }

    [ForeignKey("Idevts")]
    [InverseProperty("Aide")]
    public virtual Sortiecaisse IdevtsNavigation { get; set; } = null!;
}
