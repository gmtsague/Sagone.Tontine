using System;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CoreAnnualSettingDto
    {
        public int SettingId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int AnneeId { get; set; }
        public int EtabId { get; set; }
        public int MaxAllowPhotoLiens { get; set; }
        public bool Copyengagements { get; set; }
        public bool Copymembers { get; set; }
        public CoreAnneeDto Annee { get; set; }
        public CoreEtablissementDto Etab { get; set; }
        public MeetPreferenceDto? MeetPreference { get; set; }
    }
}