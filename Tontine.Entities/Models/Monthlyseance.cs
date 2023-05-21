using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Represente le decoupage mensuel de l&apos;annee
/// </summary>
[PrimaryKey("Idannee", "Iddivision")]
[Table("monthlyseance", Schema = "tontine")]
[Index("Idinscrit", Name = "association_16_fk")]
[Index("Idannee", Name = "association_1_fk")]
[Index("Idannee", "Iddivision", Name = "monthlyseance_pk", IsUnique = true)]
public partial class Monthlyseance
{
    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Key]
    [Column("idannee")]
    public int Idannee { get; set; }

    /// <summary>
    /// Identifiant de la division
    /// </summary>
    [Key]
    [Column("iddivision")]
    public int Iddivision { get; set; }

    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    [Column("idinscrit")]
    public int? Idinscrit { get; set; }

    /// <summary>
    /// Date de debut de la division
    /// </summary>
    [Column("dateseance")]
    public DateOnly Dateseance { get; set; }

    /// <summary>
    /// HeureDebut
    /// </summary>
    [Column("heuredebut")]
    public DateOnly? Heuredebut { get; set; }

    /// <summary>
    /// Libelle de la division
    /// </summary>
    [Column("libelle")]
    [StringLength(254)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Numero d&apos;ordre de la division
    /// </summary>
    [Column("numordre")]
    public int Numordre { get; set; }

    /// <summary>
    /// TotalCotise
    /// </summary>
    [Column("totalcotise")]
    public decimal Totalcotise { get; set; }

    /// <summary>
    /// TotalSortie
    /// </summary>
    [Column("totalsortie")]
    public decimal Totalsortie { get; set; }

    /// <summary>
    /// MontantPercu
    /// </summary>
    [Column("montantpercu")]
    public decimal Montantpercu { get; set; }

    /// <summary>
    /// Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.
    /// </summary>
    [Column("visarestants")]
    public int Visarestants { get; set; }

    [ForeignKey("Idannee")]
    [InverseProperty("Monthlyseances")]
    public virtual CoreAnnee IdanneeNavigation { get; set; } = null!;

    [ForeignKey("Idinscrit")]
    [InverseProperty("Monthlyseances")]
    public virtual Inscription? IdinscritNavigation { get; set; }

    [InverseProperty("Id")]
    public virtual ICollection<Presence> Presences { get; set; } = new List<Presence>();

    [InverseProperty("Id")]
    public virtual ICollection<Sortiecaisse> Sortiecaisses { get; set; } = new List<Sortiecaisse>();

    [InverseProperty("Id")]
    public virtual ICollection<Visa> Visas { get; set; } = new List<Visa>();
}
