namespace BtkAkademiAi.WebUI.Dtos.CommentDtos
{
    public class GetCommentById
    {
        public string CommentId { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public bool IsConfirm { get; set; }

        public string CommentStatus { get; set; }

        public string AppUserId { get; set; }

        public int ArticleId { get; set; }

        public decimal Rating { get; set; }
    }
}
