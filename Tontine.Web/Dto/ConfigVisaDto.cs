using Tontine.Entities.Models;

namespace Tontine.Web.Dto
{
    public class ConfigvisaDto:BaseDto<ConfigvisaDto, Configvisa>
    {
        //public ConfigVisaDto() { }
        /// <summary>
        /// Identifiant de la configuration de signature
        /// </summary>
        public int Idconfigvisa { get; set; }

        /// <summary>
        /// Idposte
        /// </summary>
        public int Idposte { get; set; }

        /// <summary>
        /// Identifiant de l&apos;annee
        /// </summary>
        public int Idannee { get; set; }

        /// <summary>
        /// Identifiant du type d&apos;evenement
        /// </summary>
        public int Idtype { get; set; }

        /// <summary>
        /// Numero d&apos;ordre de la signature pour un type de document
        /// </summary>
        public int Numordre { get; set; }

        public string? LibelleAnnee { get; set; } 
        public string? LibelleRubrique { get; set; }
        public string? LibellePoste { get; set; }

        public override void AddCustomMappings()
        {
            //SetCustomMappings()
            //    .Map(dest => dest.Dateoperation, src => src.Dateop)
            //    .Map(dest => dest.Userid, src => src.UserId);

            SetCustomMappingsInverse()
                .Map(dest => dest.LibelleAnnee, src => src.IdanneeNavigation.Libelle)
                .Map(dest => dest.LibelleRubrique, src => src.IdtypeNavigation.Libelle)
                .Map(dest => dest.LibellePoste, src => src.IdposteNavigation.Libelle);
        }

    }
}
