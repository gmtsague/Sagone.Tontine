using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Tontine.Entities.Models_v1_4_annotes;

/// <summary>
/// Represente le renoouvellement de la presence d&apos;un membre au sein de &apos;association au cours d&apos;une annee
/// </summary>
[Table("meet_inscription", Schema = "tontine_v14")]
[Index("etab_id", "antenne_id", Name = "association_3_fk")]
[Index("person_id", Name = "association_4_fk")]
[Index("annee_id", Name = "association_5_fk")]
[Index("etab_id", "antenne_id", "person_id", "annee_id", Name = "uniq_inscription", IsUnique = true)]
public partial class meet_inscription
{
    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    [Key]
    public int idinscrit { get; set; }

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
    /// Etab_id
    /// </summary>
    public int etab_id { get; set; }

    /// <summary>
    /// Identifiant de l&apos;antenne
    /// </summary>
    public int antenne_id { get; set; }

    /// <summary>
    /// Person_id
    /// </summary>
    public int person_id { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    public int annee_id { get; set; }

    /// <summary>
    /// Date de l&apos;inscription
    /// </summary>
    public DateOnly dateinscrit { get; set; }

    /// <summary>
    /// Date de derniere suspension d&apos;un membre
    /// </summary>
    public DateOnly? datesuspension { get; set; }

    /// <summary>
    /// Statut actif ou non d&apos;un membre
    /// </summary>
    public bool is_active { get; set; }

    /// <summary>
    /// Nocni
    /// </summary>
    [StringLength(32)]
    public string nocni { get; set; } = null!;

    /// <summary>
    /// SoldeDebut
    /// </summary>
    public decimal soldedebut { get; set; }

    /// <summary>
    /// SoldeFin
    /// </summary>
    public decimal? soldefin { get; set; }

    /// <summary>
    /// Report a nouveau du membre pour la nouvelle annee
    /// </summary>
    public decimal tauxcotisation { get; set; }

    /// <summary>
    /// Total_verse
    /// </summary>
    public decimal total_verse { get; set; }

    /// <summary>
    /// Dettes cumulees applicable la nouvelle annee
    /// </summary>
    public decimal? cumuldettes { get; set; }

    /// <summary>
    /// Dettes cumules de penelites applicable la nouvelle annee
    /// </summary>
    public decimal? cumulpenalites { get; set; }

    /// <summary>
    /// Indique si le membre est endette
    /// </summary>
    public bool endette { get; set; }

    /// <summary>
    /// Report a nouveau indiquant les dettes d&apos;un membre au terme d&apos;un exercice precedent
    /// </summary>
    public decimal report_nouveau { get; set; }

    [ForeignKey("annee_id")]
    [InverseProperty("meet_inscriptions")]
    public virtual core_annee annee { get; set; } = null!;

    [ForeignKey("etab_id, antenne_id")]
    [InverseProperty("meet_inscriptions")]
    public virtual meet_antenne meet_antenne { get; set; } = null!;

    [InverseProperty("idinscritNavigation")]
    public virtual ICollection<meet_membre_bureau> meet_membre_bureaus { get; set; } = new List<meet_membre_bureau>();

    [InverseProperty("idinscritNavigation")]
    public virtual ICollection<meet_ordre_passage> meet_ordre_passages { get; set; } = new List<meet_ordre_passage>();

    [InverseProperty("idinscritNavigation")]
    public virtual ICollection<meet_presence> meet_presences { get; set; } = new List<meet_presence>();

    [InverseProperty("idinscritNavigation")]
    public virtual ICollection<meet_pret> meet_prets { get; set; } = new List<meet_pret>();

    [InverseProperty("idinscritNavigation")]
    public virtual ICollection<meet_sortie_caisse> meet_sortie_caisses { get; set; } = new List<meet_sortie_caisse>();

    [InverseProperty("idinscritNavigation")]
    public virtual ICollection<meet_visa> meet_visas { get; set; } = new List<meet_visa>();

    [ForeignKey("person_id")]
    [InverseProperty("meet_inscriptions")]
    public virtual core_person person { get; set; } = null!;
}
