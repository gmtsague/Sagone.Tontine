using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class CoreBank
{
    public long BankId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long? CountryId { get; set; }

    public string Libelle { get; set; } = null!;

    public string? Adresse { get; set; }

    public string? Email { get; set; }

    public string Coderib { get; set; } = null!;

    public virtual ICollection<CoreBankaccount> CoreBankaccounts { get; set; } = new List<CoreBankaccount>();

    public virtual ICollection<CorePhonenumber> CorePhonenumbers { get; set; } = new List<CorePhonenumber>();

    public virtual CoreCountry? Country { get; set; }
}
