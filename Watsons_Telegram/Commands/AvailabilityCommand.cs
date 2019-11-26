using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Watsons_Telegram.Commands
{
    public class AvailabilityCommand : Command
    {
        public override string Name => @"/slotavailability";

        public override bool Contains(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
                return false;

            return message.Text.Contains(this.Name) || message.Text.Contains("Slot Availabity");
        }

        public override async Task Execute(Message message, TelegramBotClient botClient)
        {
            var chatId = message.Chat.Id;

            ReplyKeyboardMarkup ReplyKeyboard = new[]
                    {
                        new[] { "Slot Availabity", "Waiting Time" },
                        new[] { "Operating Hours"},
                    };

            await botClient.SendTextMessageAsync(chatId, "Highly Available", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, replyMarkup: ReplyKeyboard);
        }
    }
}
