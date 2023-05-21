using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// SortieCaisse
/// </summary>
[Table("sortiecaisse", Schema = "tontine")]
[Index("Idannee", "Iddivision", Name = "association_11_fk")]
[Index("Idconfig", Name = "association_12_fk")]
[Index("Idinscrit", Name = "association_19_fk")]
[Index("Idevts", Name = "sortiecaisse_pk", IsUnique = true)]
public partial class Sortiecaisse
{
    /// <summary>
    /// Idevts
    /// </summary>
    [Key]
    [Column("idevts")]
    public int Idevts { get; set; }

    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    [Column("idinscrit")]
    public int? Idinscrit { get; set; }

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
    /// Identifiant d&apos;une configuration
    /// </summary>
    [Column("idconfig")]
    public int Idconfig { get; set; }

    /// <summary>
    /// Date effective a laquelle a lieu l&apos;evenement
    /// </summary>
    [Column("dateevts")]
    public DateOnly Dateevts { get; set; }

    /// <summary>
    /// Indique que l&apos;evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)
    /// </summary>
    [Column("isclosed")]
    public bool Isclosed { get; set; }

    /// <summary>
    /// Montant percu par le beneficiaire de l&apos;evenement
    /// </summary>
    [Column("montantpercu")]
    public decimal? Montantpercu { get; set; }

    /// <summary>
    /// Observation generale concernant le deroulement de l&apos;evenement
    /// </summary>
    [Column("note")]
    [StringLength(254)]
    public string? Note { get; set; }

    /// <summary>
    /// Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.
    /// </summary>
    [Column("visarestants")]
    public int Visarestants { get; set; }

    [InverseProperty("IdevtsNavigation")]
    public virtual Aide? Aide { get; set; }

    [InverseProperty("IdevtsNavigation")]
    public virtual ICollection<Entreecaisse> Entreecaisses { get; set; } = new List<Entreecaisse>();

    [ForeignKey("Idannee, Iddivision")]
    [InverseProperty("Sortiecaisses")]
    public virtual Monthlyseance Id { get; set; } = null!;

    [ForeignKey("Idconfig")]
    [InverseProperty("Sortiecaisses")]
    public virtual Annualengagement IdconfigNavigation { get; set; } = null!;

    [ForeignKey("Idinscrit")]
    [InverseProperty("Sortiecaisses")]
    public virtual Inscription? IdinscritNavigation { get; set; }

    [InverseProperty("IdevtsNavigation")]
    public virtual Pret? Pret { get; set; }

    [InverseProperty("IdevtsNavigation")]
    public virtual ICollection<Visa> Visas { get; set; } = new List<Visa>();
}
