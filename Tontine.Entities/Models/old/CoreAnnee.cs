using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models;

/// <summary>
/// Represente une annee 
/// </summary>
public partial class CoreAnnee
{
    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int Idannee { get; set; }

    /// <summary>
    /// Idbureau
    /// </summary>
    public int? Idbureau { get; set; }

    /// <summary>
    /// Libelle de l&apos;annee
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Date de debut de l&apos;annee
    /// </summary>
    public DateOnly Datedebut { get; set; }

    /// <summary>
    /// Date de fin de l&apos;annee
    /// </summary>
    public DateOnly Datefin { get; set; }

    /// <summary>
    /// Indique l&apos;annee de travail
    /// </summary>
    public bool Iscurrent { get; set; }

    /// <summary>
    /// Indique que l&apos;annee et cloturee et ses donnees ne sont plus modifiables
    /// </summary>
    public bool Isclosed { get; set; }

    /// <summary>
    /// Nombre de divisions de l&apos;annee
    /// </summary>
    public int Nbdivision { get; set; }

    public virtual ICollection<Annualengagement> Annualengagements { get; set; } = new List<Annualengagement>();

    public virtual ICollection<Configvisa> Configvisas { get; set; } = new List<Configvisa>();

    public virtual ICollection<CoreAnnualetabparam> CoreAnnualetabparams { get; set; } = new List<CoreAnnualetabparam>();

    public virtual Bureau? IdbureauNavigation { get; set; }

    public virtual ICollection<Inscription> Inscriptions { get; set; } = new List<Inscription>();

    public virtual ICollection<Monthlyseance> Monthlyseances { get; set; } = new List<Monthlyseance>();

    public virtual ICollection<Yearlycopyoption> Yearlycopyoptions { get; set; } = new List<Yearlycopyoption>();
}
