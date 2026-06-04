namespace BtkAkademiAi.WebUI.Dtos.ArticlesDtos
{
    public class TrendArticleDto
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }

        public string TrendImageUrl { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string AuthorName { get; set; }

        public string AuthorSurname { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
