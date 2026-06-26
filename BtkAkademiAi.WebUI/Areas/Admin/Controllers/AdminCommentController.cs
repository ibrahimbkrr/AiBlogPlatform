using BtkAkademiAi.WebUI.Dtos.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BtkAkademiAi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> CommentList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7090/api/Comments/WithArticleAndAuthor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var comments = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(comments);

            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateComment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(string commentDetail)
        {
            using (var client = new HttpClient())
            {
                var apiKey = "";
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiKey);

                try
                {
                    var translateRequestBody = new
                    {
                        inputs = commentDetail
                    };

                    var jsonRequestBody = JsonConvert.SerializeObject(translateRequestBody);

                }
                catch (Exception ex)
                {
                    // Handle any exceptions that may occur during the API call
                    ModelState.AddModelError(string.Empty, $"An error occurred while creating the comment: {ex.Message}");
                    return View();

                }
                return View();
            }
        }
    }
}
