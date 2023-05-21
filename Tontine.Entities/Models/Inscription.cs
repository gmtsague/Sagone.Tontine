using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Represente le renoouvellement de la presence d&apos;un membre au sein de &apos;association au cours d&apos;une annee
/// </summary>
[Table("inscription", Schema = "tontine")]
[Index("Idposte", Name = "association_23_fk")]
[Index("Idantenne", Name = "association_3_fk")]
[Index("Idperson", Name = "association_4_fk")]
[Index("Idannee", Name = "association_5_fk")]
[Index("Idinscrit", Name = "inscription_pk", IsUnique = true)]
public partial class Inscription
{
    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    [Key]
    [Column("idinscrit")]
    public int Idinscrit { get; set; }

    /// <summary>
    /// Identifiant de l&apos;antenne
    /// </summary>
    [Column("idantenne")]
    public int Idantenne { get; set; }

    /// <summary>
    /// Idposte
    /// </summary>
    [Column("idposte")]
    public int Idposte { get; set; }

    /// <summary>
    /// Idperson
    /// </summary>
    [Column("idperson")]
    public int Idperson { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Column("idannee")]
    public int Idannee { get; set; }

    /// <summary>
    /// Date de l&apos;inscription
    /// </summary>
    [Column("dateinscrit")]
    public DateOnly Dateinscrit { get; set; }

    /// <summary>
    /// Date de derniere suspension d&apos;un membre
    /// </summary>
    [Column("datesuspension")]
    public DateOnly? Datesuspension { get; set; }

    /// <summary>
    /// Statut actif ou non d&apos;un membre
    /// </summary>
    [Column("isactive")]
    public bool Isactive { get; set; }

    /// <summary>
    /// Nocni
    /// </summary>
    [Column("nocni")]
    [StringLength(254)]
    public string Nocni { get; set; } = null!;

    /// <summary>
    /// SoldeDebut
    /// </summary>
    [Column("soldedebut")]
    public decimal Soldedebut { get; set; }

    /// <summary>
    /// SoldeFin
    /// </summary>
    [Column("soldefin")]
    public decimal? Soldefin { get; set; }

    /// <summary>
    /// Report a nouveau du membre pour la nouvelle annee
    /// </summary>
    [Column("tauxcotisation")]
    public decimal Tauxcotisation { get; set; }

    /// <summary>
    /// Totalverse
    /// </summary>
    [Column("totalverse")]
    public decimal Totalverse { get; set; }

    /// <summary>
    /// Dettes cumulees applicable la nouvelle annee
    /// </summary>
    [Column("cumuldettes")]
    public decimal? Cumuldettes { get; set; }

    /// <summary>
    /// Dettes cumules de penelites applicable la nouvelle annee
    /// </summary>
    [Column("cumulpenalites")]
    public decimal? Cumulpenalites { get; set; }

    /// <summary>
    /// Indique si le membre est endette
    /// </summary>
    [Column("endette")]
    public bool Endette { get; set; }

    [ForeignKey("Idannee")]
    [InverseProperty("Inscriptions")]
    public virtual CoreAnnee IdanneeNavigation { get; set; } = null!;

    [ForeignKey("Idantenne")]
    [InverseProperty("Inscriptions")]
    public virtual Antenne IdantenneNavigation { get; set; } = null!;

    [ForeignKey("Idperson")]
    [InverseProperty("Inscriptions")]
    public virtual CorePerson IdpersonNavigation { get; set; } = null!;

    [ForeignKey("Idposte")]
    [InverseProperty("Inscriptions")]
    public virtual Poste IdposteNavigation { get; set; } = null!;

    [InverseProperty("IdinscritNavigation")]
    public virtual ICollection<Monthlyseance> Monthlyseances { get; set; } = new List<Monthlyseance>();

    [InverseProperty("IdinscritNavigation")]
    public virtual ICollection<Presence> Presences { get; set; } = new List<Presence>();

    [InverseProperty("IdinscritNavigation")]
    public virtual ICollection<Sortiecaisse> Sortiecaisses { get; set; } = new List<Sortiecaisse>();

    [InverseProperty("IdinscritNavigation")]
    public virtual ICollection<Visa> Visas { get; set; } = new List<Visa>();
}
