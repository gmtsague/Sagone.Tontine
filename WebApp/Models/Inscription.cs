using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models;

/// <summary>
/// Represente le renoouvellement de la presence d&apos;un membre au sein de &apos;association au cours d&apos;une annee
/// </summary>
public partial class Inscription
{
    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    public int Idinscrit { get; set; }

    /// <summary>
    /// Identifiant de l&apos;antenne
    /// </summary>
    public int Idantenne { get; set; }

    /// <summary>
    /// Idposte
    /// </summary>
    public int Idposte { get; set; }

    /// <summary>
    /// Idperson
    /// </summary>
    public int Idperson { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int Idannee { get; set; }

    /// <summary>
    /// Date de l&apos;inscription
    /// </summary>
    public DateOnly Dateinscrit { get; set; }

    /// <summary>
    /// Date de derniere suspension d&apos;un membre
    /// </summary>
    public DateOnly? Datesuspension { get; set; }

    /// <summary>
    /// Statut actif ou non d&apos;un membre
    /// </summary>
    public bool Isactive { get; set; }

    /// <summary>
    /// Nocni
    /// </summary>
    public string Nocni { get; set; } = null!;

    /// <summary>
    /// SoldeDebut
    /// </summary>
    public decimal Soldedebut { get; set; }

    /// <summary>
    /// SoldeFin
    /// </summary>
    public decimal? Soldefin { get; set; }

    /// <summary>
    /// Report a nouveau du membre pour la nouvelle annee
    /// </summary>
    public decimal Tauxcotisation { get; set; }

    /// <summary>
    /// Totalverse
    /// </summary>
    public decimal Totalverse { get; set; }

    /// <summary>
    /// Dettes cumulees applicable la nouvelle annee
    /// </summary>
    public decimal? Cumuldettes { get; set; }

    /// <summary>
    /// Dettes cumules de penelites applicable la nouvelle annee
    /// </summary>
    public decimal? Cumulpenalites { get; set; }

    /// <summary>
    /// Indique si le membre est endette
    /// </summary>
    public bool Endette { get; set; }

    public virtual CoreAnnee IdanneeNavigation { get; set; } = null!;

    public virtual Antenne IdantenneNavigation { get; set; } = null!;

    public virtual CorePerson IdpersonNavigation { get; set; } = null!;

    public virtual Poste IdposteNavigation { get; set; } = null!;

    public virtual ICollection<Monthlyseance> Monthlyseances { get; set; } = new List<Monthlyseance>();

    public virtual ICollection<Presence> Presences { get; set; } = new List<Presence>();

    public virtual ICollection<Sortiecaisse> Sortiecaisses { get; set; } = new List<Sortiecaisse>();

    public virtual ICollection<Visa> Visas { get; set; } = new List<Visa>();
}
