using Tontine.Entities.ModelsDto;

namespace Tontine.Entities.ModelsDto
{
    public partial class MeetPreferenceDto
    {
        public int SettingId { get; set; }
        public decimal TauxInteretMensuel { get; set; }
        public decimal TauxInteretPenalite { get; set; }
        public decimal TauxPenaliteCotisation { get; set; }
        public bool? EnableAutoGenPresence { get; set; }
        public bool EnableSigningOutcome { get; set; }
        public bool? EnableMaxDelayPenalites { get; set; }
        public bool? EnableAutoDispatchIncome { get; set; }
        public bool EnableFixedAmountFees { get; set; }
        public bool EnableSecoursInsurance { get; set; }
        public bool EnableFixedFeesByAnten { get; set; }
        public CoreAnnualSettingDto Setting { get; set; }
    }
}