using Arch.EntityFrameworkCore.UnitOfWork;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using MeetingEntities.Models;
using Microsoft.EntityFrameworkCore;

namespace Meeting.Web.Repository
{
    public interface ITypeRubriqueRepository
    {
        Task<int> Add(MeetTypeRubrique NewValue);
        Task<int> Delete(int id);
        Task<IPagedList<MeetTypeRubrique>> GetAll();
        Task<MeetTypeRubrique?> GetDetails(int? id);
        IUnitOfWork GetUnitOfWork();
        Task<int> Update(int id, MeetTypeRubrique NewValue);
    }

    public class TypeRubriqueRepository : ITypeRubriqueRepository
    {
        private readonly ILogger<TypeRubriqueRepository> _logger;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly LabosContext _context;
        private readonly IRepository<MeetTypeRubrique> _repo;

        public TypeRubriqueRepository(ILogger<TypeRubriqueRepository> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repo = _unitOfWork.GetRepository<MeetTypeRubrique>();
        }

        public IUnitOfWork GetUnitOfWork() => _unitOfWork;

        /// <summary>
        /// Get information details of an object.
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>MeetTypeRubrique</returns>        
        public async Task<MeetTypeRubrique?> GetDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var Repo = _unitOfWork.GetRepository<MeetTypeRubrique>();

            var findObj = await _repo.GetFirstOrDefaultAsync(disableTracking: true,
                                                            predicate: m => m.TyperubId == id);
            return findObj;
        }

        /// <summary>
        /// Check if an object exists given an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool TypeRubriqueExists(int id)
        {
            return (_repo.Count(e => e.TyperubId == id) != 0);
        }

        /// <summary>
        /// Get All objects from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<MeetTypeRubrique>> GetAll()
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                                 orderBy: m => m.OrderBy(m => m.Libelle));
        }

        /// <summary>
        /// Saved a new object into the database.
        /// </summary>
        /// <param name="valueDto"></param>
        /// <returns></returns>
        public async Task<int> Add(MeetTypeRubrique NewValue)
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
        public async Task<int> Update(int id, MeetTypeRubrique NewValue)
        {
            try
            {
                if (NewValue == null || id != NewValue.TyperubId)
                {
                    return 0;
                }

                _repo.Update(NewValue);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeRubriqueExists(NewValue.TyperubId))
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
                _logger.LogWarning($"{0} => {1}", DateTime.Now.ToString(), "Entity set 'LabosContext.MeetTypeRubriques'  is null.");

            return NbDeletedObjects;
        }
    }
}
