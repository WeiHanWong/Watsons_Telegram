using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using Watsons_Telegram.Models;
using Watson_WebService;

namespace Watsons_Telegram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BroadcastController : ControllerBase
    {

        public ApplicationDbContext Database { get; }

        public BroadcastController(ApplicationDbContext database)
        {
            Database = database;
        }

        private static readonly HttpClient client = new HttpClient();

        [HttpPost]
        public IActionResult send([FromBody] string value)
        {
            dynamic broadcastBody = JsonConvert.DeserializeObject<dynamic>(value);
            var chatQuery = Database.TelegramUsers
                .Select(x => x.ChatId)
                .ToArray();

            //string[] chatQuery = new string[] { "473354391", "460865971" };

            var m = broadcastBody.message.Value;

            foreach (var chatid in chatQuery)
            {
                Task<HttpResponseMessage> task = client.PostAsync("https://api.telegram.org/bot" + Bot.Key + "/sendMessage?chat_id=" + chatid + "&text=" + m, null);
            }
                
            return Ok();
        }
    }
}