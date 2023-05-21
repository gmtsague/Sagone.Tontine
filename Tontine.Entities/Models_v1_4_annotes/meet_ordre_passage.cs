using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Meet_Ordre_Passage
/// </summary>
[Table("meet_ordre_passage", Schema = "tontine_v14")]
[Index("idinscrit", Name = "association_16_fk")]
[Index("annee_id", "division_id", Name = "association_51_fk")]
[Index("passage_id", Name = "meet_ordre_passage_pk", IsUnique = true)]
[Index("annee_id", "division_id", "idinscrit", Name = "uniq_ordre_passage", IsUnique = true)]
public partial class meet_ordre_passage
{
    /// <summary>
    /// passage_id
    /// </summary>
    [Key]
    public int passage_id { get; set; }

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
    /// Identifiant de la division
    /// </summary>
    public int division_id { get; set; }

    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    public int idinscrit { get; set; }

    /// <summary>
    /// MontantPercu
    /// </summary>
    public decimal montantpercu { get; set; }

    /// <summary>
    /// HeureDebut
    /// </summary>
    public DateOnly? heuredebut { get; set; }

    /// <summary>
    /// Commentaire
    /// </summary>
    public string? commentaire { get; set; }

    [ForeignKey("annee_id, division_id")]
    [InverseProperty("meet_ordre_passages")]
    public virtual core_subdivision core_subdivision { get; set; } = null!;

    [ForeignKey("idinscrit")]
    [InverseProperty("meet_ordre_passages")]
    public virtual meet_inscription idinscritNavigation { get; set; } = null!;
}
