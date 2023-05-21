using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// core_Frequence_Division
/// </summary>
public partial class CoreFrequenceDivision
{
    /// <summary>
    /// Frequence_id
    /// </summary>
    public int FrequenceId { get; set; }

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
    /// Libelle
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Nb_Days
    /// </summary>
    public int NbDays { get; set; }

    public virtual ICollection<CoreAnnee> CoreAnnees { get; set; } = new List<CoreAnnee>();
}
