using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models;

/// <summary>
/// SortieCaisse
/// </summary>
public partial class Sortiecaisse
{
    /// <summary>
    /// Idevts
    /// </summary>
    public int Idevts { get; set; }

    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    public int? Idinscrit { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int Idannee { get; set; }

    /// <summary>
    /// Identifiant de la division
    /// </summary>
    public int Iddivision { get; set; }

    /// <summary>
    /// Identifiant d&apos;une configuration
    /// </summary>
    public int Idconfig { get; set; }

    /// <summary>
    /// Date effective a laquelle a lieu l&apos;evenement
    /// </summary>
    public DateOnly Dateevts { get; set; }

    /// <summary>
    /// Indique que l&apos;evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)
    /// </summary>
    public bool Isclosed { get; set; }

    /// <summary>
    /// Montant percu par le beneficiaire de l&apos;evenement
    /// </summary>
    public decimal? Montantpercu { get; set; }

    /// <summary>
    /// Observation generale concernant le deroulement de l&apos;evenement
    /// </summary>
    public string? Note { get; set; }

    /// <summary>
    /// Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.
    /// </summary>
    public int Visarestants { get; set; }

    public virtual Aide? Aide { get; set; }

    public virtual ICollection<Entreecaisse> Entreecaisses { get; set; } = new List<Entreecaisse>();

    public virtual Monthlyseance Id { get; set; } = null!;

    public virtual Annualengagement IdconfigNavigation { get; set; } = null!;

    public virtual Inscription? IdinscritNavigation { get; set; }

    public virtual Pret? Pret { get; set; }

    public virtual ICollection<Visa> Visas { get; set; } = new List<Visa>();
}
