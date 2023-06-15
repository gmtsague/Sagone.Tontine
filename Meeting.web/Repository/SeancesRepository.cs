using Microsoft.EntityFrameworkCore;
using Arch.EntityFrameworkCore.UnitOfWork;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using MeetingEntities.Models;

namespace Meeting.Web.Repository
{
    public interface ISeancesRepository
    {
        Task<int> Add(MeetSeance NewValue);
        Task<int> Delete(int id);
        Task<IPagedList<MeetSeance>> GetAll(int EtabId, int YearId);
        Task<IPagedList<MeetInscription>> GetAnnualRegisteredMembersAsync(int yearId, int antenne);
        Task<MeetSeance?> GetDetails(int? id);
        Task<IPagedList<MeetPresence>> GetDetailsPresences(int seanceId);
        IUnitOfWork GetUnitOfWork();
        Task<IPagedList<MeetSeance>> SeancesByAntenne(int AntenId, int EtabId, int YearId);
        Task<int> Update(int id, MeetSeance NewValue);
    }

    public class SeancesRepository : ISeancesRepository
    {
        private readonly ILogger<SeancesRepository> _logger;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly LabosContext _context;
        private readonly IRepository<MeetSeance> _repo;

        public SeancesRepository(ILogger<SeancesRepository> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repo = _unitOfWork.GetRepository<MeetSeance>();

        }

        public IUnitOfWork GetUnitOfWork() => _unitOfWork;


        /// <summary>
        /// Get information details of an object.
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>MeetSeance</returns>        
        public async Task<MeetSeance?> GetDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var Repo = _unitOfWork.GetRepository<MeetSeance>();

            var findObj = await _repo.GetFirstOrDefaultAsync(disableTracking: true,
                                                              include: m => m.Include(m => m.CoreSubdivision)
                                                                             .Include(m => m.MeetAntenne),
                                                              predicate: m => m.SeanceId == id);
            return findObj;
        }

        /// <summary>
        /// Check if an object exists given an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DoExists(int id)
        {
            return (_repo.Count(e => e.SeanceId == id) != 0);
        }

        /// <summary>
        /// Get All objects from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<MeetSeance>> GetAll(int EtabId, int YearId)
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                                 include: m => m.Include(m => m.CoreSubdivision)
                                                                .Include(m => m.MeetAntenne),
                                                 predicate: m => (m.MeetAntenne.EtabId == EtabId && m.AnneeId == YearId),
                                                 orderBy: m => m.OrderBy(m => m.CoreSubdivision.MonthDate));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<IPagedList<MeetSeance>> SeancesByAntenne(int AntenId, int EtabId, int YearId)
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                                 include: m => m.Include(m => m.CoreSubdivision)
                                                                .Include(m => m.MeetAntenne),
                                                 predicate: m => (AntenId <= 0 || m.AntenneId == AntenId) && (m.MeetAntenne.EtabId == EtabId && m.AnneeId == YearId),
                                                 orderBy: m => m.OrderBy(m => m.CoreSubdivision.MonthDate));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="seanceId"></param>
        /// <returns></returns>
        public async Task<IPagedList<MeetPresence>> GetDetailsPresences(int seanceId)
        {
            var RepoPresence = _unitOfWork.GetRepository<MeetPresence>();

            return await RepoPresence.GetPagedListAsync(disableTracking: true,
                                                 include: m => m.Include(m => m.Seance)
                                                                .Include(p => p.Seance.CoreSubdivision)
                                                                .Include(m => m.IdinscritNavigation.MeetAntenne)
                                                                .Include(m => m.IdinscritNavigation.Person),
                                                 predicate: m => m.SeanceId == seanceId,
                                                 orderBy: m => m.OrderBy(m => m.IdinscritNavigation.Person.Nom)
                                                                .ThenBy(m => m.IdinscritNavigation.Person.Prenom));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="yearId"></param>
        /// <param name="antenne"></param>
        /// <returns></returns>
        public async Task<IPagedList<MeetInscription>> GetAnnualRegisteredMembersAsync(int yearId, int antenne)
        {
            var repoInscrits = _unitOfWork.GetRepository<MeetInscription>();

            return await repoInscrits.GetPagedListAsync(disableTracking: true,
                                                 //include: m => m.Include(m => m.Annee),
                                                 predicate: m => m.AnneeId == yearId && (antenne <= 0 || m.AntenneId == antenne),
                                                 orderBy: m => m.OrderBy(m => m.Dateinscrit)
                                                 );
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="seance"></param>
        private async void BuildSeanceMembers(MeetSeance seance)
        {
            if (seance == null)
                return;
            //Get list of annual registered members
            var registeredMembers = await this.GetAnnualRegisteredMembersAsync(seance.AnneeId, seance.AntenneId ?? 0);
            foreach (var member in registeredMembers.Items.ToList())
            {
                if (seance.MeetPresences.Count(m => m.Idinscrit == member.Idinscrit) == 0)
                {
                    seance.MeetPresences.Add(new MeetPresence()
                    {
                        Idinscrit = member.Idinscrit,
                        IsAbsent = false,
                        Globalverse = 0
                    });
                }
            }
        }

        /// <summary>
        /// Saved a new object into the database.
        /// </summary>
        /// <param name="valueDto"></param>
        /// <returns></returns>
        public async Task<int> Add(MeetSeance NewValue)
        {
            if (NewValue == null)
                return 0;

            NewValue.Opendate = DateTime.Now;
            _repo.Insert(NewValue);

            return await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Update an existant object with informations into the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="YearValue"></param>
        /// <returns></returns>
        public async Task<int> Update(int id, MeetSeance NewValue)
        {
            try
            {
                if (NewValue == null || id != NewValue.SeanceId)
                {
                    return 0;
                }

                _repo.Update(NewValue);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoExists(NewValue.SeanceId))
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
                _logger.LogWarning($"{0} => {1}", DateTime.Now.ToString(), "Entity set 'LabosContext.MeetSeances'  is null.");

            return NbDeletedObjects;
        }
    }
}
