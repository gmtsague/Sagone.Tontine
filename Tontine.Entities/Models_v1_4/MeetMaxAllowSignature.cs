using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4;

/// <summary>
/// Meet_Max_allow_signature
/// </summary>
[Table("meet_max_allow_signature", Schema = "tontine_v14")]
[Index("AnneeId", Name = "association_57_fk")]
[Index("TyperubId", Name = "association_58_fk")]
[Index("Id", Name = "meet_max_allow_signature_pk", IsUnique = true)]
[Index("AnneeId", "TyperubId", Name = "uniq_max_allow_siganture", IsUnique = true)]
public partial class MeetMaxAllowSignature
{
    /// <summary>
    /// Id
    /// </summary>
    [Key]
    [Column("id")]
    public int Id { get; set; }

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
    /// La valeur de cet attribut a partir de la somme des lignes faisant reference a un type de rubrique pour une annee donnee
    /// </summary>
    [Column("max_signature")]
    public int MaxSignature { get; set; }

    [ForeignKey("AnneeId")]
    [InverseProperty("MeetMaxAllowSignatures")]
    public virtual CoreAnnee Annee { get; set; } = null!;

    [ForeignKey("TyperubId")]
    [InverseProperty("MeetMaxAllowSignatures")]
    public virtual MeetTypeRubrique Typerub { get; set; } = null!;
}
