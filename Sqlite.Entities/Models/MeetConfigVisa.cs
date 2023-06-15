using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class MeetConfigVisa
{
    public long ConfigvisaId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long PosteId { get; set; }

    public long AnneeId { get; set; }

    public long TyperubId { get; set; }

    public long Numordre { get; set; }

    public byte[] SignByOrdre { get; set; } = null!;

    public virtual CoreAnnee Annee { get; set; } = null!;

    public virtual ICollection<MeetVisa> MeetVisas { get; set; } = new List<MeetVisa>();

    public virtual MeetPoste Poste { get; set; } = null!;

    public virtual MeetTypeRubrique Typerub { get; set; } = null!;
}
