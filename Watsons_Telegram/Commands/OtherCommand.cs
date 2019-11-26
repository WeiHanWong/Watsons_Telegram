using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Watsons_Telegram.Commands
{
    public class OtherCommand : Command
    {
        public override string Name => "";

        public override bool Contains(Message message)
        {
            return true;
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;

            ReplyKeyboardMarkup ReplyKeyboard = new[]
                    {
                        new[] { "Slot Availabity", "Waiting Time" },
                        new[] { "Operating Hours"},
                    };

            await botClient.SendTextMessageAsync(chatId,
                @"Usage: 
/slotavailability - get slot availability
/waitingtime - get average waiting time
/operatinghours - get operating hours", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, replyMarkup: ReplyKeyboard);
        }
    }
}
