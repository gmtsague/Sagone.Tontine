using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Meet_Visas
/// </summary>
[Table("meet_visas", Schema = "tontine_v14")]
[Index("configvisa_id", Name = "association_15_fk")]
[Index("sortiecaisse_id", Name = "association_22_fk")]
[Index("meet_operation", Name = "association_22_fk2")]
[Index("idinscrit", Name = "association_26_fk")]
[Index("visa_id", Name = "meet_visas_pk", IsUnique = true)]
[Index("idinscrit", "configvisa_id", Name = "uniq_visa", IsUnique = true)]
public partial class meet_visa
{
    /// <summary>
    /// Identiifant de la signature
    /// </summary>
    [Key]
    public int visa_id { get; set; }

    /// <summary>
    /// create_uid
    /// </summary>
    public long? create_uid { get; set; }

    /// <summary>
    /// update_uid
    /// </summary>
    public long? update_uid { get; set; }

    /// <summary>
    /// Create_at
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime create_at { get; set; }

    /// <summary>
    /// Update_at
    /// </summary>
    [Column(TypeName = "timestamp without time zone")]
    public DateTime update_at { get; set; }

    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    public int idinscrit { get; set; }

    /// <summary>
    /// Identifiant de la configuration de signature
    /// </summary>
    public int configvisa_id { get; set; }

    /// <summary>
    /// Sortiecaisse_id
    /// </summary>
    public int? sortiecaisse_id { get; set; }

    /// <summary>
    /// Meet_Operation
    /// </summary>
    public int? meet_operation { get; set; }

    /// <summary>
    /// Date de signature
    /// </summary>
    public DateOnly datesign { get; set; }

    /// <summary>
    /// Indique si le document est signe par ordre
    /// </summary>
    public bool sign_by_ordre { get; set; }

    /// <summary>
    /// Indique si le signataire est le beneficiare
    /// </summary>
    public bool receiver { get; set; }

    [ForeignKey("configvisa_id")]
    [InverseProperty("meet_visas")]
    public virtual meet_config_visa configvisa { get; set; } = null!;

    [ForeignKey("idinscrit")]
    [InverseProperty("meet_visas")]
    public virtual meet_inscription idinscritNavigation { get; set; } = null!;

    [ForeignKey("meet_operation")]
    [InverseProperty("meet_visas")]
    public virtual meet_pret? meet_operationNavigation { get; set; }

    [ForeignKey("sortiecaisse_id")]
    [InverseProperty("meet_visas")]
    public virtual meet_sortie_caisse? sortiecaisse { get; set; }
}
