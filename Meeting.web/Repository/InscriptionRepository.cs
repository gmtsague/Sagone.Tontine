using Arch.EntityFrameworkCore.UnitOfWork;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using MeetingEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Meeting.Web.Repository
{
    public interface IInscriptionRepository
    {
        Task<int> Add(MeetInscription NewValue);
        Task<int> Delete(int id);
        Task<IPagedList<MeetInscription>> GetAll(int yearId, int EtabId);
        Task<IPagedList<MeetInscription>> GetByAntenne(int AntenId, int yearId, int EtabId);
        Task<MeetInscription?> GetDetails(int? id);
        IUnitOfWork GetUnitOfWork();
        Task<int> ToggleStatus(int id, bool NewStatus, DateOnly? Datesuspension);
        Task<int> Update(int id, MeetInscription NewValue);
    }

    public class InscriptionRepository : IInscriptionRepository
    {
        private readonly ILogger<InscriptionRepository> _logger;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly LabosContext _context;
        private readonly IRepository<MeetInscription> _repo;

        public InscriptionRepository(ILogger<InscriptionRepository> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repo = _unitOfWork.GetRepository<MeetInscription>();

        }

        public IUnitOfWork GetUnitOfWork() => _unitOfWork;


        /// <summary>
        /// Get information details of an object.
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>MeetInscription</returns>        
        public async Task<MeetInscription?> GetDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var Repo = _unitOfWork.GetRepository<MeetInscription>();

            var findObj = await _repo.GetFirstOrDefaultAsync(disableTracking: true,
                                                              include: m => m.Include(m => m.MeetAntenne)
                                                                             .Include(m => m.Annee)
                                                                             .Include(m => m.Person),
                                                              predicate: m => m.Idinscrit == id);
            return findObj;
        }

        /// <summary>
        /// Check if an object exists given an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DoExists(int id)
        {
            return (_repo.Count(e => e.Idinscrit == id) != 0);
        }

        /// <summary>
        /// Get All objects from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<MeetInscription>> GetAll(int yearId, int EtabId)
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                                 include: m => m.Include(m => m.MeetAntenne)
                                                                .Include(m => m.Annee)
                                                                .Include(m => m.Person),
                                                 predicate: m => (m.MeetAntenne.EtabId == EtabId && m.AnneeId == yearId),
                                                 orderBy: m => m.OrderBy(m => m.Person.Nom).ThenBy(m => m.Person.Prenom));
        }

        /// <summary>
        /// Get All objects from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<MeetInscription>> GetByAntenne(int AntenId, int yearId, int EtabId)
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                                 include: m => m.Include(m => m.MeetAntenne)
                                                                .Include(m => m.Annee)
                                                                .Include(m => m.Person),
                                                 predicate: m => (m.MeetAntenne.EtabId == EtabId && m.AnneeId == yearId && (AntenId <= 0 || m.AntenneId == AntenId)),
                                                 orderBy: m => m.OrderBy(m => m.Person.Nom).ThenBy(m => m.Person.Prenom));
        }

        /// <summary>
        /// Saved a new object into the database.
        /// </summary>
        /// <param name="valueDto"></param>
        /// <returns></returns>
        public async Task<int> Add(MeetInscription NewValue)
        {
            if (NewValue == null)
                return 0;

            var _repoPerson = _unitOfWork.GetRepository<CorePerson>();
            CorePerson? pers = _repoPerson.GetFirstOrDefault(predicate: m => m.PersonId == NewValue.PersonId);

            NewValue.Nocni = pers?.Nocni ?? "None";
            NewValue.IsActive = true;
            _repo.Insert(NewValue);

            return await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Update an existant object with informations into the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="YearValue"></param>
        /// <returns></returns>
        public async Task<int> Update(int id, MeetInscription NewValue)
        {
            try
            {
                if (NewValue == null || id != NewValue.Idinscrit)
                {
                    return 0;
                }

                _repo.Update(NewValue);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoExists(NewValue.Idinscrit))
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
        /// Update an existant object with informations into the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="YearValue"></param>
        /// <returns></returns>
        public async Task<int> ToggleStatus(int id, bool NewStatus, DateOnly? Datesuspension)
        {
            try
            {
                var findObj = await this.GetDetails(id);

                if (findObj != null)
                {
                    findObj.IsActive = NewStatus;
                    findObj.Datesuspension = (NewStatus) ? null : Datesuspension;

                    _repo.Update(findObj);
                    return await _unitOfWork.SaveChangesAsync();
                }
                else
                {
                    _logger.LogWarning($"{0} => {1}", DateTime.Now.ToString(), "Entity set 'LabosContext.MeetInscriptions'  is null.");
                    return 0;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoExists(id))
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
                _logger.LogWarning($"{0} => {1}", DateTime.Now.ToString(), "Entity set 'LabosContext.MeetInscriptions'  is null.");

            return NbDeletedObjects;
        }
    }
}
