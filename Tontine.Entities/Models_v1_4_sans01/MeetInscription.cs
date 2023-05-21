using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// Represente le renoouvellement de la presence d&apos;un membre au sein de &apos;association au cours d&apos;une annee
/// </summary>
public partial class MeetInscription
{
    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    public int Idinscrit { get; set; }

    /// <summary>
    /// create_uid
    /// </summary>
    public long? CreateUid { get; set; }

    /// <summary>
    /// update_uid
    /// </summary>
    public long? UpdateUid { get; set; }

    /// <summary>
    /// Create_at
    /// </summary>
    public DateTime CreateAt { get; set; }

    /// <summary>
    /// Update_at
    /// </summary>
    public DateTime UpdateAt { get; set; }

    /// <summary>
    /// Etab_id
    /// </summary>
    public int EtabId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;antenne
    /// </summary>
    public int AntenneId { get; set; }

    /// <summary>
    /// Person_id
    /// </summary>
    public int PersonId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int AnneeId { get; set; }

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
    public bool IsActive { get; set; }

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
    /// Total_verse
    /// </summary>
    public decimal TotalVerse { get; set; }

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

    /// <summary>
    /// Report a nouveau indiquant les dettes d&apos;un membre au terme d&apos;un exercice precedent
    /// </summary>
    public decimal ReportNouveau { get; set; }

    public virtual CoreAnnee Annee { get; set; } = null!;

    public virtual MeetAntenne MeetAntenne { get; set; } = null!;

    public virtual ICollection<MeetMembreBureau> MeetMembreBureaus { get; set; } = new List<MeetMembreBureau>();

    public virtual ICollection<MeetOrdrePassage> MeetOrdrePassages { get; set; } = new List<MeetOrdrePassage>();

    public virtual ICollection<MeetPresence> MeetPresences { get; set; } = new List<MeetPresence>();

    public virtual ICollection<MeetPret> MeetPrets { get; set; } = new List<MeetPret>();

    public virtual ICollection<MeetSortieCaisse> MeetSortieCaisses { get; set; } = new List<MeetSortieCaisse>();

    public virtual ICollection<MeetVisa> MeetVisas { get; set; } = new List<MeetVisa>();

    public virtual CorePerson Person { get; set; } = null!;
}
