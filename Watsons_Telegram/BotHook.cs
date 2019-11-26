using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Watsons_Telegram.Commands;
using Watsons_Telegram.Models;

namespace Watsons_Telegram
{
    public class BotHook
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
            commandsList.Add(new ChatIdCommand());
            commandsList.Add(new OtherCommand());
            //TODO: Add more commands

            botClient = new TelegramBotClient(Bot.Key);
            string hook = string.Format(Bot.Url, "api/message/update");
            await botClient.SetWebhookAsync(hook);
            return botClient;
        }
    }
}
