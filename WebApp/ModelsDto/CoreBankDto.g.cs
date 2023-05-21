using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CoreBankDto
    {
        public int BankId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public long? CountryId { get; set; }
        public string Libelle { get; set; }
        public string? Adresse { get; set; }
        public string? Email { get; set; }
        public string Coderib { get; set; }
        public ICollection<CoreBankaccountDto> CoreBankaccounts { get; set; }
        public ICollection<CorePhonenumberDto> CorePhonenumbers { get; set; }
        public CoreCountryDto? Country { get; set; }
    }
}