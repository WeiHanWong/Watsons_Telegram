using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Watsons_Telegram.Models
{
    public class AppSettings
    {
        public static string Url { get; set; } = "https://watsonstelegram.azurewebsites.net:443/{0}";
        public static string Name { get; set; } = "watsons_bot";
        public static string Key { get; set; } = "1003051671:AAHsWnY16v1DTMl7jDPg1q80MvtBR5xA4k4";
    }
}
