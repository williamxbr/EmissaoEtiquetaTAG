using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Quartz;

class Program
{
    static async Task Main(string[] args)
    {
        IHost Host = CreateHostBuilder(args).Build();
        await Host.RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args).ConfigureServices(services =>
    {
        ConfigureQuartzService(services);
        services.AddScoped<IEtiqueta, Etiqueta>();
    });

    private static void ConfigureQuartzService(IServiceCollection services)
    {
        services.AddQuartz(q => { 
            q.UseMicrosoftDependencyInjectionJobFactory();
            var jobKey = new JobKey("GerarEtiqueta");
            q.AddJob<GerarEtiquetaJob>(opts => opts.WithIdentity(jobKey));
            q.AddTrigger(opts => opts.ForJob(jobKey).WithIdentity("GerarEtiqueta-trigger").WithCronSchedule("0/5 * * * * ?"));
        });
        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
    }
}