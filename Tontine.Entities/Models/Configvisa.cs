using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Represente l&apos;ensemble des autorisatios de signature de documents au sein de l&apos;association
/// </summary>
[Table("configvisas", Schema = "tontine")]
[Index("Idannee", Name = "association_6_fk")]
[Index("Idposte", Name = "association_7_fk")]
[Index("Idtype", Name = "association_8_fk2")]
[Index("Idconfigvisa", Name = "configvisas_pk", IsUnique = true)]
public partial class Configvisa
{
    /// <summary>
    /// Identifiant de la configuration de signature
    /// </summary>
    [Key]
    [Column("idconfigvisa")]
    public int Idconfigvisa { get; set; }

    /// <summary>
    /// Idposte
    /// </summary>
    [Column("idposte")]
    public int Idposte { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Column("idannee")]
    public int Idannee { get; set; }

    /// <summary>
    /// Identifiant du type d&apos;evenement
    /// </summary>
    [Column("idtype")]
    public int Idtype { get; set; }

    /// <summary>
    /// Numero d&apos;ordre de la signature pour un type de document
    /// </summary>
    [Column("numordre")]
    public int Numordre { get; set; }

    [ForeignKey("Idannee")]
    [InverseProperty("Configvisas")]
    public virtual CoreAnnee IdanneeNavigation { get; set; } = null!;

    [ForeignKey("Idposte")]
    [InverseProperty("Configvisas")]
    public virtual Poste IdposteNavigation { get; set; } = null!;

    [ForeignKey("Idtype")]
    [InverseProperty("Configvisas")]
    public virtual Rubrique IdtypeNavigation { get; set; } = null!;

    [InverseProperty("IdconfigvisaNavigation")]
    public virtual ICollection<Visa> Visas { get; set; } = new List<Visa>();
}
