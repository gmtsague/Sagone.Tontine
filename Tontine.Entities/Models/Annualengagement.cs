using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models;

/// <summary>
/// Represente la personnalisation de certaines valeurs appliquees aux types d&apos;eveneents au cours d&apos;une annee
/// </summary>
[Table("annualengagements", Schema = "tontine")]
[Index("Idconfig", Name = "annualengagements_pk", IsUnique = true)]
[Index("Idtype", Name = "association_10_fk")]
[Index("Idannee", Name = "association_9_fk")]
public partial class Annualengagement
{
    /// <summary>
    /// Identifiant d&apos;une configuration
    /// </summary>
    [Key]
    [Column("idconfig")]
    public int Idconfig { get; set; }

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
    /// Montant de l&apos;evenement
    /// </summary>
    [Column("montantevt")]
    public decimal Montantevt { get; set; }

    /// <summary>
    /// Isactive
    /// </summary>
    [Required]
    [Column("isactive")]
    public bool? Isactive { get; set; }

    /// <summary>
    /// Nombre de membres representant l&apos;asociation a l&apos;evenement
    /// </summary>
    [Column("nbmandataire")]
    public int Nbmandataire { get; set; }

    /// <summary>
    /// Montant du deplacement d&apos;un membre mandate par l&apos;association
    /// </summary>
    [Column("montantroute")]
    public decimal Montantroute { get; set; }

    /// <summary>
    /// Montant total associe a l&apos;evenement
    /// </summary>
    [Column("montanttotal")]
    public decimal Montanttotal { get; set; }

    /// <summary>
    /// Montant de la penalite applicable en cas d&apos;absence aa l&apos;evenement
    /// </summary>
    [Column("montantpenalite")]
    public decimal Montantpenalite { get; set; }

    /// <summary>
    /// Taux d&apos;interet mensuel
    /// </summary>
    [Column("interetmensuel")]
    public decimal? Interetmensuel { get; set; }

    /// <summary>
    /// Taux d&apos;interet applicable en cas de penalite
    /// </summary>
    [Column("tauxpenalite")]
    public decimal? Tauxpenalite { get; set; }

    /// <summary>
    /// IsAide
    /// </summary>
    [Column("isaide")]
    public bool Isaide { get; set; }

    /// <summary>
    /// Indique si le type represente la cotisation
    /// </summary>
    [Column("iscotisation")]
    public bool Iscotisation { get; set; }

    /// <summary>
    /// Isdepense
    /// </summary>
    [Column("isdepense")]
    public bool Isdepense { get; set; }

    /// <summary>
    /// IsFondEntraide
    /// </summary>
    [Column("isfondentraide")]
    public bool Isfondentraide { get; set; }

    /// <summary>
    /// Indique si le type d&apos;evenement est un pret
    /// </summary>
    [Column("ispret")]
    public bool? Ispret { get; set; }

    /// <summary>
    /// Commentaire
    /// </summary>
    [Column("commentaire")]
    [StringLength(254)]
    public string? Commentaire { get; set; }

    /// <summary>
    /// Numero determinant le type d&apos;evenement/engagement
    /// </summary>
    [Column("categorie")]
    public int Categorie { get; set; }

    [InverseProperty("IdconfigNavigation")]
    public virtual ICollection<Entreecaisse> Entreecaisses { get; set; } = new List<Entreecaisse>();

    [ForeignKey("Idannee")]
    [InverseProperty("Annualengagements")]
    public virtual CoreAnnee IdanneeNavigation { get; set; } = null!;

    [ForeignKey("Idtype")]
    [InverseProperty("Annualengagements")]
    public virtual Rubrique IdtypeNavigation { get; set; } = null!;

    [InverseProperty("IdconfigNavigation")]
    public virtual ICollection<Sortiecaisse> Sortiecaisses { get; set; } = new List<Sortiecaisse>();
}
