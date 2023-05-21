﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4;

/// <summary>
/// Represente un type d&apos;evenements par exemple Mariage, Deces, Naissance, Cotisation, Decaissement ponctuel, etc.
/// </summary>
[Table("meet_type_rubrique", Schema = "tontine_v14")]
[Index("Code", Name = "ak_uniq_type_rubrique_meet_typ", IsUnique = true)]
[Index("TyperubId", Name = "meet_type_rubrique_pk", IsUnique = true)]
public partial class MeetTypeRubrique
{
    /// <summary>
    /// Identifiant du type d&apos;evenement
    /// </summary>
    [Key]
    [Column("typerub_id")]
    public int TyperubId { get; set; }

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
    /// Libelle du type d&apos;evenement
    /// </summary>
    [Column("libelle", TypeName = "jsonb")]
    public string Libelle { get; set; } = null!;

    /// <summary>
    /// Indique si le type represente une sortie de caisse
    /// </summary>
    [Column("is_outcome")]
    public bool IsOutcome { get; set; }

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
    /// Montant de la penalite applicable en cas d&apos;absence aa l&apos;evenement
    /// </summary>
    [Column("montantpenalite")]
    public decimal Montantpenalite { get; set; }

    /// <summary>
    /// Les valeurs autorisees sont : {PRET, FONDENTRAIDE, COLLATION, EPARGNE, COTISATION, AIDE-NAISSANCE, AIDE-DECES, AIDE-MARIAGE, AIDE-DECES-CONJOINT, AIDE-DECES-FRERE, SECOURS, PENALITE-AIDES-DECES, PROJET}
    /// </summary>
    [Column("code")]
    [StringLength(64)]
    public string Code { get; set; } = null!;

    /// <summary>
    /// Indique si l&apos;utlisateur peut supprimer cette information
    /// </summary>
    [Column("candelete")]
    public bool Candelete { get; set; }

    /// <summary>
    /// Nombre de signatures autorises pour signer un documents associe a ce type devenement
    /// </summary>
    [Column("maxsignature")]
    public int Maxsignature { get; set; }

    /// <summary>
    /// Indique si le systeme cree automatiquement une rubrique correspondante quand sa valeur est TRUE
    /// </summary>
    [Column("auto_generated")]
    public bool AutoGenerated { get; set; }

    /// <summary>
    /// Indique que toutes les rubriques de ce type sont automatiquement cotisees par les membres d&apos;une reunion
    /// </summary>
    [Column("required")]
    public bool Required { get; set; }

    /// <summary>
    /// Lorsque sa valeur est a TRUE, le systeme peut proposser a l&apos;utilisateur (ou automatiquement) la creation des rubrique associee a ce type.
    /// </summary>
    [Column("is_active")]
    public bool IsActive { get; set; }

    /// <summary>
    /// Defini l&apos;ordre dans lequel les rubriques de ce type peuevnt beneficier d&apos;une repartition automatique du montant verse par un membre d&apos;une reunion
    /// </summary>
    [Column("numordre")]
    public int Numordre { get; set; }

    [InverseProperty("Typerub")]
    public virtual ICollection<MeetConfigVisa> MeetConfigVisas { get; set; } = new List<MeetConfigVisa>();

    [InverseProperty("Typerub")]
    public virtual ICollection<MeetMaxAllowSignature> MeetMaxAllowSignatures { get; set; } = new List<MeetMaxAllowSignature>();

    [InverseProperty("Typerub")]
    public virtual ICollection<MeetRubrique> MeetRubriques { get; set; } = new List<MeetRubrique>();
}
