using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MeetingEntities.Models;

/// <summary>
/// Meet_Bureau
/// </summary>
[Table("meet_bureau", Schema = "tontine_v14")]
[Index("EtabId", Name = "association_45_fk")]
[Index("BureauId", Name = "meet_bureau_pk", IsUnique = true)]
[Index("EtabId", "Debut", "Fin", Name = "uniq_bureau", IsUnique = true)]
public partial class MeetBureau
{
    /// <summary>
    /// Bureau_id
    /// </summary>
    [Key]
    [Column("bureau_id")]
    public int BureauId { get; set; }

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
    /// Etab_id
    /// </summary>
    [Column("etab_id")]
    public int? EtabId { get; set; }

    /// <summary>
    /// Libelle
    /// </summary>
    [Column("libelle")]
    [StringLength(128)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Debut
    /// </summary>
    [Column("debut")]
    public DateOnly Debut { get; set; }

    /// <summary>
    /// Fin
    /// </summary>
    [Column("fin")]
    public DateOnly Fin { get; set; }

    /// <summary>
    /// Nbperson
    /// </summary>
    [Column("nbperson")]
    public int Nbperson { get; set; }

    /// <summary>
    /// Nbvotes
    /// </summary>
    [Column("nbvotes")]
    public int Nbvotes { get; set; }

    /// <summary>
    /// NbAbstention
    /// </summary>
    [Column("nbabstention")]
    public int Nbabstention { get; set; }

    /// <summary>
    /// Resumevote
    /// </summary>
    [Column("resumevote")]
    public string? Resumevote { get; set; }

    [InverseProperty("Bureau")]
    public virtual ICollection<CoreAnnee> CoreAnnees { get; set; } = new List<CoreAnnee>();

    [ForeignKey("EtabId")]
    [InverseProperty("MeetBureaus")]
    public virtual CoreEtablissement? Etab { get; set; }

    [InverseProperty("Bureau")]
    public virtual ICollection<MeetMembreBureau> MeetMembreBureaus { get; set; } = new List<MeetMembreBureau>();
}
