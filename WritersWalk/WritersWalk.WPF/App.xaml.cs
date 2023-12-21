using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WritersWalk.Application;
using WritersWalk.Application.Database;

namespace WritersWalk.WPF;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : System.Windows.Application
{
    public IHost AppHost { get; private set; }

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
            .ConfigureServices((context, services) =>
            {
                services.AddApplicationServices(); 
            })
            .Build();
    }
    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        using var scope = AppHost.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<SqliteDbContext>();
        try
        {
            await dbContext.Database.CanConnectAsync();
            MessageBox.Show("Database connection successful!");
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Failed to connect to database. Error: {ex.Message}");
        }

        await dbContext.Database.MigrateAsync();


        await AppHost.StartAsync();
    }
    protected override async void OnExit(ExitEventArgs e)
    {
        using (AppHost)
        {
            base.OnExit(e);
            await AppHost.StopAsync(TimeSpan.FromSeconds(5));
        }
    }
}
