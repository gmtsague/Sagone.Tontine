using Microsoft.EntityFrameworkCore;
using Arch.EntityFrameworkCore.UnitOfWork;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using MeetingEntities.Models;
using FormHelper;
using Meeting.web.Controllers;

namespace Meeting.Web.Repository
{
    public interface IEngagementRepository
    {
        Task<int> Add(MeetEngagement NewValue);
        Task<int> Delete(int id);
        Task<IPagedList<MeetEngagement>> FindEngagements(int PaiementStatus, int AntenId, int PeopleId, int RubriqueId);
        Task<IPagedList<MeetEngagement>> GetAll(/*int EtabId, int YearId*/);
        Task<MeetEngagement?> GetDetails(int? id);
        IUnitOfWork GetUnitOfWork();
        Task<int> SyncEngagements(int YearId);
        Task<int> Update(int id, MeetEngagement NewValue);
    }

    public class EngagementRepository : IEngagementRepository
    {
        private readonly ILogger<EngagementRepository> _logger;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly LabosContext _context;
        private readonly IRepository<MeetEngagement> _repo;

        public EngagementRepository(ILogger<EngagementRepository> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repo = _unitOfWork.GetRepository<MeetEngagement>();

        }

        public IUnitOfWork GetUnitOfWork() => _unitOfWork;


        /// <summary>
        /// Get information details of an object.
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>MeetEngagement</returns>        
        public async Task<MeetEngagement?> GetDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            //var Repo = _unitOfWork.GetRepository<MeetEngagement>();

            var findObj = await _repo.GetFirstOrDefaultAsync(disableTracking: true,
                                                              include: m => m.Include(m => m.Person)
                                                                             .Include(m => m.Rubrique.Annee),
                                                              predicate: m => m.EngagementId == id);
            return findObj;
        }

        /// <summary>
        /// Check if an object exists given an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DoExists(int id)
        {
            return (_repo.Count(e => e.EngagementId == id) != 0);
        }

        /// <summary>
        /// Get All objects from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<MeetEngagement>> GetAll(/*int EtabId, int YearId*/)
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                                 include: m => m.Include(m => m.Person)
                                                                .Include(m => m.Rubrique),
                                                 orderBy: m => m.OrderBy(m => m.Rubrique.Numordre));
        }

        /// <summary>
        /// Get All objects from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<MeetEngagement>> FindEngagements(int PaiementStatus, int AntenId, int PeopleId, int RubriqueId)
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                                 include: m => m.Include(m => m.Rubrique)
                                                                .Include(m => m.Person)
                                                                .ThenInclude(m => m.MeetInscriptions.Where(p => p.AntenneId == AntenId || AntenId <= 0)),
                                                 predicate: m => (m.PersonId == PeopleId || PeopleId <= 0) &&
                                                                 (m.RubriqueId == RubriqueId || RubriqueId <= 0) &&
                                                                 (PaiementStatus <= 0 || ((m.ToPay - m.Cumulverse) == 0 && PaiementStatus == 1) ||
                                                                                         ((m.ToPay - m.Cumulverse) > 0 && PaiementStatus == 2)),
                                                 orderBy: m => m.OrderBy(m => m.Rubrique.Numordre));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="YearId"></param>
        /// <returns></returns>
        public async Task<int> SyncEngagements(int YearId)
        {
            var repoAnnees = _unitOfWork.GetRepository<CoreAnnee>();
            var repoRubriques = _unitOfWork.GetRepository<MeetRubrique>();
            var repoInscriptions = _unitOfWork.GetRepository<MeetInscription>();

            var curYear = repoAnnees.Find(YearId);

            if (curYear == null)
                return 0;

            //var AnnualEngagements = await _context.MeetEngagements
            //                             .Include(m => m.Rubrique)
            //                             .Where(m => m.Rubrique.AnneeId == YearId)./*AsNoTracking().*/ToListAsync();

            //var AnnualRubriques = await _context.MeetRubriques.Where(m => m.AnneeId == YearId).AsNoTracking().ToListAsync();

            //var AnnualsInscriptions = await _context.MeetInscriptions.Where(m => m.AnneeId == YearId).AsNoTracking().ToListAsync();

            var AnnualEngagements = await _repo.GetPagedListAsync(disableTracking: true,
                                                 include: m => m.Include(m => m.Rubrique),
                                                 predicate: m => (m.Rubrique.AnneeId == YearId));

            var AnnualRubriques = await repoRubriques.GetPagedListAsync(disableTracking: true,
                                                                        predicate: m => (m.AnneeId == YearId));
            //_context.MeetRubriques.Where(m => m.AnneeId == YearId).AsNoTracking().ToListAsync();

            var AnnualsInscriptions = await repoInscriptions.GetPagedListAsync(disableTracking: true,
                                                                               predicate: m => (m.AnneeId == YearId));
            //_context.MeetInscriptions.Where(m => m.AnneeId == YearId).AsNoTracking().ToListAsync();


            foreach (var membre in AnnualsInscriptions.Items.ToList())
            {
                foreach (var rubElt in AnnualRubriques.Items.ToList())
                {
                    if (AnnualEngagements.Items.Count(m => m.PersonId == membre.PersonId && m.RubriqueId == rubElt.RubriqueId) == 0)
                    {
                        MeetEngagement newObj = new MeetEngagement()
                        {
                            RubriqueId = rubElt.RubriqueId,
                            PersonId = membre.PersonId,
                            Cumulverse = 0,
                            CustomAmount = rubElt.MontantPerson,
                            IsClosed = false,
                            IsOutcome = rubElt.IsOutcome,
                            NbReqSeances = (rubElt.TopayEachPeriode == false) ? 1 : curYear.Nbdivision,
                            ToPay = rubElt.MontantPerson * ((rubElt.TopayEachPeriode == false) ? 1 : curYear.Nbdivision)
                        };

                        AnnualEngagements.Items.Add(newObj);
                    }
                }
            }

            _repo.Insert(AnnualEngagements.Items.Where(m => m.EngagementId <= 0).ToList());
            _repo.Update(AnnualEngagements.Items.Where(m => m.EngagementId > 0).ToList());

            return await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Saved a new object into the database.
        /// </summary>
        /// <param name="valueDto"></param>
        /// <returns></returns>
        public async Task<int> Add(MeetEngagement NewValue)
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
        public async Task<int> Update(int id, MeetEngagement NewValue)
        {
            try
            {
                if (NewValue == null || id != NewValue.EngagementId)
                {
                    return 0;
                }

                // var relatedRubrique = await _context.MeetRubriques.Include(m => m.Annee).FirstAsync(m => m.RubriqueId == valueDto.RubriqueId);
                var TempEngagement = await this.GetDetails(id);
                var relatedRubrique = TempEngagement.Rubrique;
                if (relatedRubrique is null)
                    return 0;

                NewValue.CustomAmount = ((relatedRubrique.AllowCustomAmount) ? NewValue.CustomAmount : relatedRubrique.MontantPerson);
                NewValue.NbReqSeances = (relatedRubrique.TopayEachPeriode == false) ? 1 : relatedRubrique.Annee.Nbdivision;
                NewValue.ToPay = ((relatedRubrique.AllowCustomAmount) ? NewValue.CustomAmount : relatedRubrique.MontantPerson) * NewValue.NbReqSeances;

                _repo.Update(NewValue);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoExists(NewValue.EngagementId))
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
                _logger.LogWarning($"{0} => {1}", DateTime.Now.ToString(), "Entity set 'LabosContext.MeetEngagements'  is null.");

            return NbDeletedObjects;
        }
    }
}
