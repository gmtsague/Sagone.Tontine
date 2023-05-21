using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MeetingEntities.Models;

/// <summary>
/// Represente la personnalisation de certaines valeurs appliquees aux types d&apos;eveneents au cours d&apos;une annee
/// </summary>
[Table("meet_rubrique", Schema = "tontine_v14")]
[Index("TyperubId", Name = "association_10_fk")]
[Index("AnneeId", Name = "association_9_fk")]
[Index("RubriqueId", Name = "meet_rubrique_pk", IsUnique = true)]
public partial class MeetRubrique
{
    /// <summary>
    /// Identifiant d&apos;une configuration
    /// </summary>
    [Key]
    [Column("rubrique_id")]
    public int RubriqueId { get; set; }

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
    /// Description de la rubrique (evenement)
    /// </summary>
    [Column("libelle")]
    [StringLength(128)]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Nombre de membres representant l&apos;asociation a l&apos;evenement
    /// </summary>
    [Column("nbmandataire")]
    public int Nbmandataire { get; set; }

    /// <summary>
    /// Montant du deplacement d&apos;un membre mandate par l&apos;association
    /// </summary>
    [Column("montantroute")]
    public decimal Montantroute { get; set; }

    /// <summary>
    /// Montant total associe a l&apos;evenement
    /// </summary>
    [Column("montant_person")]
    public decimal MontantPerson { get; set; }

    /// <summary>
    /// Indique si le type represente une sortie de caisse
    /// </summary>
    [Column("is_outcome")]
    public bool IsOutcome { get; set; }

    /// <summary>
    /// Commentaire
    /// </summary>
    [Column("commentaire")]
    public string? Commentaire { get; set; }

    /// <summary>
    /// Defini l'ordre dans lequel les rubriques de ce type peuevnt beneficier d'une repartition automatique du montant verse par un membre d'une reunion
    /// </summary>
    [Column("numordre")]
    public int Numordre { get; set; }

    /// <summary>
    /// Une rubrique de cette categorie doit faire l'objet d''un versement du montant total defini a chaque periode (mois, semaine, etc) d'un exercice.
    /// </summary>
    [Column("topay_each_periode")]
    public bool TopayEachPeriode { get; set; }

    /// <summary>
    /// Autoriser un membre a definir un montant a cotiser different de celui defini par defaut
    /// </summary>
    [Column("allow_custom_amount")]
    public bool AllowCustomAmount { get; set; }       
    
    [ForeignKey("AnneeId")]
    [InverseProperty("MeetRubriques")]
    public virtual CoreAnnee Annee { get; set; } = null!;

    [InverseProperty("Rubrique")]
    public virtual ICollection<MeetEngagement> MeetEngagements { get; set; } = new List<MeetEngagement>();

    [ForeignKey("TyperubId")]
    [InverseProperty("MeetRubriques")]
    public virtual MeetTypeRubrique Typerub { get; set; } = null!;
}
