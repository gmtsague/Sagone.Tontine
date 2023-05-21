using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans;

/// <summary>
/// Meet_Bureau
/// </summary>
public partial class MeetBureau
{
    /// <summary>
    /// Bureau_id
    /// </summary>
    public int BureauId { get; set; }

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
    public int? EtabId { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Debut
    /// </summary>
    public DateOnly Debut { get; set; }

    /// <summary>
    /// Fin
    /// </summary>
    public DateOnly Fin { get; set; }

    /// <summary>
    /// Nbperson
    /// </summary>
    public int Nbperson { get; set; }

    /// <summary>
    /// Nbvotes
    /// </summary>
    public int Nbvotes { get; set; }

    /// <summary>
    /// NbAbstention
    /// </summary>
    public int Nbabstention { get; set; }

    /// <summary>
    /// Resumevote
    /// </summary>
    public string? Resumevote { get; set; }

    public virtual ICollection<CoreAnnee> CoreAnnees { get; set; } = new List<CoreAnnee>();

    public virtual CoreEtablissement? Etab { get; set; }

    public virtual ICollection<MeetMembreBureau> MeetMembreBureaus { get; set; } = new List<MeetMembreBureau>();
}
