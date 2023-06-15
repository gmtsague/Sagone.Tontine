using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models;

public partial class MeetRubrique
{
    public long RubriqueId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long AnneeId { get; set; }

    public long TyperubId { get; set; }

    public string Libelle { get; set; } = null!;

    public long Nbmandataire { get; set; }

    public byte[] Montantroute { get; set; } = null!;

    public byte[] MontantPerson { get; set; } = null!;

    public byte[] IsOutcome { get; set; } = null!;

    public string? Commentaire { get; set; }

    public long Numordre { get; set; }

    public byte[] TopayEachPeriode { get; set; } = null!;

    public byte[] AllowCustomAmount { get; set; } = null!;

    public virtual CoreAnnee Annee { get; set; } = null!;

    public virtual ICollection<MeetEngagement> MeetEngagements { get; set; } = new List<MeetEngagement>();

    public virtual MeetTypeRubrique Typerub { get; set; } = null!;
}
