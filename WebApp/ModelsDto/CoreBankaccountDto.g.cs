using System;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CoreBankaccountDto
    {
        public int AccountId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int? EtabId { get; set; }
        public int? PersonId { get; set; }
        public int BankId { get; set; }
        public string CompteNo { get; set; }
        public bool IsActive { get; set; }
        public decimal Solde { get; set; }
        public CoreBankDto Bank { get; set; }
        public CoreEtablissementDto? Etab { get; set; }
        public CorePersonDto? Person { get; set; }
    }
}