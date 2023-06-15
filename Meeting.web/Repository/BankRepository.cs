using Arch.EntityFrameworkCore.UnitOfWork;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using MeetingEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Meeting.Web.Repository
{
    public interface IBankRepository
    {
        Task<int> Add(CoreBank NewValue);
        Task<int> Delete(int id);
        Task<IPagedList<CoreBank>> GetAll();
        Task<CoreBank?> GetDetails(int? id);
        IUnitOfWork GetUnitOfWork();
        Task<int> Update(int id, CoreBank NewValue);
    }

    public class BankRepository : IBankRepository
    {
        private readonly ILogger<BankRepository> _logger;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly LabosContext _context;
        private readonly IRepository<CoreBank> _repo;

        public BankRepository(ILogger<BankRepository> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repo = _unitOfWork.GetRepository<CoreBank>();
        }

        public IUnitOfWork GetUnitOfWork() => _unitOfWork;

        /// <summary>
        /// Get information details of an object.
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>CoreBank</returns>        
        public async Task<CoreBank?> GetDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var Repo = _unitOfWork.GetRepository<CoreBank>();

            var Bank = await _repo.GetFirstOrDefaultAsync(disableTracking: true, 
                                                            include: m => m.Include(c => c.Country), 
                                                            predicate: m => m.BankId == id);
            return Bank;
        }

        /// <summary>
        /// Check if an object exists given an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool BankExists(int id)
        {
            return (_repo.Count(e => e.BankId == id) != 0);
        }

        /// <summary>
        /// Get All objects from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<CoreBank>> GetAll()
        {
            return await _repo.GetPagedListAsync(disableTracking: true, 
                                                 include: m => m.Include(c => c.Country), 
                                                 orderBy: m => m.OrderBy(m => m.Libelle));
        }

        /// <summary>
        /// Saved a new object into the database.
        /// </summary>
        /// <param name="valueDto"></param>
        /// <returns></returns>
        public async Task<int> Add(CoreBank NewValue)
        {
            if (NewValue == null)
                return 0;

            _repo.Insert(NewValue);

            return await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Update an existant object with informations into the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="YearValue"></param>
        /// <returns></returns>
        public async Task<int> Update(int id, CoreBank NewValue)
        {
            try
            {
                if (NewValue == null || id != NewValue.BankId)
                {
                    return 0;
                }

                _repo.Update(NewValue);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BankExists(NewValue.BankId))
                {
                    return 0;
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Delete an existant object from the database.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> Delete(int id)
        {

            int NbDeletedObjects = 0;
            var Bank = this.GetDetails(id);

            if (Bank != null)
            {
                _repo.Delete(Bank);
                NbDeletedObjects = await _unitOfWork.SaveChangesAsync();
            }
            else
                _logger.LogWarning($"{0} => {1}", DateTime.Now.ToString(), "Entity set 'LabosContext.CoreBanks'  is null.");

            return NbDeletedObjects;
        }
    }
}
