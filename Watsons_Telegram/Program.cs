using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;
using Watson_WebService;

namespace Watsons_Telegram
{
    public class Program
    {

        public static void Main(string[] args)
        {
            //DataSeeder();
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        private static void DataSeeder()
        {
            using (var context = new ApplicationDbContext())
            {
                context.Database.EnsureDeleted();
                // Creates the database if not exists
                context.Database.EnsureCreated();

                context.SaveChanges();
            }
        }
    }
}
