using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models;

/// <summary>
/// Represente l&apos;etat des presences des membres a une seance de reunion et l&apos;ensemble des signatures apposees par les membres (beneficiaire et bureau) de l&apos;association sur un document
/// </summary>
public partial class Presence
{
    /// <summary>
    /// Identiifant de la signature
    /// </summary>
    public int Idpresence { get; set; }

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
    public int Idinscrit { get; set; }

    /// <summary>
    /// Idcompte
    /// </summary>
    public int? Idcompte { get; set; }

    /// <summary>
    /// Identifiant du mode de paiement
    /// </summary>
    public int Idmode { get; set; }

    /// <summary>
    /// Dateop
    /// </summary>
    public DateOnly Dateop { get; set; }

    /// <summary>
    /// isabsent
    /// </summary>
    public bool? Isabsent { get; set; }

    /// <summary>
    /// globalverse
    /// </summary>
    public decimal? Globalverse { get; set; }

    /// <summary>
    /// Soldedebut
    /// </summary>
    public decimal? Soldedebut { get; set; }

    /// <summary>
    /// Soldefin
    /// </summary>
    public decimal? Soldefin { get; set; }

    /// <summary>
    /// CumulDetteApres
    /// </summary>
    public decimal? Cumuldetteapres { get; set; }

    /// <summary>
    /// Indique le tupe d&apos;operation (Entree ou Sortie de caisse)
    /// </summary>
    public int Codeop { get; set; }

    /// <summary>
    /// Numbordero
    /// </summary>
    public string? Numbordero { get; set; }

    public virtual ICollection<Entreecaisse> Entreecaisses { get; set; } = new List<Entreecaisse>();

    public virtual Monthlyseance Id { get; set; } = null!;

    public virtual CoreBankaccount? IdcompteNavigation { get; set; }

    public virtual Inscription IdinscritNavigation { get; set; } = null!;

    public virtual Modepaie IdmodeNavigation { get; set; } = null!;
}
