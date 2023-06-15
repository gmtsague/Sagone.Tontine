using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models1;

public partial class MeetPoste
{
    public long PosteId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public byte[] Libelle { get; set; } = null!;

    public string Code { get; set; } = null!;

    public virtual ICollection<MeetConfigVisa> MeetConfigVisas { get; set; } = new List<MeetConfigVisa>();

    public virtual ICollection<MeetMembreBureau> MeetMembreBureaus { get; set; } = new List<MeetMembreBureau>();
}
