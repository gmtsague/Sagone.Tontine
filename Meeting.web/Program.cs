using Microsoft.EntityFrameworkCore;
using MeetingEntities.Models;
//using Mapster;
using Meeting.Web.Mapsterconfig;
using FormHelper;
using Meeting.Web.Repository;
using Arch.EntityFrameworkCore.UnitOfWork;

//using System.Globalization;
//using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<LabosContext>(options => options.UseNpgsql(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<LabosContext>();

builder.Services.AddUnitOfWork<LabosContext>();

builder.Services.AddScoped<IAnneeRepository, AnneeRepository>();
builder.Services.AddScoped<IAntenneRepository, AntenneRepository>();
builder.Services.AddScoped<IBankRepository, BankRepository>();
builder.Services.AddScoped<IModepaieRepository, ModepaieRepository>();
builder.Services.AddScoped<ITypeRubriqueRepository, TypeRubriqueRepository>();
builder.Services.AddScoped<IPosteRepository, PosteRepository>();
builder.Services.AddScoped<IConfigvisasRepository, ConfigvisasRepository>();
builder.Services.AddScoped<IPreferencesRepository, PreferencesRepository>();

builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IInscriptionRepository, InscriptionRepository>();
builder.Services.AddScoped<IOrdrePassageRepository, OrdrePassageRepository>();
builder.Services.AddScoped<IRubriqueRepository, RubriqueRepository>();
builder.Services.AddScoped<IEngagementRepository, EngagementRepository>();
builder.Services.AddScoped<IPresencesRepository, PresencesRepository>();
builder.Services.AddScoped<ISeancesRepository, SeancesRepository>();
builder.Services.AddScoped<ISortiecaisseRepository, SortiecaisseRepository>();


builder.Services.AddMapster();

builder.Services.AddControllersWithViews()
                .AddFormHelper();
//builder.Services.AddControllersWithViews().AddFormHelper(options => {
//    //options.CheckTheFormFieldsMessage = "Your custom message...";
//    options.RedirectDelay = 3500;
//    options.EmbeddedFiles = true;
//    options.ToastrDefaultPosition = ToastrPosition.TopFullWidth;
//}).AddFluentValidation(); 

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => 
{
    options.IdleTimeout = TimeSpan.FromSeconds(180); //30 minutes
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

//builder.Services.Configure<RequestLocalizationOptions>(options =>
//{
//    var supportedCultures = new[]
//    {
//        new CultureInfo("en-US"),
//        new CultureInfo("fr"),
//        //new CultureInfo("es")
//    };

//    options.DefaultRequestCulture = new RequestCulture("fr");
//    options.SupportedCultures = supportedCultures;
//    options.SupportedUICultures = supportedCultures;
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();
//<!--If you want to use embeded form helper files, add this line -->
app.UseFormHelper();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();

app.Run();
