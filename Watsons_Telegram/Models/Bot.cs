using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Watsons_Telegram.Models.Commands;

namespace Watsons_Telegram.Models
{
    public class Bot
    {
        private static TelegramBotClient botClient;
        private static List<Command> commandsList;

        public static IReadOnlyList<Command> Commands => commandsList.AsReadOnly();

        public static async Task<TelegramBotClient> GetBotClientAsync()
        {
            if (botClient != null)
            {
                return botClient;
            }

            commandsList = new List<Command>();
            commandsList.Add(new StartCommand());
            commandsList.Add(new AvailabilityCommand());
            commandsList.Add(new WaitingCommand());
            commandsList.Add(new OperatingCommand());
            //TODO: Add more commands

            botClient = new TelegramBotClient(AppSettings.Key);
            string hook = string.Format(AppSettings.Url, "api/message/update");
            await botClient.SetWebhookAsync(hook);
            return botClient;
        }
    }
}
