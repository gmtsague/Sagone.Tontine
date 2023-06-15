using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class CoreBankaccount
{
    public long AccountId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long? EtabId { get; set; }

    public long? PersonId { get; set; }

    public long BankId { get; set; }

    public string CompteNo { get; set; } = null!;

    public byte[] IsActive { get; set; } = null!;

    public byte[] Solde { get; set; } = null!;

    public byte[] IsDefault { get; set; } = null!;

    public virtual CoreBank Bank { get; set; } = null!;

    public virtual CoreEtablissement? Etab { get; set; }

    public virtual CorePerson? Person { get; set; }
}
