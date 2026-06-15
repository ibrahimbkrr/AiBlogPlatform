using BtkAkademiAi.WebUI.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace BtkAkademiAi.WebUI.Services.OpenAI
{
    public class OpenAiArticleService : IOpenAiArticleService
    {
        private readonly HttpClient _httpClient;
        private readonly OpenAiOptions _openAiOptions;

        public OpenAiArticleService(HttpClient httpClient, IOptions<OpenAiOptions> openAiOptions)
        {
            _httpClient = httpClient;
            _openAiOptions = openAiOptions.Value;
        }

        public async Task<string> GenerateArticleAsync(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                throw new ArgumentException("Makale konusu boş olamaz.");
            }

            var prompt = CreatePrompt(userInput);

            var articleContent = await SendRequestToOpenAiAsync(prompt);

            if (articleContent.Length < _openAiOptions.MinimumCharacterLength)
            {
                var expandPrompt = CreateExpandPrompt(userInput, articleContent);

                articleContent = await SendRequestToOpenAiAsync(expandPrompt);
            }

            return articleContent.Trim();
        }

        private async Task<string> SendRequestToOpenAiAsync(string prompt)
        {
            if (string.IsNullOrWhiteSpace(_openAiOptions.ApiKey))
            {
                throw new Exception("OpenAI API key bulunamadı.");
            }

            var requestBody = new
            {
                model = _openAiOptions.Model,
                input = prompt,
                max_output_tokens = _openAiOptions.MaxOutputTokens
            };

            using var request = new HttpRequestMessage(HttpMethod.Post, "responses");

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _openAiOptions.ApiKey);

            request.Content = JsonContent.Create(requestBody);

            using var response = await _httpClient.SendAsync(request);

            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"OpenAI isteği başarısız oldu. StatusCode: {response.StatusCode}, Response: {responseContent}");
            }

            var result = ExtractOutputText(responseContent);

            if (string.IsNullOrWhiteSpace(result))
            {
                throw new Exception("OpenAI cevabı boş geldi.");
            }

            return result;
        }

        private string CreatePrompt(string userInput)
        {
            return $"""
            Kullanıcının verdiği kısa konu:
            "{userInput}"

            Bu konuya göre Türkçe bir blog makalesi oluştur.

            Kurallar:
            - En az {_openAiOptions.MinimumCharacterLength} karakter uzunluğunda olsun.
            - Giriş, gelişme ve sonuç bölümü mantığında yaz.
            - Akıcı, sade ve anlaşılır Türkçe kullan.
            - Gereksiz tekrar yapma.
            - HTML etiketi kullanma.
            - Markdown kullanma.
            - Sadece makale içeriğini döndür.
            - Başlık yazma.
            """;
        }

        private string CreateExpandPrompt(string userInput, string currentArticle)
        {
            return $"""
            Aşağıdaki makale {_openAiOptions.MinimumCharacterLength} karakterden kısa kaldı.

            Konu:
            "{userInput}"

            Mevcut makale:
            {currentArticle}

            Bu makaleyi genişlet.

            Kurallar:
            - En az {_openAiOptions.MinimumCharacterLength} karakter uzunluğunda olsun.
            - Aynı cümleleri tekrar etme.
            - Akıcı ve doğal Türkçe kullan.
            - HTML etiketi kullanma.
            - Markdown kullanma.
            - Sadece genişletilmiş makale metnini döndür.
            """;
        }

        private static string ExtractOutputText(string json)
        {
            using var document = JsonDocument.Parse(json);

            var root = document.RootElement;

            if (root.TryGetProperty("output_text", out var outputText))
            {
                return outputText.GetString() ?? string.Empty;
            }

            if (root.TryGetProperty("output", out var outputArray))
            {
                foreach (var outputItem in outputArray.EnumerateArray())
                {
                    if (outputItem.TryGetProperty("content", out var contentArray))
                    {
                        foreach (var contentItem in contentArray.EnumerateArray())
                        {
                            if (contentItem.TryGetProperty("text", out var textElement))
                            {
                                return textElement.GetString() ?? string.Empty;
                            }
                        }
                    }
                }
            }

            return string.Empty;
        }
    }
}