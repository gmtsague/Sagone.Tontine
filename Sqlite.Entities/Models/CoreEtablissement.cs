using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class CoreEtablissement
{
    public long EtabId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long? CountryId { get; set; }

    public string Libelle { get; set; } = null!;

    public string? Adresse { get; set; }

    public byte[]? Creationdate { get; set; }

    public string DeployedUrl { get; set; } = null!;

    public string? DatabaseName { get; set; }

    public string? ConnString { get; set; }

    public byte[] EnableMultiAntenne { get; set; } = null!;

    public virtual ICollection<CoreBankaccount> CoreBankaccounts { get; set; } = new List<CoreBankaccount>();

    public virtual ICollection<CorePerson> CorePeople { get; set; } = new List<CorePerson>();

    public virtual ICollection<CorePhoto> CorePhotos { get; set; } = new List<CorePhoto>();

    public virtual CoreCountry? Country { get; set; }

    public virtual ICollection<MeetAntenne> MeetAntennes { get; set; } = new List<MeetAntenne>();

    public virtual ICollection<MeetBureau> MeetBureaus { get; set; } = new List<MeetBureau>();

    public virtual ICollection<MeetPreference> MeetPreferences { get; set; } = new List<MeetPreference>();
}
