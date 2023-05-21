using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MeetingEntities.Models;

/// <summary>
/// Meet_Membre_Bureau
/// </summary>
[Table("meet_membre_bureau", Schema = "tontine_v14")]
[Index("Idinscrit", Name = "association_23_fk")]
[Index("BureauId", Name = "association_46_fk")]
[Index("PosteId", Name = "association_47_fk")]
[Index("BureaudetailsId", Name = "meet_membre_bureau_pk", IsUnique = true)]
[Index("Idinscrit", "PosteId", "BureauId", Name = "uniq_membre_bureau", IsUnique = true)]
public partial class MeetMembreBureau
{
    /// <summary>
    /// bureaudetails_id
    /// </summary>
    [Key]
    [Column("bureaudetails_id")]
    public int BureaudetailsId { get; set; }

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
    /// Poste_id
    /// </summary>
    [Column("poste_id")]
    public int PosteId { get; set; }

    /// <summary>
    /// Bureau_id
    /// </summary>
    [Column("bureau_id")]
    public int BureauId { get; set; }

    [ForeignKey("BureauId")]
    [InverseProperty("MeetMembreBureaus")]
    public virtual MeetBureau Bureau { get; set; } = null!;

    [ForeignKey("Idinscrit")]
    [InverseProperty("MeetMembreBureaus")]
    public virtual MeetInscription IdinscritNavigation { get; set; } = null!;

    [ForeignKey("PosteId")]
    [InverseProperty("MeetMembreBureaus")]
    public virtual MeetPoste Poste { get; set; } = null!;
}
