namespace BtkAkademiAi.WebApi.Dtos.ArticleDtos
{
    public class GetLastFourArticleByCategoryDto
    {
        public int ArticleId { get; set; }
        public string CategoryName { get; set; }
        public string ArticleTitle { get; set; }
        public string TrendImageUrl { get; set; }
        
    }
}
