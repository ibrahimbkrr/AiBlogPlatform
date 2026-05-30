using BtkAkademiAi.WebUI.Dtos.ArticlesDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademiAi.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultFeatureComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            #region LastTechnology_Article
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7090/api/Articles/last-technology-article");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var articles = JsonConvert.DeserializeObject<ResultArticleDto>(jsonData);
                ViewBag.LastTechnologyArticleTitle = articles.ArticleTitle;
                ViewBag.LastTechnologyArticleFeatureImageUrl = articles.FeatureImageUrl;
                ViewBag.LastTechnologyArticleCreatedDate = articles.CreatedDate;
                ViewBag.LastTechnologyArticleAuthorName = articles.AuthorName;
                ViewBag.LastTechnologyArticleAuthorSurname = articles.AuthorSurname;
                ViewBag.LastTechnologyArticleAuthorImageUrl = articles.AuthorImageUrl;


            }
            
           
            #endregion

            #region Last_Sports_Article
            var client2 = _httpClientFactory.CreateClient();
            var responseMessage2 = await client2.GetAsync("https://localhost:7090/api/Articles/last-sports-article");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var articles2 = JsonConvert.DeserializeObject<ResultArticleDto>(jsonData2);
                ViewBag.LastSportsArticleTitle = articles2.ArticleTitle;
                ViewBag.LastSportsArticleFeatureImageUrl = articles2.FeatureImageUrl;
                ViewBag.LastSportsArticleAuthorName = articles2.AuthorName;
                ViewBag.LastSportsArticleAuthorSurname = articles2.AuthorSurname;
                ViewBag.LastSportsArticleAuthorImageUrl = articles2.AuthorImageUrl;



            }
            #endregion
            #region Last_Egitim_Article
            var client3 = _httpClientFactory.CreateClient();
            var responseMessage3 = await client3.GetAsync("https://localhost:7090/api/Articles/last-egitim-article");
            if (responseMessage3.IsSuccessStatusCode)
            {
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var articles3 = JsonConvert.DeserializeObject<ResultArticleDto>(jsonData3);
                ViewBag.LastEgitimArticleTitle = articles3.ArticleTitle;
                ViewBag.LastEgitimArticleFeatureImageUrl = articles3.FeatureImageUrl;
                ViewBag.LastEgitimArticleAuthorName = articles3.AuthorName;
                ViewBag.LastEgitimArticleAuthorSurname = articles3.AuthorSurname;
                ViewBag.LastEgitimArticleAuthorImageUrl = articles3.AuthorImageUrl;

                return View();

            }
            #endregion
            return View();
            

        }
    }
}
