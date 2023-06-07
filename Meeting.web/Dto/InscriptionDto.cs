using Mapster;
using MeetingEntities.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Meeting.Web.Dto
{
    public class InscriptionDto: BaseDto<InscriptionDto, MeetInscription>
    {
        /// <summary>
        /// Identifiant de l&apos;inscription
        /// </summary>
        [Key]
        public int Idinscrit { get; set; }

        /// <summary>
        /// Etab_id
        /// </summary>
        [Display( Name="etab_id")]
        public int EtabId { get; set; }

        /// <summary>
        /// Identifiant de l&apos;antenne
        /// </summary>
        [Display( Name="antenne_id")]
        public int AntenneId { get; set; }

        /// <summary>
        /// Person_id
        /// </summary>
        [Display( Name="person_id")]
        public int PersonId { get; set; }

        /// <summary>
        /// Identifiant de l&apos;annee
        /// </summary>
        [Display( Name="annee_id")]
        public int AnneeId { get; set; }

        /// <summary>
        /// Date de l&apos;inscription
        /// </summary>
        [Display( Name="dateinscrit")]
        public DateOnly Dateinscrit { get; set; }

        /// <summary>
        /// Date de derniere suspension d&apos;un membre
        /// </summary>
        [Display( Name="datesuspension")]
        public DateOnly? Datesuspension { get; set; }

        /// <summary>
        /// Statut actif ou non d&apos;un membre
        /// </summary>
        [Display( Name="is_active")]
        public bool IsActive { get; set; }

        /// <summary>
        /// Nocni
        /// </summary>
        [Display( Name="nocni")]
        [StringLength(32)]
        public string? Nocni { get; set; } 

        /// <summary>
        /// SoldeDebut
        /// </summary>
        [Display( Name="soldedebut")]
        public decimal Soldedebut { get; set; }

        /// <summary>
        /// SoldeFin
        /// </summary>
        [Display( Name="soldefin")]
        public decimal? Soldefin { get; set; }

        /// <summary>
        /// Report a nouveau du membre pour la nouvelle annee
        /// </summary>
        [Display( Name="tauxcotisation")]
        public decimal Tauxcotisation { get; set; }

        /// <summary>
        /// Total_verse
        /// </summary>
        [Display( Name="total_verse")]
        public decimal TotalVerse { get; set; }

        /// <summary>
        /// Dettes cumulees applicable la nouvelle annee
        /// </summary>
        [Display( Name="cumuldettes")]
        public decimal? Cumuldettes { get; set; }

        /// <summary>
        /// Dettes cumules de penelites applicable la nouvelle annee
        /// </summary>
        [Display( Name="cumulpenalites")]
        public decimal? Cumulpenalites { get; set; }

        /// <summary>
        /// Indique si le membre est endette
        /// </summary>
        [Display( Name="endette")]
        public bool Endette { get; set; }

        /// <summary>
        /// Report a nouveau indiquant les dettes d&apos;un membre au terme d&apos;un exercice precedent
        /// </summary>
        [Display( Name="report_nouveau")]
        public decimal ReportNouveau { get; set; }

        [Display(Name = "Full Name")]
        [StringLength(128)]
        public string? FullName { get; set; }

        [Display(Name = "AnneeId")]
        public virtual AnneeDto? Annee { get; set; } 

        [Display(Name = "Antenne")]
        public virtual AntenneDto? Antenne { get; set; } 

        //[Display( Name="IdinscritNavigation")]
        public virtual ICollection<MembreBureauDto>? MembreBureaus { get; set; }

        //[Display( Name="IdinscritNavigation")]
        public virtual ICollection<OrdrePassageDto>? OrdrePassages { get; set; }

        //     public virtual ICollection<PresenceDto> MeetPresences { get; set; }

        //[Display( Name="IdinscritNavigation")]
        //public virtual ICollection<PretDto> Prets { get; set; }

        //[Display( Name="IdinscritNavigation")]
        public virtual ICollection<SortieCaisseDto>? SortieCaisses { get; set; }

        //[Display( Name="IdinscritNavigation")]
        //    public virtual ICollection<VisaDto> MeetVisas { get; set; }

        [Display(Name ="PersonId")]
        public virtual PersonDto? Person { get; set; } 
        
        public override void AddCustomMappings()
        {
            //SetCustomMappings()
            //    .Map(dest => dest.full, src => src.Dateop)
            //    .Map(dest => dest.Userid, src => src.UserId);

            SetCustomMappingsInverse()
                .Map(dest => dest.FullName, src => (src.Person==null)? $"Member's Name" : $"{src.Person.Nom} {src.Person.Prenom}")
                .Map(dest => dest.Antenne, src => AntenneDto.FromEntity(src.MeetAntenne))
                .Map(dest => dest.Person, src => src.Person.Adapt<PersonDto>());
        }
    }
}
