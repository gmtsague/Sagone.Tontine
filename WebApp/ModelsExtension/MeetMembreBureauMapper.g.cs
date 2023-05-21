using Tontine.Entities.Models_v1_4_sans;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public static partial class MeetMembreBureauMapper
    {
        public static MeetMembreBureauDto AdaptToDto(this MeetMembreBureau p1)
        {
            return p1 == null ? null : new MeetMembreBureauDto()
            {
                BureaudetailsId = p1.BureaudetailsId,
                CreateUid = p1.CreateUid,
                UpdateUid = p1.UpdateUid,
                Idinscrit = p1.Idinscrit,
                PosteId = p1.PosteId,
                BureauId = p1.BureauId,
                Bureau = p1.Bureau == null ? null : new MeetBureauDto()
                {
                    BureauId = p1.Bureau.BureauId,
                    CreateUid = p1.Bureau.CreateUid,
                    UpdateUid = p1.Bureau.UpdateUid,
                    EtabId = p1.Bureau.EtabId,
                    Libelle = p1.Bureau.Libelle,
                    Debut = p1.Bureau.Debut,
                    Fin = p1.Bureau.Fin,
                    Nbperson = p1.Bureau.Nbperson,
                    Nbvotes = p1.Bureau.Nbvotes,
                    Nbabstention = p1.Bureau.Nbabstention,
                    Resumevote = p1.Bureau.Resumevote,
                    Etab = p1.Bureau.Etab == null ? null : new CoreEtablissementDto()
                    {
                        EtabId = p1.Bureau.Etab.EtabId,
                        CreateUid = p1.Bureau.Etab.CreateUid,
                        UpdateUid = p1.Bureau.Etab.UpdateUid,
                        CountryId = p1.Bureau.Etab.CountryId,
                        Libelle = p1.Bureau.Etab.Libelle,
                        Adresse = p1.Bureau.Etab.Adresse,
                        Creationdate = p1.Bureau.Etab.Creationdate,
                        DeployedUrl = p1.Bureau.Etab.DeployedUrl,
                        DatabaseName = p1.Bureau.Etab.DatabaseName,
                        ConnString = p1.Bureau.Etab.ConnString,
                        EnableMultiAntenne = p1.Bureau.Etab.EnableMultiAntenne,
                        Country = p1.Bureau.Etab.Country == null ? null : new CoreCountryDto()
                        {
                            CountryId = p1.Bureau.Etab.Country.CountryId,
                            CreateUid = p1.Bureau.Etab.Country.CreateUid,
                            UpdateUid = p1.Bureau.Etab.Country.UpdateUid,
                            Libelle = p1.Bureau.Etab.Country.Libelle,
                            CodeIso2 = p1.Bureau.Etab.Country.CodeIso2,
                            CodeIso3 = p1.Bureau.Etab.Country.CodeIso3,
                            PhoneCode = p1.Bureau.Etab.Country.PhoneCode,
                            Devise = p1.Bureau.Etab.Country.Devise
                        }
                    }
                },
                Poste = p1.Poste == null ? null : new MeetPosteDto()
                {
                    PosteId = p1.Poste.PosteId,
                    CreateUid = p1.Poste.CreateUid,
                    UpdateUid = p1.Poste.UpdateUid,
                    Libelle = p1.Poste.Libelle,
                    Code = p1.Poste.Code
                }
            };
        }
        public static MeetMembreBureauDto AdaptTo(this MeetMembreBureau p2, MeetMembreBureauDto p3)
        {
            if (p2 == null)
            {
                return null;
            }
            MeetMembreBureauDto result = p3 ?? new MeetMembreBureauDto();
            
            result.BureaudetailsId = p2.BureaudetailsId;
            result.CreateUid = p2.CreateUid;
            result.UpdateUid = p2.UpdateUid;
            result.Idinscrit = p2.Idinscrit;
            result.PosteId = p2.PosteId;
            result.BureauId = p2.BureauId;
            result.Bureau = funcMain1(p2.Bureau, result.Bureau);
            result.Poste = funcMain4(p2.Poste, result.Poste);
            return result;
            
        }
        
        private static MeetBureauDto funcMain1(MeetBureau p4, MeetBureauDto p5)
        {
            if (p4 == null)
            {
                return null;
            }
            MeetBureauDto result = p5 ?? new MeetBureauDto();
            
            result.BureauId = p4.BureauId;
            result.CreateUid = p4.CreateUid;
            result.UpdateUid = p4.UpdateUid;
            result.EtabId = p4.EtabId;
            result.Libelle = p4.Libelle;
            result.Debut = p4.Debut;
            result.Fin = p4.Fin;
            result.Nbperson = p4.Nbperson;
            result.Nbvotes = p4.Nbvotes;
            result.Nbabstention = p4.Nbabstention;
            result.Resumevote = p4.Resumevote;
            result.Etab = funcMain2(p4.Etab, result.Etab);
            return result;
            
        }
        
        private static MeetPosteDto funcMain4(MeetPoste p10, MeetPosteDto p11)
        {
            if (p10 == null)
            {
                return null;
            }
            MeetPosteDto result = p11 ?? new MeetPosteDto();
            
            result.PosteId = p10.PosteId;
            result.CreateUid = p10.CreateUid;
            result.UpdateUid = p10.UpdateUid;
            result.Libelle = p10.Libelle;
            result.Code = p10.Code;
            return result;
            
        }
        
        private static CoreEtablissementDto funcMain2(CoreEtablissement p6, CoreEtablissementDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            CoreEtablissementDto result = p7 ?? new CoreEtablissementDto();
            
            result.EtabId = p6.EtabId;
            result.CreateUid = p6.CreateUid;
            result.UpdateUid = p6.UpdateUid;
            result.CountryId = p6.CountryId;
            result.Libelle = p6.Libelle;
            result.Adresse = p6.Adresse;
            result.Creationdate = p6.Creationdate;
            result.DeployedUrl = p6.DeployedUrl;
            result.DatabaseName = p6.DatabaseName;
            result.ConnString = p6.ConnString;
            result.EnableMultiAntenne = p6.EnableMultiAntenne;
            result.Country = funcMain3(p6.Country, result.Country);
            return result;
            
        }
        
        private static CoreCountryDto funcMain3(CoreCountry p8, CoreCountryDto p9)
        {
            if (p8 == null)
            {
                return null;
            }
            CoreCountryDto result = p9 ?? new CoreCountryDto();
            
            result.CountryId = p8.CountryId;
            result.CreateUid = p8.CreateUid;
            result.UpdateUid = p8.UpdateUid;
            result.Libelle = p8.Libelle;
            result.CodeIso2 = p8.CodeIso2;
            result.CodeIso3 = p8.CodeIso3;
            result.PhoneCode = p8.PhoneCode;
            result.Devise = p8.Devise;
            return result;
            
        }
    }
}