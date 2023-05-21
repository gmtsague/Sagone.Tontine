using System;
using System.Collections.Generic;

namespace Tontine.Entities.olds;

/// <summary>
/// Represente le decoupage mensuel de l&apos;annee
/// </summary>
public partial class Monthlyseance
{
    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int Idannee { get; set; }

    /// <summary>
    /// Identifiant de la division
    /// </summary>
    public int Iddivision { get; set; }

    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    public int? Idinscrit { get; set; }

    /// <summary>
    /// Date de debut de la division
    /// </summary>
    public DateOnly Dateseance { get; set; }

    /// <summary>
    /// HeureDebut
    /// </summary>
    public DateOnly? Heuredebut { get; set; }

    /// <summary>
    /// Libelle de la division
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Numero d&apos;ordre de la division
    /// </summary>
    public int Numordre { get; set; }

    /// <summary>
    /// TotalCotise
    /// </summary>
    public decimal Totalcotise { get; set; }

    /// <summary>
    /// TotalSortie
    /// </summary>
    public decimal Totalsortie { get; set; }

    /// <summary>
    /// MontantPercu
    /// </summary>
    public decimal Montantpercu { get; set; }

    /// <summary>
    /// Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.
    /// </summary>
    public int Visarestants { get; set; }

    public virtual CoreAnnee IdanneeNavigation { get; set; } = null!;

    public virtual Inscription? IdinscritNavigation { get; set; }

    public virtual ICollection<Presence> Presences { get; set; } = new List<Presence>();

    public virtual ICollection<Sortiecaisse> Sortiecaisses { get; set; } = new List<Sortiecaisse>();

    public virtual ICollection<Visa> Visas { get; set; } = new List<Visa>();
}
