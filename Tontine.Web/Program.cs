using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tontine.Web.Data;
using Tontine.Web.MappingConfig;
using Tontine.Entities.Models;
using FormHelper;
using Mapster;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
var connectionString = builder.Configuration.GetConnectionString("pgconn") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext</*ApplicationDbContext*/ LabosContext > (options => options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores</*ApplicationDbContext*/ LabosContext>();

builder.Services.AddMapster();

var config = new TypeAdapterConfig();
builder.Services.AddSingleton(config);
TypeAdapterConfig.GlobalSettings.RequireExplicitMapping = true;
TypeAdapterConfig.GlobalSettings.RequireDestinationMemberSource = true;
TypeAdapterConfig.GlobalSettings.Compile();

builder.Services.AddControllersWithViews();
builder.Services.AddControllersWithViews().AddFormHelper(options => {
    //options.CheckTheFormFieldsMessage = "Your custom message...";
    options.RedirectDelay = 3500;
    options.EmbeddedFiles = true;
    options.ToastrDefaultPosition = ToastrPosition.TopFullWidth;
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//<!--If you want to use embeded form helper files, add this line -->
app.UseFormHelper();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
