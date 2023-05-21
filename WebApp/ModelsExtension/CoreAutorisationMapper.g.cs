using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class CoreAutorisationMapper
    {
        public static CoreAutorisationDto AdaptToDto(this CoreAutorisation p1)
        {
            return p1 == null ? null : new CoreAutorisationDto()
            {
                ChoixId = p1.ChoixId,
                ProfilId = p1.ProfilId,
                Idcmde = p1.Idcmde,
                IsActive = p1.IsActive,
                Profil = p1.Profil == null ? null : new CoreProfilDto()
                {
                    ProfilId = p1.Profil.ProfilId,
                    Libelle = p1.Profil.Libelle,
                    Candelete = p1.Profil.Candelete
                }
            };
        }
        public static CoreAutorisationDto AdaptTo(this CoreAutorisation p2, CoreAutorisationDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CoreAutorisationDto result = p3 ?? new CoreAutorisationDto();
            
            result.ChoixId = p2.ChoixId;
            result.ProfilId = p2.ProfilId;
            result.Idcmde = p2.Idcmde;
            result.IsActive = p2.IsActive;
            result.Profil = funcMain1(p2.Profil, result.Profil);
            return result;
            
        }
        
        private static CoreProfilDto funcMain1(CoreProfil p4, CoreProfilDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            CoreProfilDto result = p5 ?? new CoreProfilDto();
            
            result.ProfilId = p4.ProfilId;
            result.Libelle = p4.Libelle;
            result.Candelete = p4.Candelete;
            return result;
            
        }
    }
}