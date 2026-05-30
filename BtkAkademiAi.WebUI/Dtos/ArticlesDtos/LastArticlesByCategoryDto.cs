namespace BtkAkademiAi.WebUI.Dtos.ArticlesDtos
{
    public class LastArticlesByCategoryDto
    {
        public int ArticleId { get; set; }
        public string CategoryName { get; set; }
        public string ArticleTitle { get; set; }
        public string SliderCategoryImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
