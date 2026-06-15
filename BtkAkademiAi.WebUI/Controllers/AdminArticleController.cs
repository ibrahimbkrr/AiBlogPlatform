using BtkAkademiAi.WebUI.Dtos.AiArticleDtos;
using BtkAkademiAi.WebUI.Dtos.ArticlesDtos;
using BtkAkademiAi.WebUI.Dtos.CategoryDtos;
using BtkAkademiAi.WebUI.Services;
using BtkAkademiAi.WebUI.Services.OpenAI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace BtkAkademiAi.WebUI.Controllers
{
    public class AdminArticleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IOpenAiArticleService _openAiArticleService;
        private readonly OpenAIArticleTitleService _openAiArticleTitleService;


        public AdminArticleController(
            IHttpClientFactory httpClientFactory,
            IOpenAiArticleService openAiArticleService,
            OpenAIArticleTitleService openAiArticleTitleService)
        {
            _httpClientFactory = httpClientFactory;
            _openAiArticleService = openAiArticleService;
            _openAiArticleTitleService = openAiArticleTitleService;
        }

        public async Task<IActionResult> ArticleList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7090/api/Articles");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var articles = JsonConvert.DeserializeObject<List<ResultArticleDto>>(jsonData);
                return View(articles);
            }

            return View();
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = client.GetAsync("https://localhost:7090/api/Categories").Result;

            var jsonData = responseMessage.Content.ReadAsStringAsync().Result;

            var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

            List<SelectListItem> categoryList = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();

            ViewBag.categoryList = categoryList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(CreateArticleDto createArticleDto)
        {
            createArticleDto.CreatedDate = DateTime.Now;

            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(createArticleDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7090/api/Articles", stringContent);

            return RedirectToAction("ArticleList");
        }

        public async Task<IActionResult> DeleteArticle(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.DeleteAsync($"https://localhost:7090/api/Articles/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                TempData["Error"] = "Silme işlemi başarısız oldu.";
            }

            return RedirectToAction("ArticleList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateArticle(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessageCategory = await client.GetAsync("https://localhost:7090/api/Categories");

            if (responseMessageCategory.IsSuccessStatusCode)
            {
                var jsonDataCategory = await responseMessageCategory.Content.ReadAsStringAsync();

                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonDataCategory);

                List<SelectListItem> categoryList = categories.Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();

                ViewBag.categoryList = categoryList;
            }

            var responseMessageArticle = await client.GetAsync($"https://localhost:7090/api/Articles/{id}");

            if (!responseMessageArticle.IsSuccessStatusCode)
            {
                TempData["Error"] = "Makale bulunamadı.";
                return RedirectToAction("ArticleList");
            }

            var jsonDataArticle = await responseMessageArticle.Content.ReadAsStringAsync();

            var article = JsonConvert.DeserializeObject<UpdateArticleDto>(jsonDataArticle);

            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateArticle(UpdateArticleDto updateArticleDto)
        {
            var client = _httpClientFactory.CreateClient();

            var jsonData = JsonConvert.SerializeObject(updateArticleDto);

            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7090/api/Articles", stringContent);

            return RedirectToAction("ArticleList");
        }

        [HttpPost]
        public async Task<IActionResult> GenerateArticleContentWithAi([FromBody] AiArticleRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    success = false,
                    message = "Lütfen geçerli bir makale konusu giriniz."
                });
            }

            try
            {
                var articleContent = await _openAiArticleService.GenerateArticleAsync(request.Prompt);

                return Json(new
                {
                    success = true,
                    articleContent = articleContent,
                    characterCount = articleContent.Length
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "AI ile makale oluşturulurken hata oluştu.",
                    detail = ex.Message
                });
            }
        }

        [HttpGet]
        public IActionResult GenerateArticleContentWithAi()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GenerateArticleTitleWithAi([FromBody] AiArticleTitleRequestDto request)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToList();

                return BadRequest(new
                {
                    success = false,
                    message = errors.FirstOrDefault() ?? "Lütfen geçerli bir metin giriniz."
                });
            }

            try
            {
                var articleTitle = await _openAiArticleTitleService.GenerateArticleTitleAsync(request.ArticleText);

                return Json(new
                {
                    success = true,
                    articleTitle = articleTitle,
                    characterCount = articleTitle.Length
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = "AI ile makale başlığı oluşturulurken hata oluştu.",
                    detail = ex.Message
                });
            }
        }

        [HttpGet]
        public IActionResult GenerateArticleTitleWithAi()
        {
            return View();
        }

    }
}