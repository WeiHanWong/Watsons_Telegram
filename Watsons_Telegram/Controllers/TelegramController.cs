using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.ReplyMarkups;

namespace Watsons_Telegram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramController : ControllerBase
    {
        [HttpPost]
        public IActionResult sendAlert([FromBody] string value)
        {
            dynamic newAlertInput = JsonConvert.DeserializeObject<dynamic>(value);
            string globAlert = newAlertInput.alert.Value;
            try
            {
                TelegramBotClient Bot = new TelegramBotClient("931888826:AAGcgDtqjxGCzJvB0GAzL0lXii85ylv-T74");

                Bot.SendTextMessageAsync("@watson_pilot_bot", globAlert);

                object sendStatus = new { sendStatus = "Alert sent" };
                return Ok();
            }
            catch (Exception)
            {
                object httpFailRequestResultMessage = new { sendStatus = "Send fail" };
                return BadRequest(httpFailRequestResultMessage);
            }

        }

    }
}