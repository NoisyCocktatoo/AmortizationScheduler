using Amortization.Domain.Contexts;
using Amortization.Infrastructure.Services.DataRepositories;
using Amortization.Infrastructure.Services.DataServices;
using Amortization.WebApp.Pages;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

#region Licenses
var syncfusion = builder.Configuration.GetSection("LicenseKeys");
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(syncfusion["Syncfusion"]);
#endregion Licenses

#region DBConnection

#if DEBUG
string connectionString = "DefaultConnection";
#else
string connectionString = "ProductionConnection";
#endif

builder.Services.AddDbContext<AmortizationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString(connectionString),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure();
        });
});
#endregion DBConnection


#region ServiceContainer

builder.Services.AddScoped<AmortizationDBContext>(provider =>
{
    var optionsBuilder = new DbContextOptionsBuilder<AmortizationDBContext>();
    var configuration = provider.GetRequiredService<IConfiguration>();

    optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString(connectionString), sqlOptions =>
    {
        sqlOptions.EnableRetryOnFailure();
    });
    return new AmortizationDBContext(optionsBuilder.Options);
});

builder.Services.AddScoped<IDataRepository, DataRepository>();
builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<IDependencyAggregate, DependencyAggregate>();
#endregion ServiceContainer


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
