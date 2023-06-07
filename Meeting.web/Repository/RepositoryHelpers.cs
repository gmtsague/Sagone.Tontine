using Arch.EntityFrameworkCore.UnitOfWork;
using Mapster;
using Meeting.web.Controllers;
using Meeting.Web.Dto;
using MeetingEntities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Meeting.Web.Repository
{
    internal static class RepositoryHelpers
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="excludedValue"></param>
        /// <returns></returns>
        public static async Task<IEnumerable<CoreAnnee>> GetAnneesForSelectListBox(IUnitOfWork unitOfWork, long excludedValue = 0)
        {
            var tempRepo = unitOfWork.GetRepository<CoreAnnee>();
            var Results = await tempRepo.GetPagedListAsync(disableTracking: true,
                                                 predicate: m => excludedValue <= 0 || m.AnneeId != excludedValue,
                                                 orderBy: m => m.OrderByDescending(m => m.Datedebut)
                                                 );
            return Results.Items;
        }

        public static async Task<IEnumerable<MeetBureau>> GetBureauxForSelectListBox(IUnitOfWork unitOfWork, long excludedValue = 0)
        {
            var tempRepo = unitOfWork.GetRepository<MeetBureau>();
            var Results = await tempRepo.GetPagedListAsync(disableTracking: true,
                                                 predicate: m => excludedValue <= 0 || m.BureauId != excludedValue,
                                                 orderBy: m => m.OrderByDescending(m => m.Debut)
                                                 );
            return Results.Items;
        }


        public static async Task<IEnumerable<CoreFrequenceDivision>> GetFrequenceDivisionsForSelectListBox(IUnitOfWork unitOfWork, long excludedValue = 0)
        {
            var tempRepo = unitOfWork.GetRepository<CoreFrequenceDivision>();
            var Results = await tempRepo.GetPagedListAsync(disableTracking: true,
                                                 predicate: m => excludedValue <= 0 || m.FrequenceId != excludedValue,
                                                 orderBy: m => m.OrderByDescending(m => m.NbDays)
                                                 );
            return Results.Items;
        }


        //public static SelectList GetSelectListOfAnnees(LabosContext context, long selectedValue = 0)
        //{
        //    List<AnneeDto>? ItemsList = null;

        //    TypeAdapterConfig<CoreAnnee, AnneeDto>.NewConfig().MaxDepth(3);

        //    if (context == null || context.CoreAnnees == null)
        //        ItemsList = new List<AnneeDto>();
        //    else
        //        ItemsList = context.CoreAnnees.OrderByDescending(m => m.Datedebut).AsNoTracking().ProjectToType<AnneeDto>().ToList();

        //    return new SelectList(ItemsList, "AnneeId", "Libelle", selectedValue);
        //}

        public static async Task<IEnumerable<CoreSubdivision>> GetYearSubdivisionsForSelectListBox(IUnitOfWork unitOfWork, long YearId, long excludedValue = 0)
        {
            //List<SubdivisionDto>? ItemsList = null;

            //TypeAdapterConfig<CoreSubdivision, SubdivisionDto>.NewConfig().MaxDepth(3);

            //if (context == null || context.CoreSubdivisions == null)
            //    ItemsList = new List<SubdivisionDto>();
            //else
            //    ItemsList = context.CoreSubdivisions.Where(m => m.AnneeId == YearId).OrderByDescending(m => m.MonthDate).AsNoTracking().ProjectToType<SubdivisionDto>().ToList();

            //return new SelectList(ItemsList, "DivisionId", "Libelle", selectedValue);

            var tempRepo = unitOfWork.GetRepository<CoreSubdivision>();
            var Results = await tempRepo.GetPagedListAsync(disableTracking: true,
                                                 predicate: m => m.AnneeId == YearId && (excludedValue <= 0 || m.DivisionId != excludedValue),
                                                 orderBy: m => m.OrderByDescending(m => m.MonthDate)
                                                 );
            return Results.Items;
        }

        public static async Task<IEnumerable<CoreCountry>> GetCountriesForSelectListBox(IUnitOfWork unitOfWork, long excludedValue = 0)
        {
            //List<CountryDto>? ItemsList = null;

            //if (context == null || context.CoreCountries == null)
            //    ItemsList = new List<CountryDto>();
            //else
            //    ItemsList = context.CoreCountries.OrderBy(m => m.Libelle).AsNoTracking().ProjectToType<CountryDto>().ToList();

            //return new SelectList(ItemsList, "CountryId", "Libelle", selectedValue);

            var tempRepo = unitOfWork.GetRepository<CoreCountry>();
            var Results = await tempRepo.GetPagedListAsync(disableTracking: true,
                                                 predicate: m => excludedValue <= 0 || m.CountryId != excludedValue,
                                                 orderBy: m => m.OrderByDescending(m => m.Libelle)
                                                 );
            return Results.Items;
        }

        public static async Task<IEnumerable<MeetTypeRubrique>> GetTypeRubriquesForSelectListBox(IUnitOfWork unitOfWork, long excludedValue = 0)
        {
            //List<TypeRubriqueDto>? ItemsList = null;

            //TypeAdapterConfig<MeetTypeRubrique, TypeRubriqueDto>.NewConfig().MaxDepth(3);

            //if (context == null || context.MeetTypeRubriques == null)
            //    ItemsList = new List<TypeRubriqueDto>();
            //else
            //    ItemsList = context.MeetTypeRubriques.Where(m => m.IsActive == true).OrderBy(m => m.Libelle).AsNoTracking().ProjectToType<TypeRubriqueDto>().ToList();

            //return new SelectList(ItemsList, "TyperubId", "Libelle", selectedValue);

            var tempRepo = unitOfWork.GetRepository<MeetTypeRubrique>();
            var Results = await tempRepo.GetPagedListAsync(disableTracking: true,
                                                 predicate: m => m.IsActive == true && (excludedValue <= 0 || m.TyperubId != excludedValue),
                                                 orderBy: m => m.OrderByDescending(m => m.Libelle)
                                                 );
            return Results.Items;
        }

        public static async Task<IEnumerable<MeetRubrique>> GetRubriquesForSelectListBox(IUnitOfWork unitOfWork, long YearId, long excludedValue = 0)
        {
            //List<RubriqueDto>? ItemsList = null;

            //TypeAdapterConfig<MeetRubrique, RubriqueDto>.NewConfig().MaxDepth(3);

            //if (context == null || context.MeetRubriques == null)
            //    ItemsList = new List<RubriqueDto>();
            //else
            //    ItemsList = context.MeetRubriques.OrderBy(m => m.Libelle).Where(m => YearId <= 0 || m.AnneeId == YearId).AsNoTracking().ProjectToType<RubriqueDto>().ToList();

            //return new SelectList(ItemsList, "RubriqueId", "Libelle", selectedValue);

            var tempRepo = unitOfWork.GetRepository<MeetRubrique>();
            var Results = await tempRepo.GetPagedListAsync(disableTracking: true,
                                                 predicate: m => (YearId <= 0 || m.AnneeId == YearId) && (excludedValue <= 0 || m.RubriqueId != excludedValue),
                                                 orderBy: m => m.OrderByDescending(m => m.Libelle)
                                                 );
            return Results.Items;
        }

        public static async Task<IEnumerable<MeetPoste>> GetPostesForSelectListBox(IUnitOfWork unitOfWork, long excludedValue = 0)
        {
            //List<PosteDto>? ItemsList = null;

            //TypeAdapterConfig<MeetPoste, PosteDto>.NewConfig().MaxDepth(3);

            //if (context == null || context.MeetPostes == null)
            //    ItemsList = new List<PosteDto>();
            //else
            //    ItemsList = context.MeetPostes.OrderBy(m => m.Libelle).AsNoTracking().ProjectToType<PosteDto>().ToList();

            //return new SelectList(ItemsList, "PosteId", "Libelle", selectedValue);

            var tempRepo = unitOfWork.GetRepository<MeetPoste>();
            var Results = await tempRepo.GetPagedListAsync(disableTracking: true,
                                                 predicate: m => excludedValue <= 0 || m.PosteId != excludedValue,
                                                 orderBy: m => m.OrderBy(m => m.Libelle)
                                                 );
            return Results.Items;
        }

        public static async Task<IEnumerable<CoreEtablissement>> GetEtablissementsForSelectListBox(IUnitOfWork unitOfWork, long excludedValue = 0)
        {
            //List<EtablissementDto>? ItemsList = null;

            //if (context == null || context.CoreEtablissements == null)
            //    ItemsList = new List<EtablissementDto>();
            //else
            //    ItemsList = context.CoreEtablissements.OrderBy(m => m.Libelle).AsNoTracking().ProjectToType<EtablissementDto>().ToList();

            //return new SelectList(ItemsList, "EtabId", "Libelle", selectedValue);

            var tempRepo = unitOfWork.GetRepository<CoreEtablissement>();
            var Results = await tempRepo.GetPagedListAsync(disableTracking: true,
                                                 predicate: m => excludedValue <= 0 || m.EtabId != excludedValue,
                                                 orderBy: m => m.OrderBy(m => m.Libelle)
                                                 );
            return Results.Items;
        }

        public static async Task<IEnumerable<CorePerson>> GetPeopleForSelectListBox(IUnitOfWork unitOfWork, long excludedValue = 0)
        {
            //List<PersonDto>? ItemsList = null;

            //if (context == null || context.CorePeople == null)
            //    ItemsList = new List<PersonDto>();
            //else
            //    ItemsList = context.CorePeople.OrderBy(m => m.Nom).ThenBy(m => m.Prenom).AsNoTracking().ProjectToType<PersonDto>().ToList();

            //return new SelectList(ItemsList, "PersonId", "FullName", selectedValue);

            var tempRepo = unitOfWork.GetRepository<CorePerson>();
            var Results = await tempRepo.GetPagedListAsync(disableTracking: true,
                                                 predicate: m => excludedValue <= 0 || m.PersonId != excludedValue,
                                                 orderBy: m => m.OrderBy(m => m.Nom).ThenBy(m => m.Prenom)
                                                 );
            return Results.Items;
        }

        public static async Task<IEnumerable<CorePerson>> GetRegisteredPeopleForSelectListBox(IUnitOfWork unitOfWork, long YearId, long excludedValue = 0)
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

            //return new SelectList(ItemsList, "PersonId", "FullName", selectedValue);

            var tempRepo = unitOfWork.GetRepository<MeetInscription>();
            var Results = await tempRepo.GetPagedListAsync(disableTracking: true,
                                                           include: m => m.Include(m => m.Person),
                                                 predicate: m => (m.IsActive == true && (m.AnneeId == YearId || YearId <= 0)) && (excludedValue <= 0 || m.PersonId != excludedValue),
                                                 orderBy: m => m.OrderBy(m => m.Person.Nom).ThenBy(m => m.Person.Prenom)
                                                 );
            
            return Results.Items.Select(r => new CorePerson()
            {
                PersonId = r.PersonId,
                Nom = $"{r.Person.Nom}",
                Prenom = $"{r.Person.Prenom}"
            }).ToList();
        }


        public static async Task<IEnumerable<GenericResult>> GetInscriptionsForSelectListBox(IUnitOfWork unitOfWork, long YearId, long excludedValue = 0)
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

            //return new SelectList(ItemsList, "Id", "FullName", selectedValue);

            var tempRepo = unitOfWork.GetRepository<MeetInscription>();
            var Results = await tempRepo.GetPagedListAsync(disableTracking: true,
                                                           include: m => m.Include(m => m.Person),
                                                 predicate: m => (m.IsActive == true && (m.AnneeId == YearId || YearId <= 0)) && ( excludedValue <= 0 || m.Idinscrit != excludedValue),
                                                 orderBy: m => m.OrderBy(m => m.Person.Nom).ThenBy(m => m.Person.Prenom)
                                                 );
            return Results.Items.Select(r => new GenericResult(r.Idinscrit, $"{r.Person.Nom} {r.Person.Prenom}"));
        }

        public static async Task<IEnumerable<MeetAntenne>> GetAntennesForSelectListBox(IUnitOfWork unitOfWork, long MasterId, long excludedValue = 0)
        {
            //List<AntenneDto>? ItemsList = null;

            //if (context == null || context.MeetAntennes == null)
            //    ItemsList = new List<AntenneDto>();
            //else
            //    ItemsList = context.MeetAntennes.Where(m => m.EtabId == MasterId).OrderBy(m => m.Libelle).AsNoTracking().ProjectToType<AntenneDto>().ToList();

            //return new SelectList(ItemsList, "AntenneId", "Libelle", selectedValue);

            var tempRepo = unitOfWork.GetRepository<MeetAntenne>();
            var Results = await tempRepo.GetPagedListAsync(disableTracking: true,
                                                 predicate: m => m.EtabId == MasterId && (excludedValue <= 0 || m.AntenneId != excludedValue),
                                                 orderBy: m => m.OrderByDescending(m => m.Libelle)
                                                 );
            return Results.Items;
        }

        public static async Task<IEnumerable<MeetSeance>> GetSeancesForSelectListBox(IUnitOfWork unitOfWork, long MasterEtabId, long YearId, long excludedValue = 0)
        {
            var tempRepo = unitOfWork.GetRepository<MeetSeance>();
            var Results = await tempRepo.GetPagedListAsync(disableTracking: true,
                                                            include: m => m.Include(m => m.CoreSubdivision)
                                                                           .Include(m => m.MeetAntenne),
                                                 predicate: m => m.MeetAntenne.EtabId == MasterEtabId && m.AnneeId == YearId && (excludedValue <= 0 || m.SeanceId != excludedValue),
                                                 orderBy: m => m.OrderByDescending(m => m.CoreSubdivision.MonthDate)
                                                 );
            return Results.Items;//.Where(m => m.MeetAntenne.EtabId == MasterEtabId && m.AnneeId == YearId);
        }

        public static async Task<IEnumerable<MeetEngagement>> GetEngagementsNonPayesForSelectListBox(IUnitOfWork unitOfWork, long PeopleId, long YearId, long excludedValue = 0)
        {
            //List</*EngagementDto*/ GenericResult>? ItemsList = null;

            //TypeAdapterConfig<MeetEngagement, EngagementDto>.NewConfig().MaxDepth(3);

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

            //return new SelectList(ItemsList, "Id", "FullName", selectedValue);

            var tempRepo = unitOfWork.GetRepository<MeetEngagement>();
            var Results = await tempRepo.GetPagedListAsync(disableTracking: true,
                                                 include: m => m.Include(m => m.Rubrique)
                                                                .Include(m => m.Person),
                                                 predicate: m => excludedValue <= 0 || m.RubriqueId != excludedValue
                                                 //orderBy: m => m.OrderByDescending(m => m.NbDays)
                                                 );
            return Results.Items.Where(m => (m.PersonId == PeopleId || PeopleId <= 0))
                                .Where(m => (m.IsClosed == false && m.IsOutcome == true && (m.Rubrique.AnneeId == YearId || YearId <= 0)));
        }

    }
}