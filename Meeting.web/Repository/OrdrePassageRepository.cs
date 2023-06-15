using Microsoft.EntityFrameworkCore;
using Arch.EntityFrameworkCore.UnitOfWork;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using MeetingEntities.Models;

namespace Meeting.Web.Repository
{
    public interface IOrdrePassageRepository
    {
        Task<int> Add(MeetOrdrePassage NewValue);
        Task<int> Delete(int id);
        Task<IPagedList<MeetOrdrePassage>> GetAll(int EtabId, int YearId);
        Task<IPagedList<MeetOrdrePassage>> GetByAntenne(int AntenId, int EtabId, int YearId);
        Task<MeetOrdrePassage?> GetDetails(int? id);
        IUnitOfWork GetUnitOfWork();
        Task<int> Update(int id, MeetOrdrePassage NewValue);
    }

    public class OrdrePassageRepository : IOrdrePassageRepository
    {
        private readonly ILogger<OrdrePassageRepository> _logger;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly LabosContext _context;
        private readonly IRepository<MeetOrdrePassage> _repo;

        public OrdrePassageRepository(ILogger<OrdrePassageRepository> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repo = _unitOfWork.GetRepository<MeetOrdrePassage>();

        }

        public IUnitOfWork GetUnitOfWork() => _unitOfWork;

        /// <summary>
        /// Get information details of an object.
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>MeetOrdrePassage</returns>        
        public async Task<MeetOrdrePassage?> GetDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var Repo = _unitOfWork.GetRepository<MeetOrdrePassage>();

            var findObj = await _repo.GetFirstOrDefaultAsync(disableTracking: true,
                                                              include: m => m.Include(m => m.CoreSubdivision)
                                                                             .Include(m => m.IdinscritNavigation.MeetAntenne)
                                                                             .Include(m => m.IdinscritNavigation).ThenInclude(m => m.Person),
                                                              predicate: m => m.PassageId == id);
            return findObj;
        }

        /// <summary>
        /// Check if an object exists given an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DoExists(int id)
        {
            return (_repo.Count(e => e.PassageId == id) != 0);
        }

        /// <summary>
        /// Get All objects from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<MeetOrdrePassage>> GetAll(int EtabId, int YearId)
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                                 include: m => m.Include(m => m.CoreSubdivision)
                                                                .Include(m => m.IdinscritNavigation.MeetAntenne)
                                                                //.ThenInclude(m=>m.Person)
                                                                .Include(p => p.IdinscritNavigation.Person),
                                                 predicate: m => (m.IdinscritNavigation.EtabId == EtabId && m.AnneeId == YearId),
                                                 orderBy: m => m.OrderBy(m => m.CoreSubdivision.MonthDate));
        }

        /// <summary>
        /// Get All objects from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<MeetOrdrePassage>> GetByAntenne(int AntenId, int EtabId, int YearId)
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                                 include: m => m.Include(m => m.CoreSubdivision)
                                                                .Include(m => m.IdinscritNavigation.MeetAntenne)
                                                                //.ThenInclude(m=>m.Person)
                                                                .Include(p => p.IdinscritNavigation.Person),
                                                 predicate: m => (m.IdinscritNavigation.EtabId == EtabId && m.AnneeId == YearId) &&
                                                                 (AntenId <= 0 || m.IdinscritNavigation.AntenneId == AntenId),
                                                 orderBy: m => m.OrderBy(m => m.CoreSubdivision.MonthDate));
        }

        /// <summary>
        /// Saved a new object into the database.
        /// </summary>
        /// <param name="valueDto"></param>
        /// <returns></returns>
        public async Task<int> Add(MeetOrdrePassage NewValue)
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
        public async Task<int> Update(int id, MeetOrdrePassage NewValue)
        {
            try
            {
                if (NewValue == null || id != NewValue.PassageId)
                {
                    return 0;
                }

                _repo.Update(NewValue);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoExists(NewValue.PassageId))
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
            var findObj = this.GetDetails(id);

            if (findObj != null)
            {
                _repo.Delete(findObj);
                NbDeletedObjects = await _unitOfWork.SaveChangesAsync();
            }
            else
                _logger.LogWarning($"{0} => {1}", DateTime.Now.ToString(), "Entity set 'LabosContext.MeetOrdrePassages'  is null.");

            return NbDeletedObjects;
        }
    }
}
