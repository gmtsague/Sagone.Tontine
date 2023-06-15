using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models1;

public partial class CoreAnnee
{
    public long AnneeId { get; set; }

    public long? CreateUid { get; set; }

    public long? UpdateUid { get; set; }

    public byte[] CreateAt { get; set; } = null!;

    public byte[] UpdateAt { get; set; } = null!;

    public long? FrequenceId { get; set; }

    public long? BureauId { get; set; }

    public string Libelle { get; set; } = null!;

    public byte[] Datedebut { get; set; } = null!;

    public byte[] Datefin { get; set; } = null!;

    public byte[] IsCurrent { get; set; } = null!;

    public byte[] IsClosed { get; set; } = null!;

    public long Nbdivision { get; set; }

    public virtual MeetBureau? Bureau { get; set; }

    public virtual ICollection<CoreSubdivision> CoreSubdivisions { get; set; } = new List<CoreSubdivision>();

    public virtual CoreFrequenceDivision? Frequence { get; set; }

    public virtual ICollection<MeetConfigVisa> MeetConfigVisas { get; set; } = new List<MeetConfigVisa>();

    public virtual ICollection<MeetInscription> MeetInscriptions { get; set; } = new List<MeetInscription>();

    public virtual ICollection<MeetMaxAllowSignature> MeetMaxAllowSignatures { get; set; } = new List<MeetMaxAllowSignature>();

    public virtual ICollection<MeetPreference> MeetPreferenceAnnees { get; set; } = new List<MeetPreference>();

    public virtual ICollection<MeetPreference> MeetPreferencePreviousYearNavigations { get; set; } = new List<MeetPreference>();

    public virtual ICollection<MeetRubrique> MeetRubriques { get; set; } = new List<MeetRubrique>();
}
