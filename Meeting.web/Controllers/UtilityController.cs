using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MeetingEntities.Models;
using Meeting.Web.Dto;
using Mapster;
using System.Diagnostics;
using Meeting.Web.Repository;
using Arch.EntityFrameworkCore.UnitOfWork;
//using static Meeting.Web.Dto.AppPageViewModel<TEntity>;

namespace Meeting.web.Controllers
{
    public class UtilityController : Controller
    {
        private readonly LabosContext _context;

        public static string SuccessOperation { get; } = "Opération réalisée avec succès.";
        public static string RequestedEntityNotFound { get; } = "Requested Entity Not Found.";
        public static string DeleteOperationFailed { get; } = "Delete operation failed: Requested Entity Not Found.";
        public static string SetAsDefaultOperationFailed { get; } = "Operation failed";

        // public static AnneeDto GlobalSelectedYear { get; set; }
        // public static EtablissementDto GlobalSelectedEtab { get; set; }
        public static SessionEntitiesDto? SessionEntities { get; set; } = new SessionEntitiesDto();

        private readonly ILogger<UtilityController> _logger;

        public UtilityController(ILogger<UtilityController> logger, LabosContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        //------BEGIN-----

        public static SelectList GetSelectListOfBureaux(IUnitOfWork unitOfWork, long selectedValue = 0, long excludedValue = 0)
        {
            var ItemsList = RepositoryHelpers.GetBureauxForSelectListBox(unitOfWork, excludedValue).Result.AsQueryable().ProjectToType<BureauDto>().ToList();
            return new SelectList(ItemsList, "BureauId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfFrequenceDivisions(IUnitOfWork unitOfWork, long selectedValue = 0, long excludedValue = 0)
        {
            var ItemsList = RepositoryHelpers.GetFrequenceDivisionsForSelectListBox(unitOfWork, excludedValue).Result.AsQueryable().ProjectToType<FrequenceDivisionDto>().ToList();
            return new SelectList(ItemsList, "FrequenceId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfAnnees(IUnitOfWork unitOfWork, long selectedValue = 0, long excludedValue = 0)
        {
            TypeAdapterConfig<CoreAnnee, AnneeDto>.NewConfig().MaxDepth(3);

            var ItemsList = RepositoryHelpers.GetAnneesForSelectListBox(unitOfWork, excludedValue).Result.AsQueryable().ProjectToType<AnneeDto>().ToList();
            return new SelectList(ItemsList, "AnneeId", "Libelle", selectedValue);
        }


        public static SelectList GetSelectListOfYearSubdivisions(IUnitOfWork unitOfWork, long YearId, long selectedValue = 0, long excludedValue = 0)
        {

            TypeAdapterConfig<CoreSubdivision, SubdivisionDto>.NewConfig().MaxDepth(3);
            //List<SubdivisionDto>? ItemsList = null;

            //if (context == null || context.CoreSubdivisions == null)
            //    ItemsList = new List<SubdivisionDto>();
            //else
            //    ItemsList = context.CoreSubdivisions.Where(m => m.AnneeId == YearId).OrderByDescending(m => m.MonthDate).AsNoTracking().ProjectToType<SubdivisionDto>().ToList();

            var ItemsList = RepositoryHelpers.GetYearSubdivisionsForSelectListBox(unitOfWork, excludedValue).Result.AsQueryable().ProjectToType<SubdivisionDto>().ToList();
            return new SelectList(ItemsList, "DivisionId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfCountries(IUnitOfWork unitOfWork, long selectedValue = 0, long excludedValue = 0)
        {
            //List<CountryDto>? ItemsList = null;

            //if (context == null || context.CoreCountries == null)
            //    ItemsList = new List<CountryDto>();
            //else
            //    ItemsList = context.CoreCountries.OrderBy(m => m.Libelle).AsNoTracking().ProjectToType<CountryDto>().ToList();

            var ItemsList = RepositoryHelpers.GetCountriesForSelectListBox(unitOfWork, excludedValue).Result.AsQueryable().ProjectToType<CountryDto>().ToList();
            return new SelectList(ItemsList, "CountryId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfTypeRubriques(IUnitOfWork unitOfWork, long selectedValue = 0, long excludedValue = 0)
        {
            TypeAdapterConfig<MeetTypeRubrique, TypeRubriqueDto>.NewConfig().MaxDepth(3);
            //List<TypeRubriqueDto>? ItemsList = null;

            //if (context == null || context.MeetTypeRubriques == null)
            //    ItemsList = new List<TypeRubriqueDto>();
            //else
            //    ItemsList = context.MeetTypeRubriques.Where(m => m.IsActive == true).OrderBy(m => m.Libelle).AsNoTracking().ProjectToType<TypeRubriqueDto>().ToList();

            var ItemsList = RepositoryHelpers.GetTypeRubriquesForSelectListBox(unitOfWork, excludedValue).Result.AsQueryable().ProjectToType<TypeRubriqueDto>().ToList();

            return new SelectList(ItemsList, "TyperubId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfRubriques(IUnitOfWork unitOfWork, long YearId, long selectedValue = 0, long excludedValue = 0)
        {

            TypeAdapterConfig<MeetRubrique, RubriqueDto>.NewConfig().MaxDepth(3);

            //List<RubriqueDto>? ItemsList = null;
            //if (context == null || context.MeetRubriques == null)
            //    ItemsList = new List<RubriqueDto>();
            //else
            //    ItemsList = context.MeetRubriques.OrderBy(m => m.Libelle).Where(m => YearId <= 0 || m.AnneeId == YearId).AsNoTracking().ProjectToType<RubriqueDto>().ToList();

            var ItemsList = RepositoryHelpers.GetRubriquesForSelectListBox(unitOfWork, excludedValue).Result.AsQueryable().ProjectToType<RubriqueDto>().ToList();

            return new SelectList(ItemsList, "RubriqueId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfPostes(IUnitOfWork unitOfWork, long selectedValue = 0, long excludedValue = 0)
        {

            TypeAdapterConfig<MeetPoste, PosteDto>.NewConfig().MaxDepth(3);
            //List<PosteDto>? ItemsList = null;

            //if (context == null || context.MeetPostes == null)
            //    ItemsList = new List<PosteDto>();
            //else
            //    ItemsList = context.MeetPostes.OrderBy(m => m.Libelle).AsNoTracking().ProjectToType<PosteDto>().ToList();

            var ItemsList = RepositoryHelpers.GetPostesForSelectListBox(unitOfWork, excludedValue).Result.AsQueryable().ProjectToType<PosteDto>().ToList();

            return new SelectList(ItemsList, "PosteId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfEtablissements(IUnitOfWork unitOfWork, long selectedValue = 0, long excludedValue = 0)
        {
            //List<EtablissementDto>? ItemsList = null;

            //if (context == null || context.CoreEtablissements == null)
            //    ItemsList = new List<EtablissementDto>();
            //else
            //    ItemsList = context.CoreEtablissements.OrderBy(m => m.Libelle).AsNoTracking().ProjectToType<EtablissementDto>().ToList();

            var ItemsList = RepositoryHelpers.GetEtablissementsForSelectListBox(unitOfWork, excludedValue).Result.AsQueryable().ProjectToType<EtablissementDto>().ToList();

            return new SelectList(ItemsList, "EtabId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfPeople(IUnitOfWork unitOfWork, long selectedValue = 0, long excludedValue = 0)
        {
            //List<PersonDto>? ItemsList = null;

            //if (context == null || context.CorePeople == null)
            //    ItemsList = new List<PersonDto>();
            //else
            //    ItemsList = context.CorePeople.OrderBy(m => m.Nom).ThenBy(m => m.Prenom).AsNoTracking().ProjectToType<PersonDto>().ToList();

            var ItemsList = RepositoryHelpers.GetPeopleForSelectListBox(unitOfWork, excludedValue).Result.AsQueryable().ProjectToType<PersonDto>().ToList();

            return new SelectList(ItemsList, "PersonId", "FullName", selectedValue);
        }

        public static SelectList GetSelectListOfRegisteredPeople(IUnitOfWork unitOfWork, long YearId, long selectedValue = 0, long excludedValue = 0)
        {
            //List<PersonDto>? ItemsList = null;

            //if (context == null || context.MeetInscriptions == null)
            //    ItemsList = new List<PersonDto>();
            //else
            //    ItemsList = context.MeetInscriptions
            //           .Include(m => m.Person)
            //           .Where(m => m.IsActive == true && (m.AnneeId == YearId || YearId <= 0))
            //           .OrderBy(m => m.Person.Nom).ThenBy(m => m.Person.Prenom)
            //           .Select(r => new PersonDto()
            //           {
            //               PersonId = r.PersonId,
            //               FullName = $"{r.Person.Nom} {r.Person.Prenom}"
            //           })
            //           .ToList();
            /////ItemsList = context.CorePeople.AsQueryable().Join(_context.MeetInscription, p=>p.PersonId, reg =>reg.PersonId, (p,reg)=>).OrderBy(m => m.Nom).ThenBy(m => m.Prenom).AsNoTracking().ProjectToType<PersonDto>().ToList();

            var ItemsList = RepositoryHelpers.GetRegisteredPeopleForSelectListBox(unitOfWork, excludedValue).Result.AsQueryable().ProjectToType<PersonDto>().ToList();

            return new SelectList(ItemsList, "PersonId", "FullName", selectedValue);
        }


        public static SelectList GetSelectListOfInscriptions(IUnitOfWork unitOfWork, long YearId, long selectedValue = 0, long excludedValue = 0)
        {
            //List<GenericResult>? ItemsList = null;

            //if (context == null || context.MeetInscriptions == null)
            //    ItemsList = new List<GenericResult>();
            //else
            //    ItemsList = context.MeetInscriptions
            //           .Include(m => m.Person)
            //           .Where(m => m.IsActive == true && (m.AnneeId == YearId || YearId <= 0))
            //           .OrderBy(m => m.Person.Nom).ThenBy(m => m.Person.Prenom)
            //           .Select(r => new GenericResult(r.Idinscrit, $"{r.Person.Nom} {r.Person.Prenom}"))
            //           .ToList();
            /////ItemsList = context.CorePeople.AsQueryable().Join(_context.MeetInscription, p=>p.PersonId, reg =>reg.PersonId, (p,reg)=>).OrderBy(m => m.Nom).ThenBy(m => m.Prenom).AsNoTracking().ProjectToType<PersonDto>().ToList();

            var ItemsList = RepositoryHelpers.GetInscriptionsForSelectListBox(unitOfWork, YearId, excludedValue).Result.AsQueryable().ProjectToType<GenericResult>().ToList();
            return new SelectList(ItemsList, "Id", "FullName", selectedValue);
        }

        public static SelectList GetSelectListOfAntennes(IUnitOfWork unitOfWork, long MasterId, long selectedValue = 0, long excludedValue = 0)
        {
            //List<AntenneDto>? ItemsList = null;

            //if (context == null || context.MeetAntennes == null)
            //    ItemsList = new List<AntenneDto>();
            //else
            //    ItemsList = context.MeetAntennes.Where(m => m.EtabId == MasterId).OrderBy(m => m.Libelle).AsNoTracking().ProjectToType<AntenneDto>().ToList();

            var ItemsList = RepositoryHelpers.GetAntennesForSelectListBox(unitOfWork, MasterId, excludedValue).Result.AsQueryable().ProjectToType<AntenneDto>().ToList();
            return new SelectList(ItemsList, "AntenneId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfSeances(IUnitOfWork unitOfWork, long MasterEtabId, long YearId, long selectedValue = 0, long excludedValue = 0)
        {
            //List<SeanceDto>? ItemsList = null;

            //if (context == null || context.MeetAntennes == null)
            //    ItemsList = new List<SeanceDto>();
            //else
            //    ItemsList = context.MeetSeances.Include(m => m.CoreSubdivision)
            //                           .Include(m => m.MeetAntenne)
            //                           .Where(m => m.MeetAntenne.EtabId == MasterEtabId && m.AnneeId == YearId)
            //                           .AsNoTracking().ProjectToType<SeanceDto>().ToList();

            var ItemsList = RepositoryHelpers.GetSeancesForSelectListBox(unitOfWork, YearId, excludedValue).Result.AsQueryable().ProjectToType<SeanceDto>().ToList();
            return new SelectList(ItemsList, "SeanceId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfEngagementsNonPayes(IUnitOfWork unitOfWork, long PeopleId, long YearId, long selectedValue = 0, long excludedValue = 0)
        {

            TypeAdapterConfig<MeetEngagement, EngagementDto>.NewConfig().MaxDepth(3);

            //List</*EngagementDto*/ GenericResult>? ItemsList = null;
            //if (context == null || context.MeetAntennes == null)
            //    ItemsList = new List</*EngagementDto*/ GenericResult>();
            //else
            //    ItemsList = context.MeetEngagements
            //                       .Include(m => m.Rubrique)
            //                        .Include(m => m.Person)
            //                        //.ThenInclude(m => m.MeetInscriptions.Where(p => p.AntenneId == AntenneId || AntenneId <= 0))
            //                        .Where(m => (m.PersonId == PeopleId || PeopleId <= 0))
            //                        .Where(m => (m.IsClosed == false && m.IsOutcome == true && (m.Rubrique.AnneeId == YearId || YearId <= 0)))
            //                        //.Where(m => (m.RubriqueId == RubriqueId || RubriqueId <= 0))
            //                        .AsNoTracking().ProjectToType<EngagementDto>()
            //                        .Select(r => new GenericResult(r.EngagementId, r.Libelle)).ToList();

            var ItemsList = RepositoryHelpers.GetEngagementsNonPayesForSelectListBox(unitOfWork, PeopleId, YearId, excludedValue).Result.AsQueryable().ProjectToType<EngagementDto>().ToList();

            return new SelectList(ItemsList, "Id", "FullName", selectedValue);
        }

        //------END-------

        public static SelectList GetSelectListOfBureaux(LabosContext context, long selectedValue = 0)
        {
            List<BureauDto>? ItemsList = null;
            BureauDto selectInstruction = new BureauDto() { BureauId = 0, Libelle = "Select one", Debut = DateOnly.MinValue, Fin = DateOnly.MaxValue, Nbperson = 0, Nbvotes = 0, Nbabstention = 0 };

            if (context == null || context.MeetBureaus == null)
                ItemsList = new List<BureauDto>();
            else
                ItemsList = context.MeetBureaus.OrderByDescending(m => m.Debut).AsNoTracking().ProjectToType<BureauDto>().ToList();
            ItemsList.Insert(0, selectInstruction);

            return new SelectList(ItemsList, "BureauId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfFrequenceDivisions(LabosContext context, long selectedValue = 0)
        {
            List<FrequenceDivisionDto>? ItemsList = null;

            if (context == null || context.CoreFrequenceDivisions == null)
                ItemsList = new List<FrequenceDivisionDto>();
            else
                ItemsList = context.CoreFrequenceDivisions.AsNoTracking().ProjectToType<FrequenceDivisionDto>().ToList();

            return new SelectList(ItemsList, "FrequenceId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfAnnees(LabosContext context, long selectedValue = 0)
        {
            List<AnneeDto>? ItemsList = null;

            TypeAdapterConfig<CoreAnnee, AnneeDto>.NewConfig().MaxDepth(3);

            if (context == null || context.CoreAnnees == null)
                ItemsList = new List<AnneeDto>();
            else
                ItemsList = context.CoreAnnees.OrderByDescending(m => m.Datedebut).AsNoTracking().ProjectToType<AnneeDto>().ToList();

            return new SelectList(ItemsList, "AnneeId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfYearSubdivisions(LabosContext context, long YearId, long selectedValue = 0)
        {
            List<SubdivisionDto>? ItemsList = null;

            TypeAdapterConfig<CoreSubdivision, SubdivisionDto>.NewConfig().MaxDepth(3);

            if (context == null || context.CoreSubdivisions == null)
                ItemsList = new List<SubdivisionDto>();
            else
                ItemsList = context.CoreSubdivisions.Where(m => m.AnneeId == YearId).OrderByDescending(m => m.MonthDate).AsNoTracking().ProjectToType<SubdivisionDto>().ToList();

            return new SelectList(ItemsList, "DivisionId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfCountries(LabosContext context, long selectedValue = 0)
        {
            List<CountryDto>? ItemsList = null;

            if (context == null || context.CoreCountries == null)
                ItemsList = new List<CountryDto>();
            else
                ItemsList = context.CoreCountries.OrderBy(m => m.Libelle).AsNoTracking().ProjectToType<CountryDto>().ToList();

            return new SelectList(ItemsList, "CountryId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfTypeRubriques(LabosContext context, long selectedValue = 0)
        {
            List<TypeRubriqueDto>? ItemsList = null;

            TypeAdapterConfig<MeetTypeRubrique, TypeRubriqueDto>.NewConfig().MaxDepth(3);

            if (context == null || context.MeetTypeRubriques == null)
                ItemsList = new List<TypeRubriqueDto>();
            else
                ItemsList = context.MeetTypeRubriques.Where(m => m.IsActive == true).OrderBy(m => m.Libelle).AsNoTracking().ProjectToType<TypeRubriqueDto>().ToList();

            return new SelectList(ItemsList, "TyperubId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfRubriques(LabosContext context, long YearId, long selectedValue = 0)
        {
            List<RubriqueDto>? ItemsList = null;

            TypeAdapterConfig<MeetRubrique, RubriqueDto>.NewConfig().MaxDepth(3);

            if (context == null || context.MeetRubriques == null)
                ItemsList = new List<RubriqueDto>();
            else
                ItemsList = context.MeetRubriques.OrderBy(m => m.Libelle).Where(m => YearId <= 0 || m.AnneeId == YearId).AsNoTracking().ProjectToType<RubriqueDto>().ToList();

            return new SelectList(ItemsList, "RubriqueId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfPostes(LabosContext context, long selectedValue = 0)
        {
            List<PosteDto>? ItemsList = null;

            TypeAdapterConfig<MeetPoste, PosteDto>.NewConfig().MaxDepth(3);

            if (context == null || context.MeetPostes == null)
                ItemsList = new List<PosteDto>();
            else
                ItemsList = context.MeetPostes.OrderBy(m => m.Libelle).AsNoTracking().ProjectToType<PosteDto>().ToList();

            return new SelectList(ItemsList, "PosteId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfEtablissements(LabosContext context, long selectedValue = 0)
        {
            List<EtablissementDto>? ItemsList = null;

            if (context == null || context.CoreEtablissements == null)
                ItemsList = new List<EtablissementDto>();
            else
                ItemsList = context.CoreEtablissements.OrderBy(m => m.Libelle).AsNoTracking().ProjectToType<EtablissementDto>().ToList();

            return new SelectList(ItemsList, "EtabId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfPeople(LabosContext context, long selectedValue = 0)
        {
            List<PersonDto>? ItemsList = null;

            if (context == null || context.CorePeople == null)
                ItemsList = new List<PersonDto>();
            else
                ItemsList = context.CorePeople.OrderBy(m => m.Nom).ThenBy(m => m.Prenom).AsNoTracking().ProjectToType<PersonDto>().ToList();

            return new SelectList(ItemsList, "PersonId", "FullName", selectedValue);
        }

        public static SelectList GetSelectListOfRegisteredPeople(LabosContext context, long YearId, long selectedValue = 0)
        {
            List<PersonDto>? ItemsList = null;

            if (context == null || context.MeetInscriptions == null)
                ItemsList = new List<PersonDto>();
            else
                ItemsList = context.MeetInscriptions
                       .Include(m=>m.Person)
                       .Where(m=>m.IsActive == true && (m.AnneeId == YearId || YearId <= 0))
                       .OrderBy(m => m.Person.Nom).ThenBy(m => m.Person.Prenom)
                       .Select(r=> new PersonDto() {
                           PersonId = r.PersonId, 
                           FullName = $"{r.Person.Nom} {r.Person.Prenom}"})
                       .ToList();
                ///ItemsList = context.CorePeople.AsQueryable().Join(_context.MeetInscription, p=>p.PersonId, reg =>reg.PersonId, (p,reg)=>).OrderBy(m => m.Nom).ThenBy(m => m.Prenom).AsNoTracking().ProjectToType<PersonDto>().ToList();

            return new SelectList(ItemsList, "PersonId", "FullName", selectedValue);
        }


        public static SelectList GetSelectListOfInscriptions(LabosContext context, long YearId, long selectedValue = 0)
        {
            List<GenericResult>? ItemsList = null;

            if (context == null || context.MeetInscriptions == null)
                ItemsList = new List<GenericResult>();
            else
                ItemsList = context.MeetInscriptions
                       .Include(m => m.Person)
                       .Where(m => m.IsActive == true && (m.AnneeId == YearId || YearId <= 0))
                       .OrderBy(m => m.Person.Nom).ThenBy(m => m.Person.Prenom)
                       .Select(r => new GenericResult( r.Idinscrit, $"{r.Person.Nom} {r.Person.Prenom}"))
                       .ToList();
            ///ItemsList = context.CorePeople.AsQueryable().Join(_context.MeetInscription, p=>p.PersonId, reg =>reg.PersonId, (p,reg)=>).OrderBy(m => m.Nom).ThenBy(m => m.Prenom).AsNoTracking().ProjectToType<PersonDto>().ToList();

            return new SelectList(ItemsList, "Id", "FullName", selectedValue);
        }

        public static SelectList GetSelectListOfAntennes(LabosContext context, long MasterId, long selectedValue = 0)
        {
            List<AntenneDto>? ItemsList = null;

            if (context == null || context.MeetAntennes == null)
                ItemsList = new List<AntenneDto>();
            else
                ItemsList = context.MeetAntennes.Where(m => m.EtabId == MasterId).OrderBy(m => m.Libelle).AsNoTracking().ProjectToType<AntenneDto>().ToList();

            return new SelectList(ItemsList, "AntenneId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfSeances(LabosContext context, long MasterEtabId, long YearId, long selectedValue = 0)
        {
            List<SeanceDto>? ItemsList = null;

            if (context == null || context.MeetAntennes == null)
                ItemsList = new List<SeanceDto>();
            else
                ItemsList = context.MeetSeances.Include(m => m.CoreSubdivision)
                                       .Include(m => m.MeetAntenne)
                                       .Where(m => m.MeetAntenne.EtabId == MasterEtabId && m.AnneeId == YearId)
                                       .AsNoTracking().ProjectToType<SeanceDto>().ToList();

            return new SelectList(ItemsList, "SeanceId", "Libelle", selectedValue);
        }

        public static SelectList GetSelectListOfEngagementsNonPayes(LabosContext context, long PeopleId, long YearId, long selectedValue = 0)
        {
            List</*EngagementDto*/ GenericResult>? ItemsList = null;

            TypeAdapterConfig<MeetEngagement, EngagementDto>.NewConfig().MaxDepth(3);

            if (context == null || context.MeetAntennes == null)
                ItemsList = new List</*EngagementDto*/ GenericResult>();
            else
                ItemsList = context.MeetEngagements
                                   .Include(m => m.Rubrique)
                                    .Include(m => m.Person)
                                    //.ThenInclude(m => m.MeetInscriptions.Where(p => p.AntenneId == AntenneId || AntenneId <= 0))
                                    .Where(m => (m.PersonId == PeopleId || PeopleId <= 0))
                                    .Where(m => (m.IsClosed == false && m.IsOutcome == true && (m.Rubrique.AnneeId  == YearId || YearId <= 0)))
                                    //.Where(m => (m.RubriqueId == RubriqueId || RubriqueId <= 0))
                                    .AsNoTracking().ProjectToType<EngagementDto>()
                                    .Select(r => new GenericResult(r.EngagementId, r.Libelle)).ToList();

            return new SelectList(ItemsList, "Id", "FullName", selectedValue);
        }

        public static long GetGlobalSelectedAssociation()
        {
            if (SessionEntities?.GlobalSelectedEtab == null)
                return 0;
            else
                return (long)(SessionEntities?.GlobalSelectedEtab?.EtabId);
        }

        public static long GetGlobalSelectedYear()
        {
            //AnneeDto? selectedYear = ViewData["SelectedYear"] as AnneeDto;
            if (SessionEntities?.GlobalSelectedYear == null)
                return 0;
            else
                return SessionEntities.GlobalSelectedYear.AnneeId;
        }
    }

    public record GenericResult(int Id, string FullName);

    public class SessionEntitiesDto
    {
        public AnneeDto? GlobalSelectedYear { get; set; }
        public EtablissementDto? GlobalSelectedEtab { get; set; }
    }
}
