using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models1;

public partial class MeetBureau
{
    public long BureauId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long? EtabId { get; set; }

    public string Libelle { get; set; } = null!;

    public byte[] Debut { get; set; } = null!;

    public byte[] Fin { get; set; } = null!;

    public long Nbperson { get; set; }

    public long Nbvotes { get; set; }

    public long Nbabstention { get; set; }

    public string? Resumevote { get; set; }

    public virtual ICollection<CoreAnnee> CoreAnnees { get; set; } = new List<CoreAnnee>();

    public virtual CoreEtablissement? Etab { get; set; }

    public virtual ICollection<MeetMembreBureau> MeetMembreBureaus { get; set; } = new List<MeetMembreBureau>();
}
