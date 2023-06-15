﻿using Microsoft.EntityFrameworkCore;
using Arch.EntityFrameworkCore.UnitOfWork;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using MeetingEntities.Models;

namespace Meeting.Web.Repository
{
    public interface ISortiecaisseRepository
    {
        Task<int> Add(MeetSortieCaisse NewValue);
        Task<int> Delete(int id);
        Task<IPagedList<MeetSortieCaisse>> GetAll(int YearId);
        Task<IPagedList<MeetSortieCaisse>> GetDataBySeance(int seanceId, int YearId);
        Task<MeetSortieCaisse?> GetDetails(int? id);
        IUnitOfWork GetUnitOfWork();
        Task<int> Update(int id, MeetSortieCaisse NewValue);
    }

    public class SortiecaisseRepository : ISortiecaisseRepository
    {
        private readonly ILogger<SortiecaisseRepository> _logger;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly LabosContext _context;
        private readonly IRepository<MeetSortieCaisse> _repo;

        public SortiecaisseRepository(ILogger<SortiecaisseRepository> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _repo = _unitOfWork.GetRepository<MeetSortieCaisse>();

        }

        public IUnitOfWork GetUnitOfWork() => _unitOfWork;


        /// <summary>
        /// Get information details of an object.
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>MeetSortieCaisse</returns>        
        public async Task<MeetSortieCaisse?> GetDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var Repo = _unitOfWork.GetRepository<MeetSortieCaisse>();

            var findObj = await _repo.GetFirstOrDefaultAsync(disableTracking: true,
                                                              include: m => m.Include(m => m.Rubrique)
                                                                             .Include(m => m.IdinscritNavigation.Person)
                                                                             .Include(m => m.IdinscritNavigation.MeetAntenne)
                                                                             .Include(m => m.Seance.CoreSubdivision),
                                                              predicate: m => m.SortiecaisseId == id);
            return findObj;
        }

        /// <summary>
        /// Check if an object exists given an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool DoExists(int id)
        {
            return (_repo.Count(e => e.SortiecaisseId == id) != 0);
        }

        /// <summary>
        /// Get All objects from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<MeetSortieCaisse>> GetAll(int YearId)
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                                 include: m => m.Include(m => m.Rubrique)
                                                                .Include(m => m.IdinscritNavigation.Person)
                                                                .Include(m => m.IdinscritNavigation.MeetAntenne)
                                                                .Include(m => m.Seance.CoreSubdivision),
                                                 predicate: m => ((m.IdinscritNavigation == null || m.IdinscritNavigation.AnneeId == m.Rubrique.AnneeId) && m.Rubrique.AnneeId == YearId),
                                                 orderBy: m => m.OrderByDescending(m => m.Dateevts));
        }

        /// <summary>
        /// Get All objects from database.
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<MeetSortieCaisse>> GetDataBySeance(int seanceId, int YearId)
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                                 include: m => m.Include(m => m.Rubrique)
                                                                .Include(m => m.IdinscritNavigation.Person)
                                                                .Include(m => m.IdinscritNavigation.MeetAntenne)
                                                                .Include(m => m.Seance.CoreSubdivision),
                                                 predicate: m => ((m.IdinscritNavigation == null || m.IdinscritNavigation.AnneeId == m.Rubrique.AnneeId) && m.SeanceId == seanceId) &&
                                                                 (m.Rubrique.AnneeId == YearId),
                                                 orderBy: m => m.OrderByDescending(m => m.Dateevts));
        }

        /// <summary>
        /// Saved a new object into the database.
        /// </summary>
        /// <param name="valueDto"></param>
        /// <returns></returns>
        public async Task<int> Add(MeetSortieCaisse NewValue)
        {
            if (NewValue == null)
                return 0;

            NewValue.RefNo = Guid.NewGuid().ToString().Substring(0, 13);
            _repo.Insert(NewValue);

            return await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Update an existant object with informations into the database.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="YearValue"></param>
        /// <returns></returns>
        public async Task<int> Update(int id, MeetSortieCaisse NewValue)
        {
            try
            {
                if (NewValue == null || id != NewValue.SortiecaisseId)
                {
                    return 0;
                }

                _repo.Update(NewValue);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoExists(NewValue.SortiecaisseId))
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
                _logger.LogWarning($"{0} => {1}", DateTime.Now.ToString(), "Entity set 'LabosContext.MeetSortieCaisses'  is null.");

            return NbDeletedObjects;
        }
    }
}
