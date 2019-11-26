using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Watson_WebService;
using Watsons_Telegram.Models;

namespace Watsons_Telegram.Commands
{
    public class StartCommand : Command
    {
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

            ApplicationDbContext Database = new ApplicationDbContext();

            TelegramUser newUser = new TelegramUser();

            var slotQueryResultCount = Database.TelegramUsers
            .Where(x => x.ChatId == chatId.ToString())
            .Count();

            if(slotQueryResultCount < 1)
            {
                newUser.ChatId = chatId.ToString();

                Database.TelegramUsers.Add(newUser);
                Database.SaveChanges();
            }

            await botClient.SendTextMessageAsync(chatId, 
                @"Usage: 
/slotavailability - get slot availability
/waitingtime - get average waiting time
/operatinghours - get operating hours", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
