using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace Watsons_Telegram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BroadcastController : ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();

        public IActionResult Create([FromBody] string value)
        {
            string customMessage = "";
            dynamic broadcastBody = JsonConvert.DeserializeObject<dynamic>(value);
            try
            {
                string[] ids = new string[] { "473354391", "460865971" };

                var m = broadcastBody.message.Value;

                string apiKey = "1003051671:AAHsWnY16v1DTMl7jDPg1q80MvtBR5xA4k4";

                foreach (var chatid in ids)
                {
                    Task<HttpResponseMessage> task = client.PostAsync("https://api.telegram.org/bot" + apiKey + "/sendMessage?chat_id=" + chatid + "&text=" + m, null);
                }
                
                return Ok();
            }
            catch (Exception)
            {
                customMessage = "Unable to send";
                object httpFailRequestResultMessage = new { message = customMessage };
                return BadRequest(httpFailRequestResultMessage);
            }
        }

    }
}