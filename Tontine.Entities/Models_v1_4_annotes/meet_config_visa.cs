using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Represente l&apos;ensemble des autorisatios de signature de documents au sein de l&apos;association
/// </summary>
[Table("meet_config_visas", Schema = "tontine_v14")]
[Index("annee_id", Name = "association_6_fk")]
[Index("poste_id", Name = "association_7_fk")]
[Index("typerub_id", Name = "association_8_fk2")]
[Index("configvisa_id", Name = "meet_config_visas_pk", IsUnique = true)]
[Index("poste_id", "annee_id", "typerub_id", Name = "uniq_config_visas", IsUnique = true)]
public partial class meet_config_visa
{
    /// <summary>
    /// Identifiant de la configuration de signature
    /// </summary>
    [Key]
    public int configvisa_id { get; set; }

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
    /// Poste_id
    /// </summary>
    public int poste_id { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int annee_id { get; set; }

    /// <summary>
    /// Identifiant du type d&apos;evenement
    /// </summary>
    public int typerub_id { get; set; }

    /// <summary>
    /// Numero d&apos;ordre de la signature pour un type de document
    /// </summary>
    public int numordre { get; set; }

    /// <summary>
    /// Sign_by_ordre
    /// </summary>
    public bool sign_by_ordre { get; set; }

    [ForeignKey("annee_id")]
    [InverseProperty("meet_config_visas")]
    public virtual core_annee annee { get; set; } = null!;

    [InverseProperty("configvisa")]
    public virtual ICollection<meet_visa> meet_visas { get; set; } = new List<meet_visa>();

    [ForeignKey("poste_id")]
    [InverseProperty("meet_config_visas")]
    public virtual meet_poste poste { get; set; } = null!;

    [ForeignKey("typerub_id")]
    [InverseProperty("meet_config_visas")]
    public virtual meet_type_rubrique typerub { get; set; } = null!;
}
