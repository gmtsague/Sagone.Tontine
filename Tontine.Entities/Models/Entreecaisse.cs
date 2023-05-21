using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Entreecaisse
/// </summary>
[Table("entreecaisse", Schema = "tontine")]
[Index("Idpresence", Name = "association_20_fk")]
[Index("Idevts", Name = "association_21_fk")]
[Index("Idconfig", Name = "association_2_fk")]
[Index("Idoperation", Name = "entreecaisse_pk", IsUnique = true)]
public partial class Entreecaisse
{
    /// <summary>
    /// Idoperation
    /// </summary>
    [Key]
    [Column("idoperation")]
    public int Idoperation { get; set; }

    /// <summary>
    /// Idevts
    /// </summary>
    [Column("idevts")]
    public int? Idevts { get; set; }

    /// <summary>
    /// Identiifant de la signature
    /// </summary>
    [Column("idpresence")]
    public int Idpresence { get; set; }

    /// <summary>
    /// Identifiant d&apos;une configuration
    /// </summary>
    [Column("idconfig")]
    public int? Idconfig { get; set; }

    /// <summary>
    /// MontantVerse
    /// </summary>
    [Column("montantverse")]
    public decimal Montantverse { get; set; }

    /// <summary>
    /// CumulVerse
    /// </summary>
    [Column("cumulverse")]
    public decimal? Cumulverse { get; set; }

    /// <summary>
    /// Reste
    /// </summary>
    [Column("reste")]
    public decimal? Reste { get; set; }

    [ForeignKey("Idconfig")]
    [InverseProperty("Entreecaisses")]
    public virtual Annualengagement? IdconfigNavigation { get; set; }

    [ForeignKey("Idevts")]
    [InverseProperty("Entreecaisses")]
    public virtual Sortiecaisse? IdevtsNavigation { get; set; }

    [ForeignKey("Idpresence")]
    [InverseProperty("Entreecaisses")]
    public virtual Presence IdpresenceNavigation { get; set; } = null!;
}
