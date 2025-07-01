using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace LineNotifierApi.Controllers
{
    [Route("api/notify")]
    [ApiController]
    public class NotifyController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _token = "YOUR_LINE_NOTIFY_TOKEN"; // ⚠️ 請替換成您自己的 token

        public NotifyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send([FromBody] NotifyRequest req)
        {
            if (string.IsNullOrWhiteSpace(req.Message))
                return BadRequest("Message is required");

            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("message", req.Message)
            });

            var response = await client.PostAsync("https://notify-api.line.me/api/notify", content);
            var result = await response.Content.ReadAsStringAsync();

            return Ok(new { success = response.IsSuccessStatusCode, result });
        }
    }

    public class NotifyRequest
    {
        public string Message { get; set; }
    }
}
