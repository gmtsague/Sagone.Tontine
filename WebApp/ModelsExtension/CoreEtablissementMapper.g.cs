using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class CoreEtablissementMapper
    {
        public static CoreEtablissementDto AdaptToDto(this CoreEtablissement p1)
        {
            return p1 == null ? null : new CoreEtablissementDto()
            {
                EtabId = p1.EtabId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                CountryId = p1.CountryId,
                Libelle = p1.Libelle,
                Adresse = p1.Adresse,
                Creationdate = p1.Creationdate,
                DeployedUrl = p1.DeployedUrl,
                DatabaseName = p1.DatabaseName,
                ConnString = p1.ConnString,
                EnableMultiAntenne = p1.EnableMultiAntenne,
                Country = p1.Country == null ? null : new CoreCountryDto()
                {
                    CountryId = p1.Country.CountryId,
                    CreateUid = p1.Country.CreateUid,
                    UpdateUid = p1.Country.UpdateUid,
                    Libelle = p1.Country.Libelle,
                    CodeIso2 = p1.Country.CodeIso2,
                    CodeIso3 = p1.Country.CodeIso3,
                    PhoneCode = p1.Country.PhoneCode,
                    Devise = p1.Country.Devise
                }
            };
        }
        public static CoreEtablissementDto AdaptTo(this CoreEtablissement p2, CoreEtablissementDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CoreEtablissementDto result = p3 ?? new CoreEtablissementDto();
            
            result.EtabId = p2.EtabId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.CountryId = p2.CountryId;
            result.Libelle = p2.Libelle;
            result.Adresse = p2.Adresse;
            result.Creationdate = p2.Creationdate;
            result.DeployedUrl = p2.DeployedUrl;
            result.DatabaseName = p2.DatabaseName;
            result.ConnString = p2.ConnString;
            result.EnableMultiAntenne = p2.EnableMultiAntenne;
            result.Country = funcMain1(p2.Country, result.Country);
            return result;
            
        }
        
        private static CoreCountryDto funcMain1(CoreCountry p4, CoreCountryDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            CoreCountryDto result = p5 ?? new CoreCountryDto();
            
            result.CountryId = p4.CountryId;
            result.CreateUid = p4.CreateUid;
            result.UpdateUid = p4.UpdateUid;
            result.Libelle = p4.Libelle;
            result.CodeIso2 = p4.CodeIso2;
            result.CodeIso3 = p4.CodeIso3;
            result.PhoneCode = p4.PhoneCode;
            result.Devise = p4.Devise;
            return result;
            
        }
    }
}