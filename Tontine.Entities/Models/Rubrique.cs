using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Represente un type d&apos;evenements par exemple Mariage, Deces, Naissance, Cotisation, Decaissement ponctuel, etc.
/// </summary>
[Table("rubrique", Schema = "tontine")]
[Index("Idtype", Name = "rubrique_pk", IsUnique = true)]
public partial class Rubrique
{
    /// <summary>
    /// Identifiant du type d&apos;evenement
    /// </summary>
    [Key]
    [Column("idtype")]
    public int Idtype { get; set; }

    /// <summary>
    /// Libelle du type d&apos;evenement
    /// </summary>
    [Column("libelle")]
    [StringLength(254)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Indique si le type represente la cotisation
    /// </summary>
    [Column("iscotisation")]
    public bool Iscotisation { get; set; }

    /// <summary>
    /// Indique si le type d&apos;evenement est un pret
    /// </summary>
    [Column("ispret")]
    public bool? Ispret { get; set; }

    /// <summary>
    /// IsAide
    /// </summary>
    [Column("isaide")]
    public bool Isaide { get; set; }

    /// <summary>
    /// IsFondEntraide
    /// </summary>
    [Column("isfondentraide")]
    public bool Isfondentraide { get; set; }

    /// <summary>
    /// Isdepense
    /// </summary>
    [Column("isdepense")]
    public bool Isdepense { get; set; }

    /// <summary>
    /// CanDelete
    /// </summary>
    [Column("candelete")]
    public bool Candelete { get; set; }

    /// <summary>
    /// Nombre de signatures autorises pour signer un documents associe a ce type devenement
    /// </summary>
    [Column("maxsignature")]
    public int Maxsignature { get; set; }

    [InverseProperty("IdtypeNavigation")]
    public virtual ICollection<Annualengagement> Annualengagements { get; set; } = new List<Annualengagement>();

    [InverseProperty("IdtypeNavigation")]
    public virtual ICollection<Configvisa> Configvisas { get; set; } = new List<Configvisa>();
}
