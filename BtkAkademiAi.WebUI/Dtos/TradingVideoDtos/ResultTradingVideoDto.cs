namespace BtkAkademiAi.WebUI.Dtos.TradingVideoDtos
{
    public class ResultTradingVideoDto
    {
        public int TradingVideoId { get; set; }
        public string VideoTitle { get; set; }
        public string VideoUrl { get; set; }
        public string VideoDescription { get; set; }
        public bool IsFeature { get; set; }
        public string? FeatureImageUrl { get; set; }
        public DateTime CreatedDate { get; set; } 
        public string CategoryName { get; set; }
   
    }
}
