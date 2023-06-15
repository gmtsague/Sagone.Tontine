using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models1;

public partial class MeetAntenne
{
    public long AntenneId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long EtabId { get; set; }

    public string Libelle { get; set; } = null!;

    public byte[]? Creationdate { get; set; }

    public virtual CoreEtablissement Etab { get; set; } = null!;

    public virtual ICollection<MeetInscription> MeetInscriptions { get; set; } = new List<MeetInscription>();

    public virtual ICollection<MeetSeance> MeetSeances { get; set; } = new List<MeetSeance>();
}
