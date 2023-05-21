using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class CoreCommandeMapper
    {
        public static CoreCommandeDto AdaptToDto(this CoreCommande p1)
        {
            return p1 == null ? null : new CoreCommandeDto()
            {
                Idcmde = p1.Idcmde,
                Libelle = p1.Libelle
            };
        }
        public static CoreCommandeDto AdaptTo(this CoreCommande p2, CoreCommandeDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CoreCommandeDto result = p3 ?? new CoreCommandeDto();
            
            result.Idcmde = p2.Idcmde;
            result.Libelle = p2.Libelle;
            return result;
            
        }
    }
}