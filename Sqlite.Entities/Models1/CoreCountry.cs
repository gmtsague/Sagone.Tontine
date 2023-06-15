using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models1;

public partial class CoreCountry
{
    public long CountryId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public byte[] Libelle { get; set; } = null!;

    public string CodeIso2 { get; set; } = null!;

    public string CodeIso3 { get; set; } = null!;

    public string PhoneCode { get; set; } = null!;

    public string? Devise { get; set; }

    public virtual ICollection<CoreBank> CoreBanks { get; set; } = new List<CoreBank>();

    public virtual ICollection<CoreEtablissement> CoreEtablissements { get; set; } = new List<CoreEtablissement>();

    public virtual ICollection<CorePerson> CorePeople { get; set; } = new List<CorePerson>();

    public virtual ICollection<CorePhonenumber> CorePhonenumbers { get; set; } = new List<CorePhonenumber>();
}
