using BtkAkademiAi.WebUI.Dtos.ArticlesDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademiAi.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultGetCategoriesWithLastArticleComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultGetCategoriesWithLastArticleComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7090/api/Articles/GetLastArticlesByDifferentCategories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var articles = JsonConvert.DeserializeObject<List<LastArticlesByCategoryDto>>(jsonData);
                return View(articles);
               
            }

            return View();

        }
    }
}
