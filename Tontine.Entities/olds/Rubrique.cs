using System;
using System.Collections.Generic;

namespace Tontine.Entities.olds;

/// <summary>
/// Represente un type d&apos;evenements par exemple Mariage, Deces, Naissance, Cotisation, Decaissement ponctuel, etc.
/// </summary>
public partial class Rubrique
{
    /// <summary>
    /// Identifiant du type d&apos;evenement
    /// </summary>
    public int Idtype { get; set; }

    /// <summary>
    /// Libelle du type d&apos;evenement
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Indique si le type represente la cotisation
    /// </summary>
    public bool Iscotisation { get; set; }

    /// <summary>
    /// Indique si le type d&apos;evenement est un pret
    /// </summary>
    public bool? Ispret { get; set; }

    /// <summary>
    /// IsAide
    /// </summary>
    public bool Isaide { get; set; }

    /// <summary>
    /// IsFondEntraide
    /// </summary>
    public bool Isfondentraide { get; set; }

    /// <summary>
    /// Isdepense
    /// </summary>
    public bool Isdepense { get; set; }

    /// <summary>
    /// CanDelete
    /// </summary>
    public bool Candelete { get; set; }

    /// <summary>
    /// Nombre de signatures autorises pour signer un documents associe a ce type devenement
    /// </summary>
    public int Maxsignature { get; set; }

    public virtual ICollection<Annualengagement> Annualengagements { get; set; } = new List<Annualengagement>();

    public virtual ICollection<Configvisa> Configvisas { get; set; } = new List<Configvisa>();
}
