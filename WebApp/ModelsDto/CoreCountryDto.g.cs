using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CoreCountryDto
    {
        public long CountryId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public string Libelle { get; set; }
        public string CodeIso2 { get; set; }
        public string CodeIso3 { get; set; }
        public string PhoneCode { get; set; }
        public string? Devise { get; set; }
        public ICollection<CoreBankDto> CoreBanks { get; set; }
        public ICollection<CoreEtablissementDto> CoreEtablissements { get; set; }
        public ICollection<CorePersonDto> CorePeople { get; set; }
        public ICollection<CorePhonenumberDto> CorePhonenumbers { get; set; }
    }
}