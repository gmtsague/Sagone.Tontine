using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Bureau
/// </summary>
[Table("bureau", Schema = "tontine")]
[Index("Idbureau", Name = "bureau_pk", IsUnique = true)]
public partial class Bureau
{
    /// <summary>
    /// Idbureau
    /// </summary>
    [Key]
    [Column("idbureau")]
    public int Idbureau { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    [Column("libelle")]
    [StringLength(254)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Debut
    /// </summary>
    [Column("debut")]
    public DateOnly Debut { get; set; }

    /// <summary>
    /// Fin
    /// </summary>
    [Column("fin")]
    public DateOnly Fin { get; set; }

    /// <summary>
    /// Nbperson
    /// </summary>
    [Column("nbperson")]
    public int? Nbperson { get; set; }

    /// <summary>
    /// Nbvotes
    /// </summary>
    [Column("nbvotes")]
    public int? Nbvotes { get; set; }

    /// <summary>
    /// NbAbstention
    /// </summary>
    [Column("nbabstention")]
    public int? Nbabstention { get; set; }

    [InverseProperty("IdbureauNavigation")]
    public virtual ICollection<CoreAnnee> CoreAnnees { get; set; } = new List<CoreAnnee>();
}
