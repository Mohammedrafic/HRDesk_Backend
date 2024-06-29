using HRDesk;
using Microsoft.AspNetCore.Hosting;


namespace MyApiProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(WebBuilder => {
                WebBuilder.UseStartup<StartUp>();
            });
    }

}

