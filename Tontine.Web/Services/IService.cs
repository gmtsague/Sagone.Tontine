using Tontine.Entities.Models;

namespace Tontine.Web.Services
{
    public interface IService
    {
        public void AddYear(CoreAnnee value);
        public void UpdateYear(CoreAnnee value);
        public void DeleteYear(CoreAnnee value);
        public void DeleteYear(long value);
        public IEnumerable<CoreAnnee> GetYears();
        public CoreAnnee GetCurrentYear();
        public void SetCurrentYear(CoreAnnee value);
        public void CloseYear(CoreAnnee value);
    }
}
