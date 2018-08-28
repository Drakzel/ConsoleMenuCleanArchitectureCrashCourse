using CrashCourse.Core.ApplicationService;
using CrashCourse.Core.ApplicationService.Services;
using CrashCourse.Core.DomainService;
using CrashCourse.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CrashCourse
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IVideoRepository, VideoRepository>();
            serviceCollection.AddScoped<IVideoService, VideoService>();
            serviceCollection.AddScoped<IPrinter, Printer>();

            ////then build provider 
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var printer = serviceProvider.GetRequiredService<IPrinter>();
            printer.InitiateMainMenu();
        }
    }
}
