using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace MyCourse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string arg01 = args.FirstOrDefault();
            CreateWebHostBuilder(args).Build().Run();
        }

        //KESTREL => webserver di default di .netCore

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
