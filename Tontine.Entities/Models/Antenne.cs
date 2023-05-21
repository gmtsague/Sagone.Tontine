using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Represente ue antenne de l&apos;association
/// </summary>
[Table("antenne", Schema = "tontine")]
[Index("Idantenne", Name = "antenne_pk", IsUnique = true)]
public partial class Antenne
{
    /// <summary>
    /// Identifiant de l&apos;antenne
    /// </summary>
    [Key]
    [Column("idantenne")]
    public int Idantenne { get; set; }

    /// <summary>
    /// Libelle de l&apos;antenne
    /// </summary>
    [Column("libelle")]
    [StringLength(254)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Date de creation de l&apos;antenne
    /// </summary>
    [Column("creationdate")]
    public DateOnly? Creationdate { get; set; }

    [InverseProperty("IdantenneNavigation")]
    public virtual ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();
}
