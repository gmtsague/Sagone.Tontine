using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class CoreProfilMapper
    {
        public static CoreProfilDto AdaptToDto(this CoreProfil p1)
        {
            return p1 == null ? null : new CoreProfilDto()
            {
                ProfilId = p1.ProfilId,
                Libelle = p1.Libelle,
                Candelete = p1.Candelete
            };
        }
        public static CoreProfilDto AdaptTo(this CoreProfil p2, CoreProfilDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CoreProfilDto result = p3 ?? new CoreProfilDto();
            
            result.ProfilId = p2.ProfilId;
            result.Libelle = p2.Libelle;
            result.Candelete = p2.Candelete;
            return result;
            
        }
    }
}