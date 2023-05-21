using System;
using System.Collections.Generic;

namespace Tontine.Entities.Models_v1_4_sans01;

/// <summary>
/// Meet_Visas
/// </summary>
public partial class MeetVisa
{
    /// <summary>
    /// Identiifant de la signature
    /// </summary>
    public int VisaId { get; set; }

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
    /// Identifiant de l&apos;inscription
    /// </summary>
    public int Idinscrit { get; set; }

    /// <summary>
    /// Identifiant de la configuration de signature
    /// </summary>
    public int ConfigvisaId { get; set; }

    /// <summary>
    /// Sortiecaisse_id
    /// </summary>
    public int? SortiecaisseId { get; set; }

    /// <summary>
    /// Meet_Operation
    /// </summary>
    public int? MeetOperation { get; set; }

    /// <summary>
    /// Date de signature
    /// </summary>
    public DateOnly Datesign { get; set; }

    /// <summary>
    /// Indique si le document est signe par ordre
    /// </summary>
    public bool SignByOrdre { get; set; }

    /// <summary>
    /// Indique si le signataire est le beneficiare
    /// </summary>
    public bool Receiver { get; set; }

    public virtual MeetConfigVisa Configvisa { get; set; } = null!;

    public virtual MeetInscription IdinscritNavigation { get; set; } = null!;

    public virtual MeetPret? MeetOperationNavigation { get; set; }

    public virtual MeetSortieCaisse? Sortiecaisse { get; set; }
}
