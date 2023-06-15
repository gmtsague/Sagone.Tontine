using Microsoft.EntityFrameworkCore;
using Arch.EntityFrameworkCore.UnitOfWork;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using MeetingEntities.Models;

namespace Meeting.Web.Repository
{
    public interface IConfigvisasRepository
    {
        Task<int> Add(MeetConfigVisa NewValue);
        Task<int> Delete(int id);
        Task<IPagedList<MeetConfigVisa>> GetAll();
        Task<MeetConfigVisa?> GetDetails(int? id);
        IUnitOfWork GetUnitOfWork();
        Task<int> Update(int id, MeetConfigVisa NewValue);
    }

    public class ConfigvisasRepository : IConfigvisasRepository
    {
        private readonly ILogger<ConfigvisasRepository> _logger;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly LabosContext _context;
        private readonly IRepository<MeetConfigVisa> _repo;

        public ConfigvisasRepository(ILogger<ConfigvisasRepository> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repo = _unitOfWork.GetRepository<MeetConfigVisa>();
        }

        public IUnitOfWork GetUnitOfWork() => _unitOfWork;


        /// <summary>
        /// Get information details of an object.
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>MeetConfigVisa</returns>        
        public async Task<MeetConfigVisa?> GetDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var Repo = _unitOfWork.GetRepository<MeetConfigVisa>();

            var Modepaie = await _repo.GetFirstOrDefaultAsync(disableTracking: true,
                                                              include: m => m.Include(m => m.Annee)
                                                                             .Include(m => m.Poste)
                                                                             .Include(m => m.Typerub),
                                                              predicate: m => m.ConfigvisaId == id);
            return Modepaie;
        }

        /// <summary>
        /// Check if an object exists given an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool ConfigvisaExists(int id)
        {
            return (_repo.Count(e => e.ConfigvisaId == id) != 0);
        }

        /// <summary>
        /// Get All objects from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<MeetConfigVisa>> GetAll()
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                                 include: m => m.Include(m => m.Annee)
                                                                .Include(m => m.Poste)
                                                                .Include(m => m.Typerub),
                                                 orderBy: m => m.OrderBy(m => m.Poste.Libelle).ThenBy(m => m.Typerub.Libelle));
        }

        /// <summary>
        /// Saved a new object into the database.
        /// </summary>
        /// <param name="valueDto"></param>
        /// <returns></returns>
        public async Task<int> Add(MeetConfigVisa NewValue)
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
        public async Task<int> Update(int id, MeetConfigVisa NewValue)
        {
            try
            {
                if (NewValue == null || id != NewValue.ConfigvisaId)
                {
                    return 0;
                }

                _repo.Update(NewValue);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfigvisaExists(NewValue.ConfigvisaId))
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
            var Modepaie = this.GetDetails(id);

            if (Modepaie != null)
            {
                _repo.Delete(Modepaie);
                NbDeletedObjects = await _unitOfWork.SaveChangesAsync();
            }
            else
                _logger.LogWarning($"{0} => {1}", DateTime.Now.ToString(), "Entity set 'LabosContext.MeetConfigVisas'  is null.");

            return NbDeletedObjects;
        }
    }
}
