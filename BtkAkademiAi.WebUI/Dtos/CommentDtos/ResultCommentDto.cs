namespace BtkAkademiAi.WebUI.Dtos.CommentDtos
{
    public class ResultCommentDto
    {
        public int CommentId { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public bool IsConfirm { get; set; }

        public string CommentStatus { get; set; }

        public int ArticleId { get; set; }

        public string ArticleName { get; set; }

        public string AppUserId { get; set; }

        public string AuthorName { get; set; }

        public string AuthorSurname { get; set; }

        public string AuthorImageUrl { get; set; }
    }
}
