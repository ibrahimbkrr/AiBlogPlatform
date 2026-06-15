namespace BtkAkademiAi.WebUI.Settings
{
    public class OpenAiOptions
    {
        public string ApiKey { get; set; } = string.Empty;

        public string Model { get; set; } = "gpt-5.4-mini";

        public int MinimumCharacterLength { get; set; } = 1500;

        public int MaxOutputTokens { get; set; } = 1500;
    }
}