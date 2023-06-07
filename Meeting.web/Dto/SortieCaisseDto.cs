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
        [Display( Name="Bénéficiare")]
        public int? Idinscrit { get; set; }

        /// <summary>
        /// Seance_id
        /// </summary>
        [Display( Name="Seance")]
        public int SeanceId { get; set; }

        /// <summary>
        /// Engagement_id
        /// </summary>
        [Display( Name="Rubrique")]
        public int RubriqueId { get; set; }

        /// <summary>
        /// No de Reference permettant d''identifier le document
        /// </summary>
        [Display(Name = "NoRef.Doc")]
        [StringLength(128)]
        public string? RefNo { get; set; }

        /// <summary>
        /// Benef_principal
        /// </summary>
        [Display(Name = "Benef. Principal")]
        public bool BenefPrincipal { get; set; }

        /// <summary>
        /// Date effective a laquelle a lieu l&apos;evenement
        /// </summary>
        [Display( Name="Date Evts")]
        public DateOnly Dateevts { get; set; }

        /// <summary>
        /// Montant percu par le beneficiaire de l&apos;evenement
        /// </summary>
        [Display( Name="Montant percu")]
        public decimal Montantpercu { get; set; }

        /// <summary>
        /// Observation generale concernant le deroulement de l&apos;evenement
        /// </summary>
        [Display( Name="Observations")]
        [StringLength(1024)]
        public string? Note { get; set; }

        /// <summary>
        /// Indique que l&apos;evenement a ete cloture (pret solde, ou toutes les participations atteintes pour un evenement)
        /// </summary>
        [Display( Name="Is Closed")]
        public bool IsClosed { get; set; }

        /// <summary>
        /// Nombre de signatures restantes avant cloture du document ou de la seance de cotisation.
        /// </summary>
        [Display( Name="Visas restants")]
        public int Visarestants { get; set; }

        public virtual RubriqueDto? Rubrique { get; set; }

        [Display(Name = "Bénéficiaire")]
        public virtual InscriptionDto? IdinscritNavigation { get; set; }

        // public virtual ICollection<MeetVisa> MeetVisas { get; set; }
        
        [Display(Name = "Séance")]
        public virtual SeanceDto? Seance { get; set; }
    }
}
