using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class CorePhonenumber
{
    public long PhoneId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long CountryId { get; set; }

    public long? BankId { get; set; }

    public long? PersonId { get; set; }

    public string PhoneNo { get; set; } = null!;

    public byte[] IsDefaut { get; set; } = null!;

    public virtual CoreBank? Bank { get; set; }

    public virtual CoreCountry Country { get; set; } = null!;

    public virtual CorePerson? Person { get; set; }
}
