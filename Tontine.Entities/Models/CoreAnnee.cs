using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Represente une annee 
/// </summary>
[Table("core_annee", Schema = "tontine")]
[Index("Idbureau", Name = "association_24_fk")]
[Index("Idannee", Name = "core_annee_pk", IsUnique = true)]
public partial class CoreAnnee
{
    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Key]
    [Column("idannee")]
    public int Idannee { get; set; }

    /// <summary>
    /// Idbureau
    /// </summary>
    [Column("idbureau")]
    public int? Idbureau { get; set; }

    /// <summary>
    /// Libelle de l&apos;annee
    /// </summary>
    [Column("libelle")]
    [StringLength(254)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Date de debut de l&apos;annee
    /// </summary>
    [Column("datedebut")]
    public DateOnly Datedebut { get; set; }

    /// <summary>
    /// Date de fin de l&apos;annee
    /// </summary>
    [Column("datefin")]
    public DateOnly Datefin { get; set; }

    /// <summary>
    /// Indique l&apos;annee de travail
    /// </summary>
    [Column("iscurrent")]
    public bool Iscurrent { get; set; }

    /// <summary>
    /// Indique que l&apos;annee et cloturee et ses donnees ne sont plus modifiables
    /// </summary>
    [Column("isclosed")]
    public bool Isclosed { get; set; }

    /// <summary>
    /// Nombre de divisions de l&apos;annee
    /// </summary>
    [Column("nbdivision")]
    public int Nbdivision { get; set; }

    [InverseProperty("IdanneeNavigation")]
    public virtual ICollection<Annualengagement> Annualengagements { get; set; } = new List<Annualengagement>();

    [InverseProperty("IdanneeNavigation")]
    public virtual ICollection<Configvisa> Configvisas { get; set; } = new List<Configvisa>();

    [InverseProperty("IdanneeNavigation")]
    public virtual ICollection<CoreAnnualetabparam> CoreAnnualetabparams { get; set; } = new List<CoreAnnualetabparam>();

    [ForeignKey("Idbureau")]
    [InverseProperty("CoreAnnees")]
    public virtual Bureau? IdbureauNavigation { get; set; }

    [InverseProperty("IdanneeNavigation")]
    public virtual ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();

    [InverseProperty("IdanneeNavigation")]
    public virtual ICollection<Monthlyseance> Monthlyseances { get; set; } = new List<Monthlyseance>();

    [InverseProperty("IdanneeNavigation")]
    public virtual ICollection<Yearlycopyoption> Yearlycopyoptions { get; set; } = new List<Yearlycopyoption>();
}
