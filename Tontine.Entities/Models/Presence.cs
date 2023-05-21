using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Represente l&apos;etat des presences des membres a une seance de reunion et l&apos;ensemble des signatures apposees par les membres (beneficiaire et bureau) de l&apos;association sur un document
/// </summary>
[Table("presence", Schema = "tontine")]
[Index("Idinscrit", Name = "association_13_fk")]
[Index("Idannee", "Iddivision", Name = "association_14_fk")]
[Index("Idmode", Name = "association_18_fk")]
[Index("Idcompte", Name = "association_29_fk")]
[Index("Idpresence", Name = "presence_pk", IsUnique = true)]
public partial class Presence
{
    /// <summary>
    /// Identiifant de la signature
    /// </summary>
    [Key]
    [Column("idpresence")]
    public int Idpresence { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Column("idannee")]
    public int Idannee { get; set; }

    /// <summary>
    /// Identifiant de la division
    /// </summary>
    [Column("iddivision")]
    public int Iddivision { get; set; }

    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    [Column("idinscrit")]
    public int Idinscrit { get; set; }

    /// <summary>
    /// Idcompte
    /// </summary>
    [Column("idcompte")]
    public int? Idcompte { get; set; }

    /// <summary>
    /// Identifiant du mode de paiement
    /// </summary>
    [Column("idmode")]
    public int Idmode { get; set; }

    /// <summary>
    /// Dateop
    /// </summary>
    [Column("dateop")]
    public DateOnly Dateop { get; set; }

    /// <summary>
    /// isabsent
    /// </summary>
    [Column("isabsent")]
    public bool? Isabsent { get; set; }

    /// <summary>
    /// globalverse
    /// </summary>
    [Column("globalverse")]
    public decimal? Globalverse { get; set; }

    /// <summary>
    /// Soldedebut
    /// </summary>
    [Column("soldedebut")]
    public decimal? Soldedebut { get; set; }

    /// <summary>
    /// Soldefin
    /// </summary>
    [Column("soldefin")]
    public decimal? Soldefin { get; set; }

    /// <summary>
    /// CumulDetteApres
    /// </summary>
    [Column("cumuldetteapres")]
    public decimal? Cumuldetteapres { get; set; }

    /// <summary>
    /// Indique le tupe d&apos;operation (Entree ou Sortie de caisse)
    /// </summary>
    [Column("codeop")]
    public int Codeop { get; set; }

    /// <summary>
    /// Numbordero
    /// </summary>
    [Column("numbordero")]
    [StringLength(254)]
    public string? Numbordero { get; set; }

    [InverseProperty("IdpresenceNavigation")]
    public virtual ICollection<Entreecaisse> Entreecaisses { get; set; } = new List<Entreecaisse>();

    [ForeignKey("Idannee, Iddivision")]
    [InverseProperty("Presences")]
    public virtual Monthlyseance Id { get; set; } = null!;

    [ForeignKey("Idcompte")]
    [InverseProperty("Presences")]
    public virtual CoreBankaccount? IdcompteNavigation { get; set; }

    [ForeignKey("Idinscrit")]
    [InverseProperty("Presences")]
    public virtual Inscription IdinscritNavigation { get; set; } = null!;

    [ForeignKey("Idmode")]
    [InverseProperty("Presences")]
    public virtual Modepaie IdmodeNavigation { get; set; } = null!;
}
