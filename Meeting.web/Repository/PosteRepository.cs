using Arch.EntityFrameworkCore.UnitOfWork;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using MeetingEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Meeting.Web.Repository
{
    public interface IPosteRepository
    {
        Task<int> Add(MeetPoste NewValue);
        Task<int> Delete(int id);
        Task<IPagedList<MeetPoste>> GetAll();
        Task<MeetPoste?> GetDetails(int? id);
        IUnitOfWork GetUnitOfWork();
        Task<int> Update(int id, MeetPoste NewValue);
    }

    public class PosteRepository : IPosteRepository
    {
        private readonly ILogger<PosteRepository> _logger;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly LabosContext _context;
        private readonly IRepository<MeetPoste> _repo;

        public PosteRepository(ILogger<PosteRepository> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repo = _unitOfWork.GetRepository<MeetPoste>();
        }

        public IUnitOfWork GetUnitOfWork() => _unitOfWork;


        /// <summary>
        /// Get information details of an object.
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>MeetPoste</returns>        
        public async Task<MeetPoste?> GetDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var Repo = _unitOfWork.GetRepository<MeetPoste>();

            var Modepaie = await _repo.GetFirstOrDefaultAsync(disableTracking: true,
                                                              predicate: m => m.PosteId == id);
            return Modepaie;
        }

        /// <summary>
        /// Check if an object exists given an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool PosteExists(int id)
        {
            return (_repo.Count(e => e.PosteId == id) != 0);
        }

        /// <summary>
        /// Get All objects from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<MeetPoste>> GetAll()
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                                 orderBy: m => m.OrderBy(m => m.Libelle));
        }

        /// <summary>
        /// Saved a new object into the database.
        /// </summary>
        /// <param name="valueDto"></param>
        /// <returns></returns>
        public async Task<int> Add(MeetPoste NewValue)
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
        public async Task<int> Update(int id, MeetPoste NewValue)
        {
            try
            {
                if (NewValue == null || id != NewValue.PosteId)
                {
                    return 0;
                }

                _repo.Update(NewValue);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PosteExists(NewValue.PosteId))
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
                _logger.LogWarning($"{0} => {1}", DateTime.Now.ToString(), "Entity set 'LabosContext.MeetPostes'  is null.");

            return NbDeletedObjects;
        }
    }
}
