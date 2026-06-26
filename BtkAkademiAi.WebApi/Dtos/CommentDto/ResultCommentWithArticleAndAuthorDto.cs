namespace BtkAkademiAi.WebApi.Dtos.CommentDto
{
    public class ResultCommentWithArticleAndAuthorDto
    {
        public int CommentId { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }
              
        public string ArticleName { get; set; }

        public string AuthorName { get; set; }

        public string AuthorSurname { get; set; }

        public string AuthorImageUrl { get; set; }

        public decimal Rating { get; set; }
    }
}
