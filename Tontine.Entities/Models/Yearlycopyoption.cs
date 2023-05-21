using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// yearlycopyoption
/// </summary>
[Table("yearlycopyoption", Schema = "tontine")]
[Index("Idannee", Name = "association_37_fk")]
[Index("Idcopyoption", Name = "yearlycopyoption_pk", IsUnique = true)]
public partial class Yearlycopyoption
{
    /// <summary>
    /// Idcopyoption
    /// </summary>
    [Key]
    [Column("idcopyoption")]
    public int Idcopyoption { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Column("idannee")]
    public int Idannee { get; set; }

    /// <summary>
    /// Previousyear
    /// </summary>
    [Column("previousyear")]
    public int Previousyear { get; set; }

    /// <summary>
    /// CopyEngagements
    /// </summary>
    [Column("copyengagements")]
    public bool Copyengagements { get; set; }

    /// <summary>
    /// CopyMembers
    /// </summary>
    [Column("copymembers")]
    public bool Copymembers { get; set; }

    [ForeignKey("Idannee")]
    [InverseProperty("Yearlycopyoptions")]
    public virtual CoreAnnee IdanneeNavigation { get; set; } = null!;
}
