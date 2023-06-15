using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class MeetMembreBureau
{
    public long BureaudetailsId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long Idinscrit { get; set; }

    public long PosteId { get; set; }

    public long BureauId { get; set; }

    public virtual MeetBureau Bureau { get; set; } = null!;

    public virtual MeetInscription IdinscritNavigation { get; set; } = null!;

    public virtual MeetPoste Poste { get; set; } = null!;
}
