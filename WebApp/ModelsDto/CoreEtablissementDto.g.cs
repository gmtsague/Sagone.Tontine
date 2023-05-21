using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CoreEtablissementDto
    {
        public int EtabId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public long? CountryId { get; set; }
        public string Libelle { get; set; }
        public string? Adresse { get; set; }
        public DateOnly? Creationdate { get; set; }
        public string DeployedUrl { get; set; }
        public string? DatabaseName { get; set; }
        public string? ConnString { get; set; }
        public bool EnableMultiAntenne { get; set; }
        public ICollection<CoreAnnualSettingDto> CoreAnnualSettings { get; set; }
        public ICollection<CoreBankaccountDto> CoreBankaccounts { get; set; }
        public ICollection<CorePersonDto> CorePeople { get; set; }
        public ICollection<CorePhotoDto> CorePhotos { get; set; }
        public CoreCountryDto? Country { get; set; }
        public ICollection<MeetAntenneDto> MeetAntennes { get; set; }
        public ICollection<MeetBureauDto> MeetBureaus { get; set; }
    }
}