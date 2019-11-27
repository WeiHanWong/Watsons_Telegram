using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Watson_WebService;
using Watsons_Telegram.Models;
using Telegram.Bot.Types.ReplyMarkups;

namespace Watsons_Telegram.Commands
{
    public class StartCommand : Command
    {

        public ApplicationDbContext Database { get; }

        public StartCommand()
        {
            Database = new ApplicationDbContext();
        }

        public override string Name => @"/start";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name);
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;

            ReplyKeyboardMarkup ReplyKeyboard = new[]
                    {
                        new[] { "Slot Availabity", "Waiting Time" },
                        new[] { "Operating Hours"},
                    };

            await botClient.SendTextMessageAsync(chatId, @"Verifying...
(Do not type anything. This make take a few moments. Please wait...)", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, replyMarkup: ReplyKeyboard);

            TelegramUser newUser = new TelegramUser();

            var slotQueryResultCount = Database.TelegramUsers
            .Where(x => x.ChatId == chatId.ToString())
            .Count();

            if (slotQueryResultCount < 1)
            {
                await botClient.SendTextMessageAsync(chatId, @"Registering...
(Do not type anything. Please wait...)", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, replyMarkup: ReplyKeyboard);

                newUser.ChatId = chatId.ToString();

                Database.TelegramUsers.Add(newUser);
                Database.SaveChanges();
                await botClient.SendTextMessageAsync(chatId,
                @"Registration Completed!
Usage: 
/slotavailability - get slot availability
/waitingtime - get average waiting time
/operatinghours - get operating hours", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, replyMarkup: ReplyKeyboard);
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId,
                @"You had previously registered!
Usage: 
/slotavailability - get slot availability
/waitingtime - get average waiting time
/operatinghours - get operating hours", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, replyMarkup: ReplyKeyboard);
            }

            
        }
    }
}
