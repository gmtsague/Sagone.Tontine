using System;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CorePhotoDto
    {
        public long PhotoId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public int? EtabId { get; set; }
        public int? PersonId { get; set; }
        public string Image { get; set; }
        public string? Filename { get; set; }
        public string Fileext { get; set; }
        public bool IsSignature { get; set; }
        public string? Filepath { get; set; }
        public int MaxAllowLiens { get; set; }
        public int NbActualLiens { get; set; }
        public CoreEtablissementDto? Etab { get; set; }
        public CorePersonDto? Person { get; set; }
    }
}