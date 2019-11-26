using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace Watsons_Telegram.Models.Commands
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
            await botClient.SendTextMessageAsync(chatId,
                @"Usage: 
/slotavailability - get slot availability
/waitingtime - get average waiting time
/operatinghours - get operating hours", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown);
        }
    }
}
