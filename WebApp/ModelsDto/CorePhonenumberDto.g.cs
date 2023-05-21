using System;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CorePhonenumberDto
    {
        public long PhoneId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public long CountryId { get; set; }
        public int? BankId { get; set; }
        public int? PersonId { get; set; }
        public string PhoneNo { get; set; }
        public bool IsDefaut { get; set; }
        public CoreBankDto? Bank { get; set; }
        public CoreCountryDto Country { get; set; }
        public CorePersonDto? Person { get; set; }
    }
}