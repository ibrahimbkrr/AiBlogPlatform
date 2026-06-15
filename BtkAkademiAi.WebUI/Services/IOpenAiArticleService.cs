namespace BtkAkademiAi.WebUI.Services.OpenAI
{
    public interface IOpenAiArticleService
    {
        Task<string> GenerateArticleAsync(string userInput);
    }
}