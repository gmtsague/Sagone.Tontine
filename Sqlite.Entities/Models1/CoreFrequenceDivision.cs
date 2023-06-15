using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models1;

public partial class CoreFrequenceDivision
{
    public long FrequenceId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public string Libelle { get; set; } = null!;

    public long NbDays { get; set; }

    public virtual ICollection<CoreAnnee> CoreAnnees { get; set; } = new List<CoreAnnee>();
}
