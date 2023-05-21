using MeetingEntities.Models;
using System.ComponentModel.DataAnnotations;

namespace Meeting.Web.Dto
{
    public class SortieCaisseDto : BaseDto<SortieCaisseDto, MeetSortieCaisse>
    {
        /// <summary>
        /// Sortiecaisse_id
        /// </summary>
        [Key]
        [Display( Name="sortiecaisse_id")]
        public int SortiecaisseId { get; set; }

        /// <summary>
        /// Identifiant de l&apos;inscription
        /// </summary>
        [Display( Name="idinscrit")]
        public int? Idinscrit { get; set; }

        /// <summary>
        /// Seance_id
        /// </summary>
        [Display( Name="seance_id")]
        public int SeanceId { get; set; }

        /// <summary>
        /// Engagement_id
        /// </summary>
        [Display( Name="engagement_id")]
        public int EngagementId { get; set; }

        /// <summary>
        /// No de Reference permettant d''identifier le document
        /// </summary>
        [Display(Name = "ref_no")]
        [StringLength(128)]
        public string? RefNo { get; set; }

        /// <summary>
        /// Benef_principal
        /// </summary>
        [Display(Name = "benef_principal")]
        public bool BenefPrincipal { get; set; }

        /// <summary>
        /// Date effective a laquelle a lieu l&apos;evenement
        /// </summary>
        [Display( Name="dateevts")]
        public DateOnly Dateevts { get; set; }

        /// <summary>
        /// Montant percu par le beneficiaire de l&apos;evenement
        /// </summary>
        [Display( Name="montantpercu")]
        public decimal Montantpercu { get; set; }

        /// <summary>
        /// Observation generale concernant le deroulement de l&apos;evenement
        /// </summary>
        [Display( Name="note")]
        [StringLength(1024)]
        public string? Note { get; set; }

        /// <summary>
        /// Indique que l&apos;evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)
        /// </summary>
        [Display( Name="is_closed")]
        public bool IsClosed { get; set; }

        /// <summary>
        /// Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.
        /// </summary>
        [Display( Name="visarestants")]
        public int Visarestants { get; set; }

        public virtual EngagementDto Engagement { get; set; } = null!;

        public virtual InscriptionDto? IdinscritNavigation { get; set; }

       // public virtual ICollection<MeetVisa> MeetVisas { get; set; } = new List<MeetVisa>();

        public virtual SeanceDto Seance { get; set; } = null!;
    }
}
