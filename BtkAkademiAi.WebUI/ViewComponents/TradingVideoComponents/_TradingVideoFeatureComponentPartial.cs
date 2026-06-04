using BtkAkademiAi.WebUI.Dtos.TradingVideoDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademiAi.WebUI.ViewComponents.DefaultComponents
{
    public class _TradingVideoFeatureComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _TradingVideoFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7090/api/TradingVideos/featured");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var  tradingVideo = JsonConvert.DeserializeObject<GetTradingFeatureVideoDto>(jsonData);
                ViewBag.TradingFeatureTitle = tradingVideo.VideoTitle;
                ViewBag.TradingFeatureVideoUrl = tradingVideo.VideoUrl;
                ViewBag.TradingFeatureVideoDescription = tradingVideo.VideoDescription;
                ViewBag.TradingFeatureIsFeature = tradingVideo.IsFeature;
                ViewBag.TradingFeatureImageUrl = tradingVideo.FeatureImageUrl;
                ViewBag.TradingFeatureAuthorName = tradingVideo.AuthorName;
                ViewBag.TradingFeatureAuthorSurname = tradingVideo.AuthorSurname;
                ViewBag.TradingFeatureAuthorImageUrl = tradingVideo.AuthorImageUrl;
                ViewBag.TradingFeatureCreatedDate = tradingVideo.CreatedDate;

            }
            return View();
        }
    }
}
