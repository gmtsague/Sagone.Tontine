using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MeetingEntities.Models;

/// <summary>
/// Meet_Visas
/// </summary>
[Table("meet_visas", Schema = "tontine_v14")]
[Index("ConfigvisaId", Name = "association_15_fk")]
[Index("SortiecaisseId", Name = "association_22_fk")]
[Index("MeetOperation", Name = "association_22_fk2")]
[Index("Idinscrit", Name = "association_26_fk")]
[Index("VisaId", Name = "meet_visas_pk", IsUnique = true)]
[Index("Idinscrit", "ConfigvisaId", Name = "uniq_visa", IsUnique = true)]
public partial class MeetVisa
{
    /// <summary>
    /// Identiifant de la signature
    /// </summary>
    [Key]
    [Column("visa_id")]
    public int VisaId { get; set; }

    /// <summary>
    /// create_uid
    /// </summary>
    [Column("create_uid")]
    public long? CreateUid { get; set; }

    /// <summary>
    /// update_uid
    /// </summary>
    [Column("update_uid")]
    public long? UpdateUid { get; set; }

    /// <summary>
    /// Create_at
    /// </summary>
    [Column("create_at", TypeName = "timestamp without time zone")]
    public DateTime CreateAt { get; set; }

    /// <summary>
    /// Update_at
    /// </summary>
    [Column("update_at", TypeName = "timestamp without time zone")]
    public DateTime UpdateAt { get; set; }

    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    [Column("idinscrit")]
    public int Idinscrit { get; set; }

    /// <summary>
    /// Identifiant de la configuration de signature
    /// </summary>
    [Column("configvisa_id")]
    public int ConfigvisaId { get; set; }

    /// <summary>
    /// Sortiecaisse_id
    /// </summary>
    [Column("sortiecaisse_id")]
    public int? SortiecaisseId { get; set; }

    /// <summary>
    /// Meet_Operation
    /// </summary>
    [Column("meet_operation")]
    public int? MeetOperation { get; set; }

    /// <summary>
    /// Date de signature
    /// </summary>
    [Column("datesign")]
    public DateOnly Datesign { get; set; }

    /// <summary>
    /// Indique si le document est signe par ordre
    /// </summary>
    [Column("sign_by_ordre")]
    public bool SignByOrdre { get; set; }

    /// <summary>
    /// Indique si le signataire est le beneficiare
    /// </summary>
    [Column("receiver")]
    public bool Receiver { get; set; }

    [ForeignKey("ConfigvisaId")]
    [InverseProperty("MeetVisas")]
    public virtual MeetConfigVisa Configvisa { get; set; } = null!;

    [ForeignKey("Idinscrit")]
    [InverseProperty("MeetVisas")]
    public virtual MeetInscription IdinscritNavigation { get; set; } = null!;

    [ForeignKey("MeetOperation")]
    [InverseProperty("MeetVisas")]
    public virtual MeetPret? MeetOperationNavigation { get; set; }

    [ForeignKey("SortiecaisseId")]
    [InverseProperty("MeetVisas")]
    public virtual MeetSortieCaisse? Sortiecaisse { get; set; }
}
