using Microsoft.EntityFrameworkCore;
using Arch.EntityFrameworkCore.UnitOfWork;
using Arch.EntityFrameworkCore.UnitOfWork.Collections;
using MeetingEntities.Models;
using System.Collections;

namespace Meeting.Web.Repository
{
    public interface IAnneeRepository
    {
        Task<int> Add(CoreAnnee YearValue);
        Task<int> Delete(int id);
        Task<IPagedList<CoreAnnee>> GetAll();
        Task<CoreAnnee?> GetDetails(int? id);
        Task<bool> SetDefault(int id);
        Task<int> Update(int id, CoreAnnee YearValue);
        IUnitOfWork GetUnitOfWork();
    }

    public class AnneeRepository : IAnneeRepository
    {
        private readonly ILogger<AnneeRepository> _logger;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly LabosContext _context;
        private readonly IRepository<CoreAnnee> _repo;

        public IUnitOfWork GetUnitOfWork() => _unitOfWork;

        public AnneeRepository(ILogger<AnneeRepository> logger, IUnitOfWork unitOfWork/*, LabosContext context*/)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            // _context = context;
            _repo = _unitOfWork.GetRepository<CoreAnnee>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Boolean> SetDefault(int id)
        {
            var coreAnnee = await this.GetDetails(id);
            if (coreAnnee != null)
            {
                var results = await _repo.GetPagedListAsync(predicate: p => p.AnneeId != id, disableTracking: false);
                foreach (var annee in results.Items.ToList())
                {
                    annee.IsCurrent = false;
                }
                coreAnnee.IsCurrent = true;
                _repo.Update(coreAnnee);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
            {
                _logger.LogWarning($"{0} => {1}", DateTime.Now.ToString(), "Entity set 'LabosContext.CoreAnnees'  is null.");
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CoreAnnee?> GetDetails(int? id)
        {
            if (id == null)
            {
                return null;
            }

            var Repo = _unitOfWork.GetRepository<CoreAnnee>();

            var coreAnnee = await _repo.GetFirstOrDefaultAsync(
                            include: m => m.Include(c => c.Bureau)
                                           .Include(c => c.Frequence)
                                           .Include(c => c.PreviousYear),
                            disableTracking: true,
                            predicate: m => m.AnneeId == id);
            return coreAnnee;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool AnneeExists(int id)
        {
            return (_repo.Count(e => e.AnneeId == id) != 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coreAnnee"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private async Task BuildMonthsAsync(CoreAnnee coreAnnee)
        {
            if (coreAnnee != null)
            {
                string ErrorMessage = String.Format("Error in the defined End date ({0}) compared to effective End date {1}, considering the number of months {2}.", coreAnnee.Datefin, coreAnnee.Datedebut.AddMonths(coreAnnee.Nbdivision), coreAnnee.Nbdivision);

                var DivisionsResult = await _unitOfWork.GetRepository<CoreSubdivision>().GetPagedListAsync(predicate: m => m.AnneeId == coreAnnee.AnneeId);
                var ExistantDivisions = DivisionsResult.Items.ToList();

                if ((coreAnnee.Nbdivision == 0) || (coreAnnee.Nbdivision == ExistantDivisions?.Count && coreAnnee.Nbdivision > 0))
                    return;

                if (coreAnnee.Datefin.Month != coreAnnee.Datedebut.AddMonths(coreAnnee.Nbdivision - 1).Month)
                    throw new Exception(ErrorMessage);

                var startDate = coreAnnee.Datedebut;
                string MonthName = string.Empty;

                if (coreAnnee.Nbdivision < ExistantDivisions?.Count)
                {
                    // for(int i = ((int)(ExistantDivisions?.Count-1)); i >= coreAnnee?.Nbdivision; i--)
                    {
                        int CountElts = (int)(ExistantDivisions?.Count - coreAnnee.Nbdivision);
                        _unitOfWork.GetRepository<CoreSubdivision>().Delete(ExistantDivisions.GetRange(coreAnnee.Nbdivision, CountElts));
                        //_context.CoreSubdivisions.RemoveRange(ExistantDivisions.GetRange((int)(coreAnnee?.Nbdivision), (int)(ExistantDivisions?.Count - coreAnnee?.Nbdivision)));
                    }
                }

                for (int i = 0; i < coreAnnee.Nbdivision; i++)
                {
                    startDate = coreAnnee.Datedebut.AddMonths(i);
                    MonthName = string.Format("{0:MMMM}-{1}", startDate, startDate.Year);

                    if (i < ExistantDivisions?.Count)
                    {
                        var periode = ExistantDivisions.ElementAt(i);
                        periode.Libelle = MonthName;
                        periode.Numordre = i + 1;
                        periode.MonthDate = startDate;
                        coreAnnee.CoreSubdivisions.Add(periode);
                    }
                    else
                        coreAnnee.CoreSubdivisions.Add(new CoreSubdivision
                        {
                            AnneeId = coreAnnee.AnneeId,
                            Numordre = i + 1,
                            Libelle = MonthName,
                            MonthDate = startDate
                        });
                }

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IPagedList<CoreAnnee>> GetAll()
        {
            return await _repo.GetPagedListAsync(disableTracking: true,
                                      include: m => m.Include(c => c.Bureau)
                                                     .Include(c => c.Frequence)
                                                     .Include(c => c.PreviousYear),
                                      orderBy: m => m.OrderByDescending(m => m.Datedebut));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="valueDto"></param>
        /// <returns></returns>
        public async Task<int> Add(CoreAnnee YearValue)
        {
            if (YearValue == null)
                return 0;

            await this.BuildMonthsAsync(YearValue);
            _repo.Insert(YearValue);

            return await _unitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="YearValue"></param>
        /// <returns></returns>
        public async Task<int> Update(int id, CoreAnnee YearValue)
        {
            try
            {
                if (YearValue == null || id != YearValue.AnneeId)
                {
                    return 0;
                }

                YearValue.BureauId = (YearValue.BureauId == 0) ? null : YearValue.BureauId;
                // YearValue.FrequenceId = (YearValue.FrequenceId == 0)? null : YearValue.FrequenceId;
                YearValue.PreviousYearId = (YearValue.PreviousYearId == 0) ? null : YearValue.PreviousYearId;

                await BuildMonthsAsync(YearValue);
                _repo.Update(YearValue);
                return await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnneeExists(YearValue.AnneeId))
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
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<int> Delete(int id)
        {

            int NbDeletedObjects = 0;
            var coreAnnee = this.GetDetails(id);

            if (coreAnnee != null)
            {
                _repo.Delete(coreAnnee);
                NbDeletedObjects = await _unitOfWork.SaveChangesAsync();
            }
            else
                _logger.LogWarning($"{0} => {1}", DateTime.Now.ToString(), "Entity set 'LabosContext.CoreAnnees'  is null.");

            return NbDeletedObjects;
        }
    }
}
