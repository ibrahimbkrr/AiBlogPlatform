namespace BtkAkademiAi.WebApi.Dtos.ArticleDtos
{
    public class GetArticleByIdDto
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string CoverImageUrl { get; set; }
        public string MainImageUrl { get; set; }
        public string ArticleContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        
    }
}
