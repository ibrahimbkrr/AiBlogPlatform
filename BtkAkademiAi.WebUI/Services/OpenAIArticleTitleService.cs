using BtkAkademiAi.WebUI.Settings;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace BtkAkademiAi.WebUI.Services
{
    public class OpenAIArticleTitleService
    {
        private readonly HttpClient _httpClient;
        private readonly OpenAiOptions _openAiOptions;

        private const int MaxTitleLength = 80;

        public OpenAIArticleTitleService(HttpClient httpClient, IOptions<OpenAiOptions> openAiOptions)
        {
            _httpClient = httpClient;
            _openAiOptions = openAiOptions.Value;
            
        }

        public async Task<string> GenerateArticleTitleAsync(string userInput)
        {
            if (string.IsNullOrWhiteSpace(userInput))
            {
                throw new ArgumentException("Başlık üretilecek metin boş olamaz.");
            }

            var prompt = CreatePrompt(userInput);

            var title = await SendRequestToOpenAiAsync(prompt);

            return CleanTitle(title);
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
                max_output_tokens = 100
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
            Aşağıdaki metin bir blog makalesi, makale özeti, konu açıklaması veya kullanıcı fikri olabilir.

            Kullanıcının verdiği metin:
            "{userInput}"

            Görev:
            Bu metne uygun Türkçe bir blog başlığı üret.

            Kurallar:
            - Sadece 1 adet başlık üret.
            - Başlık Türkçe olsun.
            - Başlık kısa, net ve anlaşılır olsun.
            - Başlık en fazla {MaxTitleLength} karakter olsun.
            - Blog makalesine uygun olsun.
            - Abartılı ve clickbait başlık kullanma.
            - HTML etiketi kullanma.
            - Markdown kullanma.
            - Tırnak işareti kullanma.
            - Açıklama yazma.
            - Alternatif başlıklar yazma.
            - Sadece başlığı döndür.
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

        private static string CleanTitle(string title)
        {
            title = title.Trim();

            title = title.Replace("\"", "");
            title = title.Replace("“", "");
            title = title.Replace("”", "");
            title = title.Replace("'", "");
            title = title.Replace("Başlık:", "", StringComparison.OrdinalIgnoreCase);
            title = title.Replace("Title:", "", StringComparison.OrdinalIgnoreCase);

            title = title.Split('\n')[0].Trim();

            if (title.Length <= MaxTitleLength)
            {
                return title;
            }

            var shortenedTitle = title.Substring(0, MaxTitleLength).Trim();

            var lastSpaceIndex = shortenedTitle.LastIndexOf(' ');

            if (lastSpaceIndex > 0)
            {
                shortenedTitle = shortenedTitle.Substring(0, lastSpaceIndex);
            }

            return shortenedTitle.Trim();
        }
    }
}