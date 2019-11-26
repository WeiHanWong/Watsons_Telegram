using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using Watsons_Telegram.Models;

namespace Watsons_Telegram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BroadcastController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();

        public IActionResult Create([FromBody] string value)
        {
            dynamic broadcastBody = JsonConvert.DeserializeObject<dynamic>(value);
            try
            {
                string[] ids = new string[] { "473354391", "460865971" };

                var m = broadcastBody.message.Value;

                foreach (var chatid in ids)
                {
                    Task<HttpResponseMessage> task = client.PostAsync("https://api.telegram.org/bot" + Bot.Key + "/sendMessage?chat_id=" + chatid + "&text=" + m, null);
                }
                
                return Ok();
            }
            catch (Exception)
            {
                object httpFailRequestResultMessage = new { message = "Unable to send" };
                return BadRequest(httpFailRequestResultMessage);
            }
        }

    }
}