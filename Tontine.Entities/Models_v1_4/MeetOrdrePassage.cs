using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4;

/// <summary>
/// Meet_Ordre_Passage
/// </summary>
[Table("meet_ordre_passage", Schema = "tontine_v14")]
[Index("Idinscrit", Name = "association_16_fk")]
[Index("AnneeId", "DivisionId", Name = "association_51_fk")]
[Index("PassageId", Name = "meet_ordre_passage_pk", IsUnique = true)]
[Index("AnneeId", "DivisionId", "Idinscrit", Name = "uniq_ordre_passage", IsUnique = true)]
public partial class MeetOrdrePassage
{
    /// <summary>
    /// passage_id
    /// </summary>
    [Key]
    [Column("passage_id")]
    public int PassageId { get; set; }

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
    /// Identifiant de la division
    /// </summary>
    [Column("division_id")]
    public int DivisionId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    [Column("idinscrit")]
    public int Idinscrit { get; set; }

    /// <summary>
    /// MontantPercu
    /// </summary>
    [Column("montantpercu")]
    public decimal Montantpercu { get; set; }

    /// <summary>
    /// HeureDebut
    /// </summary>
    [Column("heuredebut")]
    public DateOnly? Heuredebut { get; set; }

    /// <summary>
    /// Commentaire
    /// </summary>
    [Column("commentaire")]
    public string? Commentaire { get; set; }

    [ForeignKey("AnneeId, DivisionId")]
    [InverseProperty("MeetOrdrePassages")]
    public virtual CoreSubdivision CoreSubdivision { get; set; } = null!;

    [ForeignKey("Idinscrit")]
    [InverseProperty("MeetOrdrePassages")]
    public virtual MeetInscription IdinscritNavigation { get; set; } = null!;
}
