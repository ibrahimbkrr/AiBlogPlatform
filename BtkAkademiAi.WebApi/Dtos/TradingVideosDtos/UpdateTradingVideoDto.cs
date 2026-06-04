namespace BtkAkademiAi.WebApi.Dtos.TradingVideosDtos
{
    public class UpdateTradingVideoDto
    {
        public int TradingVideoId { get; set; }
        public string VideoTitle { get; set; }
        public string VideoUrl { get; set; }
        public string VideoDescription { get; set; }
        public bool IsFeature { get; set; }
        public string? FeatureImageUrl { get; set; }
        public string? AppUserId { get; set; }
        public int? CategoryId { get; set; }
    }
}
