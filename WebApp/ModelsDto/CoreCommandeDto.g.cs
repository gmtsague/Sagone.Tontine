using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CoreCommandeDto
    {
        public int Idcmde { get; set; }
        public string Libelle { get; set; }
        public ICollection<CoreAutorisationDto> CoreAutorisations { get; set; }
    }
}