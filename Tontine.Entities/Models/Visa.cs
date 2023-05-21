using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Visas
/// </summary>
[Table("visas", Schema = "tontine")]
[Index("Idconfigvisa", Name = "association_15_fk")]
[Index("Idevts", Name = "association_22_fk")]
[Index("Idannee", "Iddivision", Name = "association_25_fk")]
[Index("Idinscrit", Name = "association_26_fk")]
[Index("Idvisa", Name = "visas_pk", IsUnique = true)]
public partial class Visa
{
    /// <summary>
    /// Identiifant de la signature
    /// </summary>
    [Key]
    [Column("idvisa")]
    public int Idvisa { get; set; }

    /// <summary>
    /// Idevts
    /// </summary>
    [Column("idevts")]
    public int? Idevts { get; set; }

    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    [Column("idinscrit")]
    public int Idinscrit { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Column("idannee")]
    public int? Idannee { get; set; }

    /// <summary>
    /// Identifiant de la division
    /// </summary>
    [Column("iddivision")]
    public int? Iddivision { get; set; }

    /// <summary>
    /// Identifiant de la configuration de signature
    /// </summary>
    [Column("idconfigvisa")]
    public int Idconfigvisa { get; set; }

    /// <summary>
    /// Date de signature
    /// </summary>
    [Column("datesign")]
    public DateOnly Datesign { get; set; }

    /// <summary>
    /// Indique si le document est signe par ordre
    /// </summary>
    [Column("parordre")]
    public bool Parordre { get; set; }

    /// <summary>
    /// Indique si le signataire est le beneficiare
    /// </summary>
    [Column("receiver")]
    public bool Receiver { get; set; }

    [ForeignKey("Idannee, Iddivision")]
    [InverseProperty("Visas")]
    public virtual Monthlyseance? Id { get; set; }

    [ForeignKey("Idconfigvisa")]
    [InverseProperty("Visas")]
    public virtual Configvisa IdconfigvisaNavigation { get; set; } = null!;

    [ForeignKey("Idevts")]
    [InverseProperty("Visas")]
    public virtual Sortiecaisse? IdevtsNavigation { get; set; }

    [ForeignKey("Idinscrit")]
    [InverseProperty("Visas")]
    public virtual Inscription IdinscritNavigation { get; set; } = null!;
}
