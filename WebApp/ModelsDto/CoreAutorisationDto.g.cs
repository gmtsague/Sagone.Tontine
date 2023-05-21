using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CoreAutorisationDto
    {
        public int ChoixId { get; set; }
        public int ProfilId { get; set; }
        public int Idcmde { get; set; }
        public bool IsActive { get; set; }
        public CoreCommandeDto IdcmdeNavigation { get; set; }
        public CoreProfilDto Profil { get; set; }
    }
}