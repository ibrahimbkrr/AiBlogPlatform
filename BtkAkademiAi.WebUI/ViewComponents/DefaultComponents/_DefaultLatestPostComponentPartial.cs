using BtkAkademiAi.WebUI.Dtos.ArticlesDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademiAi.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultLatestPostComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultLatestPostComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7090/api/Articles/GetLastAddedArticles");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var articles = JsonConvert.DeserializeObject<LastAddedArticlesDto>(jsonData);
                ViewBag.LastArticleCategory = articles.CategoryName;
                ViewBag.LastArticleTitle = articles.ArticleTitle;
                ViewBag.LastArticleTrendImageUrl = articles.TrendImageUrl;
                ViewBag.LastArticleCreatedDate = articles.CreatedDate;
                ViewBag.LastArticleAuthorName = articles.AuthorName;
                ViewBag.LastArticleAuthorSurname = articles.AuthorSurname;
                ViewBag.LastArticleAuthorImageUrl   = articles.AuthorImageUrl;

                
            }
            return View();
        }
    } 
}
