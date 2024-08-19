using Infra.SoldierTrackingAssesment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace SoldierTrackingAssesment;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private readonly ServiceProvider serviceProvider;

    public App()
    {
        ServiceCollection services = new ServiceCollection();
        ConfigureServices(services);
        serviceProvider = services.BuildServiceProvider();
    }

    private void ConfigureServices(ServiceCollection services)
    {
        services.AddDbContext<SoldierTrackingAssesmentContext>(options => options
            .UseSqlServer(@"Server=localhost;Database=SoldierTracking_development;ConnectRetryCount=0;Password=password123!;User Id=sa;TrustServerCertificate=True;",
            builder => builder.UseNetTopologySuite()));

        services.AddSingleton<MainWindow>();
    }

    private void OnStartup(object sender, StartupEventArgs e)
    {
        var dbContext = serviceProvider.GetRequiredService<SoldierTrackingAssesmentContext>();

        dbContext.Database.Migrate();

        var mainWindow = serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}