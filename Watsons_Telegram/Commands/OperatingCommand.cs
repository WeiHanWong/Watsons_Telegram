using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Watsons_Telegram.Commands
{
    public class OperatingCommand : Command
    {
        public override string Name => @"/operatinghours";

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
                        new[] { "/slotavailability", "/waitingtime" },
                        new[] { "/operatinghours"},
                    };

            await botClient.SendTextMessageAsync(chatId, "8:00am to 11:45pm", parseMode: Telegram.Bot.Types.Enums.ParseMode.Markdown, replyMarkup: ReplyKeyboard);
        }
    }
}
