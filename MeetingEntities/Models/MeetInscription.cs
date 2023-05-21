using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MeetingEntities.Models;

/// <summary>
/// Represente le renoouvellement de la presence d&apos;un membre au sein de &apos;association au cours d&apos;une annee
/// </summary>
[Table("meet_inscription", Schema = "tontine_v14")]
[Index("EtabId", "AntenneId", Name = "association_3_fk")]
[Index("PersonId", Name = "association_4_fk")]
[Index("AnneeId", Name = "association_5_fk")]
[Index("EtabId", "AntenneId", "PersonId", "AnneeId", Name = "uniq_inscription", IsUnique = true)]
public partial class MeetInscription
{
    /// <summary>
    /// Identifiant de l&apos;inscription
    /// </summary>
    [Key]
    [Column("idinscrit")]
    public int Idinscrit { get; set; }

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
    public int EtabId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;antenne
    /// </summary>
    [Column("antenne_id")]
    public int AntenneId { get; set; }

    /// <summary>
    /// Person_id
    /// </summary>
    [Column("person_id")]
    public int PersonId { get; set; }

    /// <summary>
    /// Identifiant de l&apos;annee
    /// </summary>
    [Column("annee_id")]
    public int AnneeId { get; set; }

    /// <summary>
    /// Date de l&apos;inscription
    /// </summary>
    [Column("dateinscrit")]
    public DateOnly Dateinscrit { get; set; }

    /// <summary>
    /// Date de derniere suspension d&apos;un membre
    /// </summary>
    [Column("datesuspension")]
    public DateOnly? Datesuspension { get; set; }

    /// <summary>
    /// Statut actif ou non d&apos;un membre
    /// </summary>
    [Column("is_active")]
    public bool IsActive { get; set; }

    /// <summary>
    /// Nocni
    /// </summary>
    [Column("nocni")]
    [StringLength(32)]
    public string Nocni { get; set; } = null!;

    /// <summary>
    /// SoldeDebut
    /// </summary>
    [Column("soldedebut")]
    public decimal Soldedebut { get; set; }

    /// <summary>
    /// SoldeFin
    /// </summary>
    [Column("soldefin")]
    public decimal? Soldefin { get; set; }

    /// <summary>
    /// Report a nouveau du membre pour la nouvelle annee
    /// </summary>
    [Column("tauxcotisation")]
    public decimal Tauxcotisation { get; set; }

    /// <summary>
    /// Total_verse
    /// </summary>
    [Column("total_verse")]
    public decimal TotalVerse { get; set; }

    /// <summary>
    /// Dettes cumulees applicable la nouvelle annee
    /// </summary>
    [Column("cumuldettes")]
    public decimal? Cumuldettes { get; set; }

    /// <summary>
    /// Dettes cumules de penelites applicable la nouvelle annee
    /// </summary>
    [Column("cumulpenalites")]
    public decimal? Cumulpenalites { get; set; }

    /// <summary>
    /// Indique si le membre est endette
    /// </summary>
    [Column("endette")]
    public bool Endette { get; set; }

    /// <summary>
    /// Report a nouveau indiquant les dettes d&apos;un membre au terme d&apos;un exercice precedent
    /// </summary>
    [Column("report_nouveau")]
    public decimal ReportNouveau { get; set; }

    [ForeignKey("AnneeId")]
    [InverseProperty("MeetInscriptions")]
    public virtual CoreAnnee Annee { get; set; } = null!;

    [ForeignKey("EtabId, AntenneId")]
    [InverseProperty("MeetInscriptions")]
    public virtual MeetAntenne MeetAntenne { get; set; } = null!;

    [InverseProperty("IdinscritNavigation")]
    public virtual ICollection<MeetMembreBureau> MeetMembreBureaus { get; set; } = new List<MeetMembreBureau>();

    [InverseProperty("IdinscritNavigation")]
    public virtual ICollection<MeetOrdrePassage> MeetOrdrePassages { get; set; } = new List<MeetOrdrePassage>();

    [InverseProperty("IdinscritNavigation")]
    public virtual ICollection<MeetPresence> MeetPresences { get; set; } = new List<MeetPresence>();

    [InverseProperty("IdinscritNavigation")]
    public virtual ICollection<MeetPret> MeetPrets { get; set; } = new List<MeetPret>();

    [InverseProperty("IdinscritNavigation")]
    public virtual ICollection<MeetSortieCaisse> MeetSortieCaisses { get; set; } = new List<MeetSortieCaisse>();

    [InverseProperty("IdinscritNavigation")]
    public virtual ICollection<MeetVisa> MeetVisas { get; set; } = new List<MeetVisa>();

    [ForeignKey("PersonId")]
    [InverseProperty("MeetInscriptions")]
    public virtual CorePerson Person { get; set; } = null!;
}
