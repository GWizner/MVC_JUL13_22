using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCJUL13
{
    public class Program
    {
        public static System.Collections.Generic.List<MVCJUL13.Models.User> userList = new List<Models.User>();
        public static void Main(string[] args)
        {
            var newUser = new Models.User();
            newUser.Id = 1;
            newUser.FirstName = "Vash";
            newUser.LastName = "TheStampede";
            newUser.FavoriteCartoon = "X/1999";
            userList.Add(newUser);
            CreateHostBuilder(args).Build().Run();
        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
