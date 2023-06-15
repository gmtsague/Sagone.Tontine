using Microsoft.EntityFrameworkCore;
using Arch.EntityFrameworkCore.UnitOfWork;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using MeetingEntities.Models;
using Meeting.web.Controllers;
using Meeting.Web.Dto;
using Microsoft.AspNetCore.Mvc;
using FormHelper;

namespace Meeting.Web.Repository
{
    public interface IPresencesRepository
    {
        Task<int> Add(MeetPresence NewValue);
        Task<int> Delete(int id);
        Task<IPagedList<MeetPresence>> GetAll();
        Task<MeetPresence?> GetDetails(int? id);
        Task<(MeetPresence Presence, decimal PayableAmount)> GetEngagements(int PresenceId, bool repartitionAuto = true);
        IUnitOfWork GetUnitOfWork();
        Task<IPagedList<MeetPresence>> PresencesBySeance(int SeanceId);
        Task<int> UndoPaiement(int PresenceId);
        Task<int> Update(int id, MeetPresence NewValue);
    }

    public class PresencesRepository : IPresencesRepository
    {
        private readonly ILogger<PresencesRepository> _logger;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly LabosContext _context;
        private readonly IRepository<MeetPresence> _repo;

        public PresencesRepository(ILogger<PresencesRepository> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repo = _unitOfWork.GetRepository<MeetPresence>();
        }

        public IUnitOfWork GetUnitOfWork() => _unitOfWork;


        /// <summary>
        /// Get information details of an object.
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>MeetPresence</returns>        
        public async Task<MeetPresence?> GetDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var findObj = await _repo.GetFirstOrDefaultAsync(disableTracking: true,
                                                              include: m => m.Include(p => p.Seance.CoreSubdivision)
                                                                             .Include(m => m.IdinscritNavigation.MeetAntenne)
                                                                             .Include(m => m.IdinscritNavigation.Person)
                                                                             //.ThenInclude(m => m.Person)
                                                                             .Include(p => p.MeetEntreeCaisses)
                                                                             .ThenInclude(p => p.Engagement)
                                                                             .ThenInclude(p => p.Rubrique),
                                                              predicate: m => m.PresenceId == id);
            return findObj;
        }

        /// <summary>
        /// Check if an object exists given an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DoExists(int id)
        {
            return (_repo.Count(e => e.PresenceId == id) != 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<MeetPresence>> GetAll()
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                      include: m => m.Include(p => p.Seance)
                                                     .Include(p => p.Seance.CoreSubdivision)
                                                     .Include(m => m.IdinscritNavigation.MeetAntenne)
                                                     .Include(m => m.IdinscritNavigation.Person),

                                      orderBy: m => m.OrderBy(m => m.IdinscritNavigation.Person.Nom)
                                                     .ThenBy(m => m.IdinscritNavigation.Person.Prenom));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="PresenceId"></param>
        /// <returns></returns>
        public async Task<IPagedList<MeetPresence>> PresencesBySeance(int SeanceId)
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                                 include: m => m.Include(m => m.Seance)
                                                                .Include(p => p.Seance.CoreSubdivision)
                                                                .Include(m => m.IdinscritNavigation.MeetAntenne)
                                                                .Include(m => m.IdinscritNavigation.Person),
                                                 predicate: m => m.SeanceId == SeanceId,
                                                 orderBy: m => m.OrderBy(m => m.IdinscritNavigation.Person.Nom)
                                                                .ThenBy(m => m.IdinscritNavigation.Person.Prenom));
        }

        /// <summary>
        /// Get information details of an object.
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>MeetPresence</returns>        
        public async Task<(MeetPresence Presence, decimal PayableAmount)> GetEngagements(int PresenceId, bool repartitionAuto = true)
        {
            var presence = await _repo.GetFirstOrDefaultAsync(disableTracking: true,
                                                              include: m => m.Include(p => p.Seance.CoreSubdivision)
                                                                             .Include(m => m.IdinscritNavigation.MeetAntenne)
                                                                             .Include(m => m.IdinscritNavigation.Person)
                                                                             //.ThenInclude(m => m.Person)
                                                                             .Include(p => p.MeetEntreeCaisses)
                                                                             .ThenInclude(p => p.Engagement)
                                                                             .ThenInclude(p => p.Rubrique),
                                                              predicate: m => m.PresenceId == PresenceId);

            //var presence = await _context.MeetPresences
            //                             .Include(m => m.Seance.CoreSubdivision)
            //                             .Include(m => m.IdinscritNavigation.MeetAntenne)
            //                             .Include(m => m.IdinscritNavigation.Person)
            //                             .FirstAsync(m => m.PresenceId == PresenceId);
            if (presence == null)
            {
                return (null, 0);
            }

            var RepoEngagements = _unitOfWork.GetRepository<MeetEngagement>();

            var details = await RepoEngagements.GetPagedListAsync(disableTracking: true,
                                                              include: m => m.Include(p => p.Rubrique.Annee)
                                                                             .Include(m => m.Person.MeetInscriptions
                                                                                      .Where(p => p.PersonId == m.PersonId && p.AnneeId == m.Rubrique.AnneeId && p.Idinscrit == presence.Idinscrit))
                                                                             .Include(p => p.MeetEntreeCaisses)
                                                                             .ThenInclude(p => p.Engagement)
                                                                             .ThenInclude(p => p.Rubrique),
                                                              predicate: m => (m.ToPay - m.Cumulverse) > 0,
                                                              orderBy: m => m.OrderBy(o => o.Rubrique.Libelle));

            //var details = from eng in _context.MeetEngagements.Include(m => m.Rubrique).Include(m => m.Person)
            //              join ins in _context.MeetInscriptions on eng.PersonId equals ins.PersonId
            //              join pers in _context.CorePeople on eng.PersonId equals pers.PersonId
            //              //join rub in _context.MeetRubriques on eng.RubriqueId equals rub.RubriqueId
            //              where ins.Idinscrit == presence.Idinscrit && (eng.ToPay - eng.Cumulverse) > 0
            //              orderby eng.Rubrique.Libelle
            //              select new { eng/*, pers, rub*/ };

            ////var details = _context.MeetEngagements.Include(m => m.Rubrique)
            ////                                .Include(m => m.Person)
            ////                                .ThenInclude(m => m.MeetInscriptions.Where(p => p.Idinscrit == presenceDto.Idinscrit))
            ////                                //.Where(m => (m.PersonId == PeopleId || PeopleId <= 0))
            ////                                //.Where(m => (m.RubriqueId == RubriqueId || RubriqueId <= 0))
            ////                                .Where(m => (m.ToPay - m.Cumulverse) > 0).AsNoTracking();
            ////var d1 =  _context.MeetEngagements.Join(_context.MeetInscriptions, e=>e.PersonId, i=>i.PersonId, (e,i)=> new )

            ////           IQueryable <MeetEngagement> details = _context.Database
            ////                                                        .SqlQuery<MeetEngagement>($@"SELECT e.* FROM meet_engagement e 
            ////JOIN meet_inscription i ON (e.person_id = i.person_id AND i.idinscrit = {{presenceDto.Idinscrit}}) 
            ////JOIN core_person p ON (p.person_id = i.person_id) 
            ////JOIN meet_rubrique R ON (R.rubrique_id = e.rubrique_id) WHERE (e.to_pay - e.cumulverse) > 0 ");

            if (details.Items != null)
            {
                if (!repartitionAuto && details.Items.Count() > 0)
                {
                    foreach (var dette in details.Items.ToList())
                    {
                        presence.MeetEntreeCaisses.Add(new MeetEntreeCaisse()
                        {
                            EngagementId = dette.EngagementId,
                            Engagement = dette,
                            IsOutcome = dette.IsOutcome,
                            Montantverse = 0,
                            PresenceId = presence.PresenceId
                            //, OperationId = 0
                        });
                    }
                }
            }
            decimal PayableAmount = (details == null || details.Items.Count() == 0) ? 0 : details.Items.Sum(m => (m.ToPay - m.Cumulverse));
            return (presence, PayableAmount);
        }

        /// <summary>
        /// Saved a new object into the database.
        /// </summary>
        /// <param name="valueDto"></param>
        /// <returns></returns>
        public async Task<int> UndoPaiement(int PresenceId)
        {
            var findObj = await this.GetDetails(PresenceId);

            if (findObj != null)
            {
                var _repoEntreeCaisses = _unitOfWork.GetRepository<MeetEntreeCaisse>();
                var _repoEngagements = _unitOfWork.GetRepository<MeetEngagement>();

                //removing previous data saved for the same month meeting and for the specified member
                if (_repoEntreeCaisses.Count(m => m.PresenceId == findObj.PresenceId) > 0)
                {
                    var EntreesCaisses = await _repoEntreeCaisses.GetPagedListAsync(predicate: m => m.PresenceId == findObj.PresenceId);
                    foreach (var elt in EntreesCaisses.Items)
                    {
                        var engage = _repoEngagements.Find(elt.EngagementId);
                        if (engage is not null)
                            engage.Cumulverse -= elt.Montantverse;
                    }
                    //_context.RemoveRange(_context.MeetEntreeCaisses.Where(m => m.PresenceId == findObj.PresenceId));
                    _repoEntreeCaisses.Delete(_repoEntreeCaisses.GetPagedList(predicate: m => m.PresenceId == findObj.PresenceId).Items);

                    findObj.Globalverse = 0;
                    findObj.VerseCash = 0;
                    findObj.VerseTransfert = 0;
                    findObj.NumBordero = string.Empty;
                }
                _repo.Update(findObj);

                return await _unitOfWork.SaveChangesAsync();
            }
            return 0;
        }

        /// <summary>
        /// Saved a new object into the database.
        /// </summary>
        /// <param name="valueDto"></param>
        /// <returns></returns>
        public async Task<int> Add(MeetPresence NewValue)
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
        public async Task<int> Update(int id, MeetPresence NewValue)
        {
            try
            {
                if (NewValue == null || id != NewValue.PresenceId)
                {
                    return 0;
                }
                var _repoEngagements = _unitOfWork.GetRepository<MeetEngagement>();

                NewValue.Globalverse = NewValue.VerseCash + NewValue.VerseTransfert;

                foreach (var elt in NewValue.MeetEntreeCaisses)
                {
                    //var details = _context.MeetEngagements.Find(elt.EngagementId);
                    var details = _repoEngagements.Find(elt.EngagementId);
                    if (details != null)
                    {
                        details.Cumulverse += elt.Montantverse;
                        elt.Engagement = details;
                    }
                }
                _repo.Update(NewValue);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoExists(NewValue.PresenceId))
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
                _logger.LogWarning($"{0} => {1}", DateTime.Now.ToString(), "Entity set 'LabosContext.MeetPresences'  is null.");

            return NbDeletedObjects;
        }
    }
}
