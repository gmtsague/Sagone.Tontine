using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Pret
/// </summary>
[Table("pret", Schema = "tontine")]
[Index("Idevts", Name = "pret_pk", IsUnique = true)]
public partial class Pret
{
    /// <summary>
    /// Idevts
    /// </summary>
    [Key]
    [Column("idevts")]
    public int Idevts { get; set; }

    /// <summary>
    /// Indique si l&apos;evenement est un pret
    /// </summary>
    [Column("ispret")]
    public bool Ispret { get; set; }

    /// <summary>
    /// Duree du pret en nombre de mois
    /// </summary>
    [Column("dureepret")]
    public int Dureepret { get; set; }

    /// <summary>
    /// Montant de l&apos;interet
    /// </summary>
    [Column("montantinteret")]
    public decimal Montantinteret { get; set; }

    /// <summary>
    /// Montant applicable en cas de penalite sur les interets ou en cas d&apos;absence de cotisation
    /// </summary>
    [Column("montantpenalite")]
    public decimal Montantpenalite { get; set; }

    [ForeignKey("Idevts")]
    [InverseProperty("Pret")]
    public virtual Sortiecaisse IdevtsNavigation { get; set; } = null!;
}
