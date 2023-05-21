using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class CoreUserMapper
    {
        public static CoreUserDto AdaptToDto(this CoreUser p1)
        {
            return p1 == null ? null : new CoreUserDto()
            {
                UserId = p1.UserId,
                ProfilId = p1.ProfilId,
                LangueId = p1.LangueId,
                Username = p1.Username,
                Passwd = p1.Passwd,
                IsActif = p1.IsActif,
                ExpirationDate = p1.ExpirationDate,
                LastConnexion = p1.LastConnexion,
                Langue = p1.Langue == null ? null : new CoreLangueDto()
                {
                    LangueId = p1.Langue.LangueId,
                    Libelle = p1.Langue.Libelle,
                    Isocode = p1.Langue.Isocode,
                    IsDefault = p1.Langue.IsDefault,
                    IsActive = p1.Langue.IsActive
                },
                Profil = p1.Profil == null ? null : new CoreProfilDto()
                {
                    ProfilId = p1.Profil.ProfilId,
                    Libelle = p1.Profil.Libelle,
                    Candelete = p1.Profil.Candelete
                }
            };
        }
        public static CoreUserDto AdaptTo(this CoreUser p2, CoreUserDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CoreUserDto result = p3 ?? new CoreUserDto();
            
            result.UserId = p2.UserId;
            result.ProfilId = p2.ProfilId;
            result.LangueId = p2.LangueId;
            result.Username = p2.Username;
            result.Passwd = p2.Passwd;
            result.IsActif = p2.IsActif;
            result.ExpirationDate = p2.ExpirationDate;
            result.LastConnexion = p2.LastConnexion;
            result.Langue = funcMain1(p2.Langue, result.Langue);
            result.Profil = funcMain2(p2.Profil, result.Profil);
            return result;
            
        }
        
        private static CoreLangueDto funcMain1(CoreLangue p4, CoreLangueDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            CoreLangueDto result = p5 ?? new CoreLangueDto();
            
            result.LangueId = p4.LangueId;
            result.Libelle = p4.Libelle;
            result.Isocode = p4.Isocode;
            result.IsDefault = p4.IsDefault;
            result.IsActive = p4.IsActive;
            return result;
            
        }
        
        private static CoreProfilDto funcMain2(CoreProfil p6, CoreProfilDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            CoreProfilDto result = p7 ?? new CoreProfilDto();
            
            result.ProfilId = p6.ProfilId;
            result.Libelle = p6.Libelle;
            result.Candelete = p6.Candelete;
            return result;
            
        }
    }
}