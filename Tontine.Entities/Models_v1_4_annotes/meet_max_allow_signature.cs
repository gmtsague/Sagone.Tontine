using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Meet_Max_allow_signature
/// </summary>
[Table("meet_max_allow_signature", Schema = "tontine_v14")]
[Index("annee_id", Name = "association_57_fk")]
[Index("typerub_id", Name = "association_58_fk")]
[Index("id", Name = "meet_max_allow_signature_pk", IsUnique = true)]
[Index("annee_id", "typerub_id", Name = "uniq_max_allow_siganture", IsUnique = true)]
public partial class meet_max_allow_signature
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    public int id { get; set; }

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
    /// Identifiant de l&apos;annee
    /// </summary>
    public int annee_id { get; set; }

    /// <summary>
    /// Identifiant du type d&apos;evenement
    /// </summary>
    public int typerub_id { get; set; }

    /// <summary>
    /// La valeur de cet attribut a partir de la somme des lignes faisant reference a un type de rubrique pour une annee donnee
    /// </summary>
    public int max_signature { get; set; }

    [ForeignKey("annee_id")]
    [InverseProperty("meet_max_allow_signatures")]
    public virtual core_annee annee { get; set; } = null!;

    [ForeignKey("typerub_id")]
    [InverseProperty("meet_max_allow_signatures")]
    public virtual meet_type_rubrique typerub { get; set; } = null!;
}
