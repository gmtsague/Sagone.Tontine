using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Represente la personnalisation de certaines valeurs appliquees aux types d&apos;eveneents au cours d&apos;une annee
/// </summary>
[Table("meet_rubrique", Schema = "tontine_v14")]
[Index("typerub_id", Name = "association_10_fk")]
[Index("annee_id", Name = "association_9_fk")]
[Index("rubrique_id", Name = "meet_rubrique_pk", IsUnique = true)]
public partial class meet_rubrique
{
    /// <summary>
    /// Identifiant d&apos;une configuration
    /// </summary>
    [Key]
    public int rubrique_id { get; set; }

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
    /// Description de la rubrique (evenement)
    /// </summary>
    [StringLength(128)]
    public string libelle { get; set; } = null!;

    /// <summary>
    /// Nombre de membres representant l&apos;asociation a l&apos;evenement
    /// </summary>
    public int nbmandataire { get; set; }

    /// <summary>
    /// Montant du deplacement d&apos;un membre mandate par l&apos;association
    /// </summary>
    public decimal montantroute { get; set; }

    /// <summary>
    /// Montant total associe a l&apos;evenement
    /// </summary>
    public decimal montant_person { get; set; }

    /// <summary>
    /// Indique si le type represente une sortie de caisse
    /// </summary>
    public bool is_outcome { get; set; }

    /// <summary>
    /// Commentaire
    /// </summary>
    public string? commentaire { get; set; }

    [ForeignKey("annee_id")]
    [InverseProperty("meet_rubriques")]
    public virtual core_annee annee { get; set; } = null!;

    [InverseProperty("rubrique")]
    public virtual ICollection<meet_engagement> meet_engagements { get; set; } = new List<meet_engagement>();

    [ForeignKey("typerub_id")]
    [InverseProperty("meet_rubriques")]
    public virtual meet_type_rubrique typerub { get; set; } = null!;
}
