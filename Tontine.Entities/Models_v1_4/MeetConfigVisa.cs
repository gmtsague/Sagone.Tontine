using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4;

/// <summary>
/// Represente l&apos;ensemble des autorisatios de signature de documents au sein de l&apos;association
/// </summary>
[Table("meet_config_visas", Schema = "tontine_v14")]
[Index("AnneeId", Name = "association_6_fk")]
[Index("PosteId", Name = "association_7_fk")]
[Index("TyperubId", Name = "association_8_fk2")]
[Index("ConfigvisaId", Name = "meet_config_visas_pk", IsUnique = true)]
[Index("PosteId", "AnneeId", "TyperubId", Name = "uniq_config_visas", IsUnique = true)]
public partial class MeetConfigVisa
{
    /// <summary>
    /// Identifiant de la configuration de signature
    /// </summary>
    [Key]
    [Column("configvisa_id")]
    public int ConfigvisaId { get; set; }

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
    /// Poste_id
    /// </summary>
    [Column("poste_id")]
    public int PosteId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Column("annee_id")]
    public int AnneeId { get; set; }

    /// <summary>
    /// Identifiant du type d&apos;evenement
    /// </summary>
    [Column("typerub_id")]
    public int TyperubId { get; set; }

    /// <summary>
    /// Numero d&apos;ordre de la signature pour un type de document
    /// </summary>
    [Column("numordre")]
    public int Numordre { get; set; }

    /// <summary>
    /// Sign_by_ordre
    /// </summary>
    [Column("sign_by_ordre")]
    public bool SignByOrdre { get; set; }

    [ForeignKey("AnneeId")]
    [InverseProperty("MeetConfigVisas")]
    public virtual CoreAnnee Annee { get; set; } = null!;

    [InverseProperty("Configvisa")]
    public virtual ICollection<MeetVisa> MeetVisas { get; set; } = new List<MeetVisa>();

    [ForeignKey("PosteId")]
    [InverseProperty("MeetConfigVisas")]
    public virtual MeetPoste Poste { get; set; } = null!;

    [ForeignKey("TyperubId")]
    [InverseProperty("MeetConfigVisas")]
    public virtual MeetTypeRubrique Typerub { get; set; } = null!;
}
