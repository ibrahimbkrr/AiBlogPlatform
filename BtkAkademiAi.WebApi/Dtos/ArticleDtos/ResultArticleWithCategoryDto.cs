namespace BtkAkademiAi.WebApi.Dtos.ArticleDtos
{
    public class ResultArticleWithCategoryDto
    {
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        public string CoverImageUrl { get; set; }
        public string MainImageUrl { get; set; }
        public string ArticleContent { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsFeatureSlider { get; set; }
        public string FeatureSliderImageUrl { get; set; }
        public string FeatureImageUrl { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string AuthorImageUrl { get; set; }


    }
}
