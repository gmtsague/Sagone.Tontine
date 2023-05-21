using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Poste occupe par un membre de l&apos;association
/// </summary>
[Table("poste", Schema = "tontine")]
[Index("Idposte", Name = "poste_pk", IsUnique = true)]
public partial class Poste
{
    /// <summary>
    /// Idposte
    /// </summary>
    [Key]
    [Column("idposte")]
    public int Idposte { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    [Column("libelle")]
    [StringLength(254)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Ispresident
    /// </summary>
    [Column("ispresident")]
    public bool Ispresident { get; set; }

    /// <summary>
    /// Istresorier
    /// </summary>
    [Column("istresorier")]
    public bool Istresorier { get; set; }

    /// <summary>
    /// Issg
    /// </summary>
    [Column("issg")]
    public bool Issg { get; set; }

    /// <summary>
    /// Issga
    /// </summary>
    [Column("issga")]
    public bool Issga { get; set; }

    /// <summary>
    /// Iscc
    /// </summary>
    [Column("iscc")]
    public bool Iscc { get; set; }

    /// <summary>
    /// Ismembre
    /// </summary>
    [Column("ismembre")]
    public bool Ismembre { get; set; }

    [InverseProperty("IdposteNavigation")]
    public virtual ICollection<Configvisa> Configvisas { get; set; } = new List<Configvisa>();

    [InverseProperty("IdposteNavigation")]
    public virtual ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
}
