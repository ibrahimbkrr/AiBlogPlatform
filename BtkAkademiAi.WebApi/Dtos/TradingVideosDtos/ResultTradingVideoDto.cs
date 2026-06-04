using BtkAkademiAi.WebApi.Entities;

namespace BtkAkademiAi.WebApi.Dtos.TradingVideosDtos
{
    public class ResultTradingVideoDto
    {
        public int TradingVideoId { get; set; }
        public string VideoTitle { get; set; }
        public string VideoUrl { get; set; }
        public string VideoDescription { get; set; }
        public bool IsFeature { get; set; }
        public string? FeatureImageUrl { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string AuthorImageUrl { get; set; }
    }
}