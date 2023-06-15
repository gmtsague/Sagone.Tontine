using System;
using System.Collections.Generic;

namespace Sqlite.Entities.Models1;

public partial class MeetPreference
{
    public long SettingId { get; set; }

    public long? EtabId { get; set; }

    public long? PreviousYear { get; set; }

    public long? AnneeId { get; set; }

    public byte[] DataFromPrevious { get; set; } = null!;

    public byte[] TauxInteretMensuel { get; set; } = null!;

    public byte[] TauxInteretPenalite { get; set; } = null!;

    public byte[] TauxPenaliteCotisation { get; set; } = null!;

    public byte[] EnableAutoGenPresence { get; set; } = null!;

    public byte[] EnableSigningOutcome { get; set; } = null!;

    public byte[] EnableMaxDelayPenalites { get; set; } = null!;

    public byte[] EnableAutoDispatchIncome { get; set; } = null!;

    public byte[] EnableFixedAmountFees { get; set; } = null!;

    public byte[] EnableSecoursInsurance { get; set; } = null!;

    public byte[] EnableFixedFeesByAnten { get; set; } = null!;

    public virtual CoreAnnee? Annee { get; set; }

    public virtual CoreEtablissement? Etab { get; set; }

    public virtual CoreAnnee? PreviousYearNavigation { get; set; }
}
