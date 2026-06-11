using BtkAkademiAi.WebUI.Dtos.TradingVideoDtos;
using BtkAkademiAi.WebUI.Dtos.UsersDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademiAi.WebUI.Controllers
{
    public class TradingVideoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TradingVideoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> TradingVideoList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7090/api/TradingVideos/");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTradingVideoDto>>(jsonData);
                return View(values);

            }

            return View();
        }
    }
}
