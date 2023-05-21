using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Meet_Membre_Bureau
/// </summary>
[Table("meet_membre_bureau", Schema = "tontine_v14")]
[Index("idinscrit", Name = "association_23_fk")]
[Index("bureau_id", Name = "association_46_fk")]
[Index("poste_id", Name = "association_47_fk")]
[Index("bureaudetails_id", Name = "meet_membre_bureau_pk", IsUnique = true)]
[Index("idinscrit", "poste_id", "bureau_id", Name = "uniq_membre_bureau", IsUnique = true)]
public partial class meet_membre_bureau
{
    /// <summary>
    /// bureaudetails_id
    /// </summary>
    [Key]
    public int bureaudetails_id { get; set; }

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
    /// Poste_id
    /// </summary>
    public int poste_id { get; set; }

    /// <summary>
    /// Bureau_id
    /// </summary>
    public int bureau_id { get; set; }

    [ForeignKey("bureau_id")]
    [InverseProperty("meet_membre_bureaus")]
    public virtual meet_bureau bureau { get; set; } = null!;

    [ForeignKey("idinscrit")]
    [InverseProperty("meet_membre_bureaus")]
    public virtual meet_inscription idinscritNavigation { get; set; } = null!;

    [ForeignKey("poste_id")]
    [InverseProperty("meet_membre_bureaus")]
    public virtual meet_poste poste { get; set; } = null!;
}
