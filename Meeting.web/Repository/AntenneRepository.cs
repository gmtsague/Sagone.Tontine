using Arch.EntityFrameworkCore.UnitOfWork;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using MeetingEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Meeting.Web.Repository
{
    public interface IAntenneRepository
    {
        Task<int> Add(MeetAntenne NewValue);
        Task<int> Delete(int? EtabId, int? AntenneId);
        Task<IPagedList<MeetAntenne>> GetAll(int? IdEtab);
        Task<MeetAntenne?> GetDetails(int? IdEtab, int? id);
        IUnitOfWork GetUnitOfWork();
        Task<int> Update(int EtabId, int AntenneId, MeetAntenne NewValue);
    }

    public class AntenneRepository : IAntenneRepository
    {
        private readonly ILogger<AntenneRepository> _logger;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly LabosContext _context;
        private readonly IRepository<MeetAntenne> _repo;

        public AntenneRepository(ILogger<AntenneRepository> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repo = _unitOfWork.GetRepository<MeetAntenne>();
        }

        public IUnitOfWork GetUnitOfWork() => _unitOfWork;


        /// <summary>
        /// Get information details of an object.
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>MeetAntenne</returns>        
        public async Task<MeetAntenne?> GetDetails(int? IdEtab, int? id)
        {
            if (id == null || IdEtab == null)
            {
                return null;
            }

            var Repo = _unitOfWork.GetRepository<MeetAntenne>();

            var findObj = await _repo.GetFirstOrDefaultAsync(disableTracking: true,
                                                            include: m => m.Include(m => m.Etab),
                                                            predicate: m => ((IdEtab.HasValue == false) || m.EtabId == IdEtab) && m.AntenneId == id);
            return findObj;
        }

        /// <summary>
        /// Check if an object exists given an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool AntenneExists(int IdEtab, int id)
        {
            return (_repo.Count(e => e.EtabId == IdEtab && e.AntenneId == id) != 0);
        }

        /// <summary>
        /// Get All objects from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<MeetAntenne>> GetAll(int? IdEtab)
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                                 include: m => m.Include(m => m.Etab),
                                                 predicate: m => (IdEtab.HasValue==false) || m.EtabId == IdEtab,
                                                 orderBy: m => m.OrderBy(m => m.Libelle));
        }

        /// <summary>
        /// Saved a new object into the database.
        /// </summary>
        /// <param name="valueDto"></param>
        /// <returns></returns>
        public async Task<int> Add(MeetAntenne NewValue)
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
        public async Task<int> Update(int EtabId, int AntenneId, MeetAntenne NewValue)
        {
            try
            {
                if (NewValue == null || AntenneId != NewValue.AntenneId && EtabId != NewValue.EtabId)
                {
                    return 0;
                }

                _repo.Update(NewValue);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AntenneExists(NewValue.EtabId, NewValue.AntenneId))
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
        public async Task<int> Delete(int? EtabId, int? AntenneId)
        {

            int NbDeletedObjects = 0;
            var Bank = this.GetDetails(EtabId, AntenneId);

            if (Bank != null)
            {
                _repo.Delete(Bank);
                NbDeletedObjects = await _unitOfWork.SaveChangesAsync();
            }
            else
                _logger.LogWarning($"{0} => {1}", DateTime.Now.ToString(), "Entity set 'LabosContext.MeetAntennes'  is null.");

            return NbDeletedObjects;
        }
    }
}
