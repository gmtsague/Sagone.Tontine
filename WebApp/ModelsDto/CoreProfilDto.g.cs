using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CoreProfilDto
    {
        public int ProfilId { get; set; }
        public string Libelle { get; set; }
        public bool Candelete { get; set; }
        public ICollection<CoreAutorisationDto> CoreAutorisations { get; set; }
        public ICollection<CoreUserDto> CoreUsers { get; set; }
    }
}