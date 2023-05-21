using Tontine.Entities.Models;

namespace Tontine.Web.Services
{
    public class MyService : IService
    {
        private readonly LabosContext _context;
        public MyService(LabosContext context)
        {
            _context = context;
        }

        public void AddYear(CoreAnnee value)
        {
            throw new NotImplementedException();
        }

        public void CloseYear(CoreAnnee value)
        {
            throw new NotImplementedException();
        }

        public void DeleteYear(CoreAnnee value)
        {
            throw new NotImplementedException();
        }

        public void DeleteYear(long value)
        {
            throw new NotImplementedException();
        }

        public CoreAnnee GetCurrentYear()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CoreAnnee> GetYears()
        {
            throw new NotImplementedException();
        }

        public void SetCurrentYear(CoreAnnee value)
        {
            throw new NotImplementedException();
        }

        public void UpdateYear(CoreAnnee value)
        {
            throw new NotImplementedException();
        }
    }
}
