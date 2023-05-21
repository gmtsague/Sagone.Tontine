using System;
using System.Collections.Generic;
using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class CorePersonDto
    {
        public int PersonId { get; set; }
        public long? CreateUid { get; set; }
        public long? UpdateUid { get; set; }
        public long? CountryId { get; set; }
        public int? EtabId { get; set; }
        public string Nom { get; set; }
        public string? Prenom { get; set; }
        public DateOnly? Datenais { get; set; }
        public string? Lieunais { get; set; }
        public string Sexe { get; set; }
        public string? Email { get; set; }
        public string? Adresse { get; set; }
        public DateOnly AdhesionDate { get; set; }
        public string Nocni { get; set; }
        public DateOnly CniExpireDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsVisible { get; set; }
        public string? AnneePromo { get; set; }
        public ICollection<CoreBankaccountDto> CoreBankaccounts { get; set; }
        public ICollection<CorePhonenumberDto> CorePhonenumbers { get; set; }
        public ICollection<CorePhotoDto> CorePhotos { get; set; }
        public CoreCountryDto? Country { get; set; }
        public CoreEtablissementDto? Etab { get; set; }
        public ICollection<MeetEngagementDto> MeetEngagements { get; set; }
        public ICollection<MeetInscriptionDto> MeetInscriptions { get; set; }
        public ICollection<MeetSuspensionMembreDto> MeetSuspensionMembres { get; set; }
    }
}