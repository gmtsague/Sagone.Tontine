using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans;

/// <summary>
/// Represente une annee 
/// </summary>
public partial class CoreAnnee
{
    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int AnneeId { get; set; }

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
    /// Frequence_id
    /// </summary>
    public int FrequenceId { get; set; }

    /// <summary>
    /// Bureau_id
    /// </summary>
    public int? BureauId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int? Previous { get; set; }

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
    public bool IsCurrent { get; set; }

    /// <summary>
    /// Indique que l&apos;annee et cloturee et ses donnees ne sont plus modifiables
    /// </summary>
    public bool IsClosed { get; set; }

    /// <summary>
    /// Nombre de divisions de l&apos;annee
    /// </summary>
    public int Nbdivision { get; set; }

    /// <summary>
    /// Copy_data_from_previous
    /// </summary>
    public bool CopyDataFromPrevious { get; set; }

    public virtual MeetBureau? Bureau { get; set; }

    public virtual ICollection<CoreAnnualSetting> CoreAnnualSettings { get; set; } = new List<CoreAnnualSetting>();

    public virtual ICollection<CoreSubdivision> CoreSubdivisions { get; set; } = new List<CoreSubdivision>();

    public virtual CoreFrequenceDivision Frequence { get; set; } = null!;

    public virtual ICollection<CoreAnnee> InversePreviousNavigation { get; set; } = new List<CoreAnnee>();

    public virtual ICollection<MeetConfigVisa> MeetConfigVisas { get; set; } = new List<MeetConfigVisa>();

    public virtual ICollection<MeetInscription> MeetInscriptions { get; set; } = new List<MeetInscription>();

    public virtual ICollection<MeetMaxAllowSignature> MeetMaxAllowSignatures { get; set; } = new List<MeetMaxAllowSignature>();

    public virtual ICollection<MeetRubrique> MeetRubriques { get; set; } = new List<MeetRubrique>();

    public virtual CoreAnnee? PreviousNavigation { get; set; }
}
