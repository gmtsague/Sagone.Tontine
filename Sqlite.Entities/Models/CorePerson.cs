using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class CorePerson
{
    public long PersonId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long? CountryId { get; set; }

    public long? EtabId { get; set; }

    public string Nom { get; set; } = null!;

    public string? Prenom { get; set; }

    public byte[]? Datenais { get; set; }

    public string? Lieunais { get; set; }

    public string Sexe { get; set; } = null!;

    public string? Email { get; set; }

    public string? Adresse { get; set; }

    public byte[] AdhesionDate { get; set; } = null!;

    public string Nocni { get; set; } = null!;

    public byte[] CniExpireDate { get; set; } = null!;

    public byte[]? IsActive { get; set; }

    public byte[] IsVisible { get; set; } = null!;

    public string? AnneePromo { get; set; }

    public virtual ICollection<CoreBankaccount> CoreBankaccounts { get; set; } = new List<CoreBankaccount>();

    public virtual ICollection<CorePhonenumber> CorePhonenumbers { get; set; } = new List<CorePhonenumber>();

    public virtual ICollection<CorePhoto> CorePhotos { get; set; } = new List<CorePhoto>();

    public virtual CoreCountry? Country { get; set; }

    public virtual CoreEtablissement? Etab { get; set; }

    public virtual ICollection<MeetEngagement> MeetEngagements { get; set; } = new List<MeetEngagement>();

    public virtual ICollection<MeetInscription> MeetInscriptions { get; set; } = new List<MeetInscription>();

    public virtual ICollection<MeetSuspensionMembre> MeetSuspensionMembres { get; set; } = new List<MeetSuspensionMembre>();
}
