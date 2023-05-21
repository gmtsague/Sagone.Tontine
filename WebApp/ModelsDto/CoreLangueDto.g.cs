using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CoreLangueDto
    {
        public int LangueId { get; set; }
        public string Libelle { get; set; }
        public string Isocode { get; set; }
        public bool IsDefault { get; set; }
        public bool IsActive { get; set; }
        public ICollection<CoreUserDto> CoreUsers { get; set; }
    }
}