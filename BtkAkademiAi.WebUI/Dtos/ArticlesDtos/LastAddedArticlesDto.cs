namespace BtkAkademiAi.WebUI.Dtos.ArticlesDtos
{
    public class LastAddedArticlesDto
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string TrendImageUrl { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string AuthorImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
