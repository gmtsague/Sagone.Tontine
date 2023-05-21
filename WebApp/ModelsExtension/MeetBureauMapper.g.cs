using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class MeetBureauMapper
    {
        public static MeetBureauDto AdaptToDto(this MeetBureau p1)
        {
            return p1 == null ? null : new MeetBureauDto()
            {
                BureauId = p1.BureauId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                EtabId = p1.EtabId,
                Libelle = p1.Libelle,
                Debut = p1.Debut,
                Fin = p1.Fin,
                Nbperson = p1.Nbperson,
                Nbvotes = p1.Nbvotes,
                Nbabstention = p1.Nbabstention,
                Resumevote = p1.Resumevote,
                Etab = p1.Etab == null ? null : new CoreEtablissementDto()
                {
                    EtabId = p1.Etab.EtabId,
                    CreateUid = p1.Etab.CreateUid,
                    UpdateUid = p1.Etab.UpdateUid,
                    CountryId = p1.Etab.CountryId,
                    Libelle = p1.Etab.Libelle,
                    Adresse = p1.Etab.Adresse,
                    Creationdate = p1.Etab.Creationdate,
                    DeployedUrl = p1.Etab.DeployedUrl,
                    DatabaseName = p1.Etab.DatabaseName,
                    ConnString = p1.Etab.ConnString,
                    EnableMultiAntenne = p1.Etab.EnableMultiAntenne,
                    Country = p1.Etab.Country == null ? null : new CoreCountryDto()
                    {
                        CountryId = p1.Etab.Country.CountryId,
                        CreateUid = p1.Etab.Country.CreateUid,
                        UpdateUid = p1.Etab.Country.UpdateUid,
                        Libelle = p1.Etab.Country.Libelle,
                        CodeIso2 = p1.Etab.Country.CodeIso2,
                        CodeIso3 = p1.Etab.Country.CodeIso3,
                        PhoneCode = p1.Etab.Country.PhoneCode,
                        Devise = p1.Etab.Country.Devise
                    }
                }
            };
        }
        public static MeetBureauDto AdaptTo(this MeetBureau p2, MeetBureauDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            MeetBureauDto result = p3 ?? new MeetBureauDto();
            
            result.BureauId = p2.BureauId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.EtabId = p2.EtabId;
            result.Libelle = p2.Libelle;
            result.Debut = p2.Debut;
            result.Fin = p2.Fin;
            result.Nbperson = p2.Nbperson;
            result.Nbvotes = p2.Nbvotes;
            result.Nbabstention = p2.Nbabstention;
            result.Resumevote = p2.Resumevote;
            result.Etab = funcMain1(p2.Etab, result.Etab);
            return result;
            
        }
        
        private static CoreEtablissementDto funcMain1(CoreEtablissement p4, CoreEtablissementDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            CoreEtablissementDto result = p5 ?? new CoreEtablissementDto();
            
            result.EtabId = p4.EtabId;
            result.CreateUid = p4.CreateUid;
            result.UpdateUid = p4.UpdateUid;
            result.CountryId = p4.CountryId;
            result.Libelle = p4.Libelle;
            result.Adresse = p4.Adresse;
            result.Creationdate = p4.Creationdate;
            result.DeployedUrl = p4.DeployedUrl;
            result.DatabaseName = p4.DatabaseName;
            result.ConnString = p4.ConnString;
            result.EnableMultiAntenne = p4.EnableMultiAntenne;
            result.Country = funcMain2(p4.Country, result.Country);
            return result;
            
        }
        
        private static CoreCountryDto funcMain2(CoreCountry p6, CoreCountryDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            CoreCountryDto result = p7 ?? new CoreCountryDto();
            
            result.CountryId = p6.CountryId;
            result.CreateUid = p6.CreateUid;
            result.UpdateUid = p6.UpdateUid;
            result.Libelle = p6.Libelle;
            result.CodeIso2 = p6.CodeIso2;
            result.CodeIso3 = p6.CodeIso3;
            result.PhoneCode = p6.PhoneCode;
            result.Devise = p6.Devise;
            return result;
            
        }
    }
}