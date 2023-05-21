using System;
using System.Collections.Generic;

namespace Tontine.Entities.olds;

/// <summary>
/// Represente la personnalisation de certaines valeurs appliquees aux types d&apos;eveneents au cours d&apos;une annee
/// </summary>
public partial class Annualengagement
{
    /// <summary>
    /// Identifiant d&apos;une configuration
    /// </summary>
    public int Idconfig { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int Idannee { get; set; }

    /// <summary>
    /// Identifiant du type d&apos;evenement
    /// </summary>
    public int Idtype { get; set; }

    /// <summary>
    /// Montant de l&apos;evenement
    /// </summary>
    public decimal Montantevt { get; set; }

    /// <summary>
    /// Isactive
    /// </summary>
    public bool? Isactive { get; set; }

    /// <summary>
    /// Nombre de membres representant l&apos;asociation a l&apos;evenement
    /// </summary>
    public int Nbmandataire { get; set; }

    /// <summary>
    /// Montant du deplacement d&apos;un membre mandate par l&apos;association
    /// </summary>
    public decimal Montantroute { get; set; }

    /// <summary>
    /// Montant total associe a l&apos;evenement
    /// </summary>
    public decimal Montanttotal { get; set; }

    /// <summary>
    /// Montant de la penalite applicable en cas d&apos;absence aa l&apos;evenement
    /// </summary>
    public decimal Montantpenalite { get; set; }

    /// <summary>
    /// Taux d&apos;interet mensuel
    /// </summary>
    public decimal? Interetmensuel { get; set; }

    /// <summary>
    /// Taux d&apos;interet applicable en cas de penalite
    /// </summary>
    public decimal? Tauxpenalite { get; set; }

    /// <summary>
    /// IsAide
    /// </summary>
    public bool Isaide { get; set; }

    /// <summary>
    /// Indique si le type represente la cotisation
    /// </summary>
    public bool Iscotisation { get; set; }

    /// <summary>
    /// Isdepense
    /// </summary>
    public bool Isdepense { get; set; }

    /// <summary>
    /// IsFondEntraide
    /// </summary>
    public bool Isfondentraide { get; set; }

    /// <summary>
    /// Indique si le type d&apos;evenement est un pret
    /// </summary>
    public bool? Ispret { get; set; }

    /// <summary>
    /// Commentaire
    /// </summary>
    public string? Commentaire { get; set; }

    /// <summary>
    /// Numero determinant le type d&apos;evenement/engagement
    /// </summary>
    public int Categorie { get; set; }

    public virtual ICollection<Entreecaisse> Entreecaisses { get; set; } = new List<Entreecaisse>();

    public virtual CoreAnnee IdanneeNavigation { get; set; } = null!;

    public virtual Rubrique IdtypeNavigation { get; set; } = null!;

    public virtual ICollection<Sortiecaisse> Sortiecaisses { get; set; } = new List<Sortiecaisse>();
}
