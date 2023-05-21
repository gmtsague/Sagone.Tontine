using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Represente un type d&apos;evenements par exemple Mariage, Deces, Naissance, Cotisation, Decaissement ponctuel, etc.
/// </summary>
[Table("meet_type_rubrique", Schema = "tontine_v14")]
[Index("code", Name = "ak_uniq_type_rubrique_meet_typ", IsUnique = true)]
[Index("typerub_id", Name = "meet_type_rubrique_pk", IsUnique = true)]
public partial class meet_type_rubrique
{
    /// <summary>
    /// Identifiant du type d&apos;evenement
    /// </summary>
    [Key]
    public int typerub_id { get; set; }

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
    /// Libelle du type d&apos;evenement
    /// </summary>
    [Column(TypeName = "jsonb")]
    public string libelle { get; set; } = null!;

    /// <summary>
    /// Indique si le type represente une sortie de caisse
    /// </summary>
    public bool is_outcome { get; set; }

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
    /// Montant de la penalite applicable en cas d&apos;absence aa l&apos;evenement
    /// </summary>
    public decimal montantpenalite { get; set; }

    /// <summary>
    /// Les valeurs autorisees sont : {PRET, FONDENTRAIDE, COLLATION, EPARGNE, COTISATION, AIDE-NAISSANCE, AIDE-DECES, AIDE-MARIAGE, AIDE-DECES-CONJOINT, AIDE-DECES-FRERE, SECOURS, PENALITE-AIDES-DECES, PROJET}
    /// </summary>
    [StringLength(64)]
    public string code { get; set; } = null!;

    /// <summary>
    /// Indique si l&apos;utlisateur peut supprimer cette information
    /// </summary>
    public bool candelete { get; set; }

    /// <summary>
    /// Nombre de signatures autorises pour signer un documents associe a ce type devenement
    /// </summary>
    public int maxsignature { get; set; }

    /// <summary>
    /// Indique si le systeme cree automatiquement une rubrique correspondante quand sa valeur est TRUE
    /// </summary>
    public bool auto_generated { get; set; }

    /// <summary>
    /// Indique que toutes les rubriques de ce type sont automatiquement cotisees par les membres d&apos;une reunion
    /// </summary>
    public bool required { get; set; }

    /// <summary>
    /// Lorsque sa valeur est a TRUE, le systeme peut proposser a l&apos;utilisateur (ou automatiquement) la creation des rubrique associee a ce type.
    /// </summary>
    public bool is_active { get; set; }

    /// <summary>
    /// Defini l&apos;ordre dans lequel les rubriques de ce type peuevnt beneficier d&apos;une repartition automatique du montant verse par un membre d&apos;une reunion
    /// </summary>
    public int numordre { get; set; }

    [InverseProperty("typerub")]
    public virtual ICollection<meet_config_visa> meet_config_visas { get; set; } = new List<meet_config_visa>();

    [InverseProperty("typerub")]
    public virtual ICollection<meet_max_allow_signature> meet_max_allow_signatures { get; set; } = new List<meet_max_allow_signature>();

    [InverseProperty("typerub")]
    public virtual ICollection<meet_rubrique> meet_rubriques { get; set; } = new List<meet_rubrique>();
}
